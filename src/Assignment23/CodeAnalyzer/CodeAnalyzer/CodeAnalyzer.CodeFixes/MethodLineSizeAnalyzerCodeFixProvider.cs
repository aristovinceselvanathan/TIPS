using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CodeActions;
using Microsoft.CodeAnalysis.CodeFixes;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Rename;
using Microsoft.CodeAnalysis.Text;
using System;
using CodeAnalyzer;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Composition;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

 

namespace CodeAnalyzer
{
    [ExportCodeFixProvider(LanguageNames.CSharp, Name = nameof(MethodSizeAnalyzer)), Shared]
    public class MethodSizeAnalyzerCodeFixProvider : CodeFixProvider
    {
        private const int MaxMethodLength = 10;
        public sealed override ImmutableArray<string> FixableDiagnosticIds
        {
            get { return ImmutableArray.Create(MethodSizeAnalyzer.DiagnosticId); }
        }

        public sealed override FixAllProvider GetFixAllProvider()
        {
            return WellKnownFixAllProviders.BatchFixer;
        }

        public sealed override async Task RegisterCodeFixesAsync(CodeFixContext context)
        {
            var root = await context.Document.GetSyntaxRootAsync(context.CancellationToken).ConfigureAwait(false);

            var diagnostic = context.Diagnostics.First();
            var diagnosticSpan = diagnostic.Location.SourceSpan;

 
            var declaration = root.FindToken(diagnosticSpan.Start).Parent.AncestorsAndSelf().OfType<MethodDeclarationSyntax>().First();

            if (declaration != null)
            {
                context.RegisterCodeFix(
                    CodeAction.Create(
                        title: "Shorten the method",
                        createChangedDocument: c => ShortenMethodAsync(context.Document, declaration, c),
                        equivalenceKey: nameof(MethodSizeAnalyzer)),
                    diagnostic);
            }
        }

 

        private async Task<Document> ShortenMethodAsync(Document document, MethodDeclarationSyntax method, CancellationToken cancellationToken)
        {
            var newMethodBody = SyntaxFactory.Block(method.Body.Statements.Take(MaxMethodLength));

            var newMethod = method.WithBody(newMethodBody);
            var root = await document.GetSyntaxRootAsync(cancellationToken);
            var newRoot = root.ReplaceNode(method, newMethod);
            return document.WithSyntaxRoot(newRoot);
        }
    }
}