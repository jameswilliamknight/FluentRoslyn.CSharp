using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace FluentRoslyn.CSharp.SyntaxExtensions;

public static class ConstructorDeclarationSyntaxExtensions
{
    public static ConstructorDeclarationSyntax WithParameters(this ConstructorDeclarationSyntax syntax,
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
