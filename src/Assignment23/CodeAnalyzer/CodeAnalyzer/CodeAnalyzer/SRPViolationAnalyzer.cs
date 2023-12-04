using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Diagnostics;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Threading;

namespace CodeAnalyzer
{
    [DiagnosticAnalyzer(LanguageNames.CSharp)]
    public class SRPViolationAnalyzer : DiagnosticAnalyzer
    {
        public const int MaximumMethodLineSize = 10;
        public const string DiagnosticId = "MS102";
        private static readonly LocalizableString Title = "SRP (Single Responsibility Principle) Rule is Violated";
        private static readonly LocalizableString MessageFormat = "The '{0}' Class is SRP (Single Responsibility Principle) Rule is Violated";
        private static readonly LocalizableString Description = "Class doesn't contain more than 5 methods";
        private const string Category = "StyleCop";

        private static readonly DiagnosticDescriptor Rule = new DiagnosticDescriptor(DiagnosticId, Title, MessageFormat, Category, DiagnosticSeverity.Warning, isEnabledByDefault: true, description: Description);

        public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics { get { return ImmutableArray.Create(Rule); } }

        public override void Initialize(AnalysisContext context)
        {
            context.ConfigureGeneratedCodeAnalysis(GeneratedCodeAnalysisFlags.None);
            context.EnableConcurrentExecution();
            context.RegisterSyntaxNodeAction(AnalyzeClass, SyntaxKind.ClassDeclaration);
        }

        private static void AnalyzeClass(SyntaxNodeAnalysisContext context)
        {
            var namedClass = (ClassDeclarationSyntax)context.Node;

            if (namedClass.Members.OfType<MemberDeclarationSyntax>().Count() > 5)
            {
                var diagnostic = Diagnostic.Create(Rule, namedClass.GetLocation(), namedClass.Identifier);
                context.ReportDiagnostic(diagnostic);
            }
        }
    }
}
