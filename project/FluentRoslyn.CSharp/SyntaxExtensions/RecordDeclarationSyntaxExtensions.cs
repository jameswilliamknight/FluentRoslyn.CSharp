using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace FluentRoslyn.CSharp.SyntaxExtensions;

public static class RecordDeclarationSyntaxExtensions
{
    public static RecordDeclarationSyntax AddModifiers(this RecordDeclarationSyntax syntax,
        params SyntaxKind[] kinds)
    {
        syntax = syntax.WithModifiers(SyntaxFactory.TokenList(kinds.Select(SyntaxFactory.Token).ToArray()));
        return syntax;
    }
}
