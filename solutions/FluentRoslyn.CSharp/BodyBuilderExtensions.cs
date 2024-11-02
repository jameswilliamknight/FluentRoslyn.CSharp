using Microsoft.CodeAnalysis.CSharp;

namespace FluentRoslyn.CSharp;

public static class BodyBuilderExtensions
{
    public static BodyBuilder AddStatement(this BodyBuilder builder,
        string statement)
    {
        builder.Statements.Add(SyntaxFactory.ParseStatement(statement));
        return builder;
    }
}
