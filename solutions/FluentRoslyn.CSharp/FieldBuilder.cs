using FluentRoslyn.CSharp.Extensions;
using FluentRoslyn.CSharp.Model;
using FluentRoslyn.CSharp.SyntaxExtensions;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace FluentRoslyn.CSharp;

public class FieldBuilder
{
    private readonly string _fieldType;

    private FieldBuilder(string fieldType)
    {
        _fieldType = fieldType;
    }

    public Access Access = Access.Private;
    public bool IsReadOnly = false;

    public static FieldBuilder Create(string fieldType)
    {
        return new(fieldType);
    }

    public FieldDeclarationSyntax Build()
    {
        var fieldName = ConvertInterfaceToPrivateFieldName(_fieldType);

        var syntaxTokens = new[]
        {
            Token(Access.AsSyntax())
        };

        if (IsReadOnly)
        {
            syntaxTokens = syntaxTokens
                .Concat(new[]
                {
                    Token(SyntaxKind.ReadOnlyKeyword),
                })
                .ToArray();
        }

        var field = FieldDeclaration(
                VariableDeclaration(IdentifierName(_fieldType))
                    .WithVariables(SingletonSeparatedList(VariableDeclarator(Identifier(fieldName)))))
            .WithModifiers(TokenList(syntaxTokens));
        return field;
    }

    /// <example>
    ///     IEntityRepository --> _entityRepository
    /// </example> 
    private static string ConvertInterfaceToPrivateFieldName(string interfaceType) =>
        $"_{interfaceType[1..].ToCamelCase()}";
}
