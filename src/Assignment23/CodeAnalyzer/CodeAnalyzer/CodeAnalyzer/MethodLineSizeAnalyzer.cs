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
    public class MethodSizeAnalyzer : DiagnosticAnalyzer
    {
        public const int MaximumMethodLineSize = 10;
        public const string DiagnosticId = "MS101";
        private static readonly LocalizableString Title = "Method Line Size Violation";
        private static readonly LocalizableString MessageFormat = "The '{0}' method is Method Line Size Violated";
        private static readonly LocalizableString Description = "The method contains more than 10 Lines";
        private const string Category = "StyleCop";

        private static readonly DiagnosticDescriptor Rule = new DiagnosticDescriptor(DiagnosticId, Title, MessageFormat, Category, DiagnosticSeverity.Warning, isEnabledByDefault: true, description: Description);

        public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics { get { return ImmutableArray.Create(Rule); } }

        public override void Initialize(AnalysisContext context)
        {
            context.ConfigureGeneratedCodeAnalysis(GeneratedCodeAnalysisFlags.None);
            context.EnableConcurrentExecution();
            context.RegisterSyntaxNodeAction(AnalyzeMethod, SyntaxKind.MethodDeclaration);
        }

        private static void AnalyzeMethod(SyntaxNodeAnalysisContext context)
        {
            var namedMethod = (MethodDeclarationSyntax)context.Node;

            if (namedMethod.Body?.Statements.Count > MaximumMethodLineSize)
            {
                var diagnostic = Diagnostic.Create(Rule, namedMethod.GetLocation(), namedMethod.Identifier);
                context.ReportDiagnostic(diagnostic);
            }
        }
    }
}
