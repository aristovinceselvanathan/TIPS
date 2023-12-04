using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CodeActions;
using Microsoft.CodeAnalysis.CodeFixes;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Rename;
using Microsoft.CodeAnalysis.Text;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Composition;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;





namespace CodeAnalyzer
{
    [ExportCodeFixProvider(LanguageNames.CSharp, Name = nameof(SRPViolationAnalyzer)), Shared]
    public class SRPViolationAnalyzerCodeFixProvider : CodeFixProvider
    {
        public sealed override ImmutableArray<string> FixableDiagnosticIds
        {
            get { return ImmutableArray.Create(SRPViolationAnalyzer.DiagnosticId); }
        }





        public sealed override FixAllProvider GetFixAllProvider()
        {
            return WellKnownFixAllProviders.BatchFixer;
        }





        public override Task RegisterCodeFixesAsync(CodeFixContext context)
        {
            var diagnostic = context.Diagnostics.First();
            var root = context.Document.GetSyntaxRootAsync(context.CancellationToken).Result;
            var diagnosticSpan = diagnostic.Location.SourceSpan;
            var classDeclaration = root.FindNode(diagnostic.Location.SourceSpan).FirstAncestorOrSelf<ClassDeclarationSyntax>();
            context.RegisterCodeFix(
                CodeAction.Create(
                    "Move method to new class",
                    c => MoveMethodsToNewClassAsync(context.Document, root, diagnosticSpan, c),
                    nameof(SRPViolationAnalyzer)),
                diagnostic);
            return Task.CompletedTask;
        }





        private async Task<Document> MoveMethodsToNewClassAsync(Document document, SyntaxNode root, TextSpan diagnosticSpan, CancellationToken cancellationToken)
        {
            var classDeclaration = root.FindToken(diagnosticSpan.Start).Parent.AncestorsAndSelf().OfType<ClassDeclarationSyntax>().First();
            var methods = classDeclaration.Members.OfType<MethodDeclarationSyntax>();
            var originalClassName = classDeclaration.Identifier.Text;
            var newClasses = new List<ClassDeclarationSyntax>();
            var currentNewClass = SyntaxFactory.ClassDeclaration(originalClassName);
            int methodCountInCurrentClass = 0;



            foreach (var method in methods)
            {
                if (methodCountInCurrentClass >= 5)
                {
                    newClasses.Add(currentNewClass);
                    currentNewClass = SyntaxFactory.ClassDeclaration(originalClassName + $"{newClasses.Count}");
                    methodCountInCurrentClass = 0;
                }



                currentNewClass = currentNewClass.AddMembers(method);
                methodCountInCurrentClass++;
            }



            if (methodCountInCurrentClass > 0)
            {
                newClasses.Add(currentNewClass);
            }



            var oldRoot = await document.GetSyntaxRootAsync(cancellationToken);
            var newRoot = oldRoot.ReplaceNode(classDeclaration, newClasses);
            return document.WithSyntaxRoot(newRoot);
        }
    }
}