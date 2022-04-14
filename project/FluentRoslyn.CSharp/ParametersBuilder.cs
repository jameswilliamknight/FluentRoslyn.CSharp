using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace FluentRoslyn.CSharp;

public class ParametersBuilder
{
    internal readonly List<SyntaxNodeOrToken> Parameters = new();
    
    public static ParametersBuilder Create()
    {
        return new();
    }

    public ParameterListSyntax Build()
    {
        return SyntaxFactory.ParameterList(
            SyntaxFactory.SeparatedList<ParameterSyntax>(
                Parameters.ToArray()
            )
        );
    }
}