using FluentRoslyn.CSharp.Extensions;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace FluentRoslyn.CSharp;

public static class ParameterBuilderExtensions
{
    public static ParametersBuilder AddParameter(this ParametersBuilder builder, 
        SyntaxKind type,
        string name)
    {
        // prefix a comma delimiter if there are existing parameters.
        var length = builder.Parameters.Count;
        if (length > 0)
        {
            builder.Parameters.Add(Token(SyntaxKind.CommaToken));
        }

        var param = Parameter(Identifier(name)).WithType(type);
        builder.Parameters.Add(param);
        return builder;
    }
    
    public static ParametersBuilder AddParameter(this ParametersBuilder builder,
        string type)
    {
        builder.AddParameter(type, type.ToCamelCase());
        return builder;
    }
    
    public static ParametersBuilder AddParameter(this ParametersBuilder builder,
        TypeSyntax type,
        string name)
    {
        var length = builder.Parameters.Count;
        if (length > 0)
        {
            builder.Parameters.Add(Token(SyntaxKind.CommaToken));
        }

        var param = Parameter(Identifier(name)).WithType(type);
        builder.Parameters.Add(param);
        return builder;
    }
    
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

    private static ParameterSyntax WithType(this ParameterSyntax syntax, 
        SyntaxKind type)
    {
        return syntax.WithType(PredefinedType(Token(type)));
    }
}