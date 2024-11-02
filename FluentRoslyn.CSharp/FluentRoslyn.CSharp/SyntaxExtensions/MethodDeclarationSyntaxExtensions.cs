using FluentRoslyn.CSharp.Model;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace FluentRoslyn.CSharp.SyntaxExtensions;

public static class MethodDeclarationSyntaxExtensions
{
    public static MethodDeclarationSyntax ConfigureAsync(this MethodDeclarationSyntax syntax,
        bool isAsync)
    {
        if (isAsync)
        {
            syntax = syntax.AddModifiers(SyntaxKind.AsyncKeyword);
        }

        return syntax;
    }

    private static MethodDeclarationSyntax AddModifiers(this MethodDeclarationSyntax syntax,
        params SyntaxKind[] kinds)
    {
        syntax = syntax.AddModifiers(kinds.Select(SyntaxFactory.Token).ToArray());
        return syntax;
    }

    public static MethodDeclarationSyntax WithAccessibility(this MethodDeclarationSyntax syntax,
        Access access)
    {
        var syntaxKind = access.AsSyntax();
        syntax = syntax.AddModifiers(SyntaxFactory.Token(syntaxKind));
        return syntax;
    }


    public static MethodDeclarationSyntax WithParameters(this MethodDeclarationSyntax syntax,
        ParameterListSyntax? parameters = null)
    {
        if (parameters == null)
        {
            return syntax;
        }

        syntax = syntax.WithParameterList(parameters!);
        return syntax;
    }
}
