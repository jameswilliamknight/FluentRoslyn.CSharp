using FluentRoslyn.CSharp.Extensions;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace FluentRoslyn.CSharp;

public static class ParameterBuilderExtensions
{
    public static ParametersBuilder AddParameter(this ParametersBuilder builder,
        string type)
    {
        builder.AddParameter(type, type.ToCamelCase());
        return builder;
    }

    /// <summary>
    ///     Add a parameter of a type that does not exist yet
    /// </summary>
    public static ParametersBuilder AddParameter(this ParametersBuilder builder,
        string type,
        string name)
    {
        var length = builder.Parameters.Count;
        if (length > 0)
        {
            builder.Parameters.Add(Token(SyntaxKind.CommaToken));
        }

        var param = Parameter(Identifier(name)).WithType(IdentifierName(type));
        builder.Parameters.Add(param);
        return builder;
    }

    /// <summary>
    ///     Add a parameter of a known type
    /// </summary>
    public static ParametersBuilder AddParameter(this ParametersBuilder builder,
        Type type,
        string name)
    {
        var length = builder.Parameters.Count;
        if (length > 0)
        {
            builder.Parameters.Add(Token(SyntaxKind.CommaToken));
        }

        var param = Parameter(Identifier(name)).WithType(IdentifierName(type.Name));
        builder.Parameters.Add(param);
        return builder;
    }

    private static ParameterSyntax WithType(this ParameterSyntax syntax,
        SyntaxKind type)
    {
        return syntax.WithType(PredefinedType(Token(type)));
    }
}
