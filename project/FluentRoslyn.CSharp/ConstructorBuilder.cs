using FluentRoslyn.CSharp.SyntaxExtensions;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace FluentRoslyn.CSharp;

public class ConstructorBuilder
{
    internal ParameterListSyntax? Parameters = null;

    private readonly string _memberName;

    private ConstructorBuilder(string memberName)
    {
        _memberName = memberName;
    }

    public BlockSyntax? Body = null;

    public static ConstructorBuilder Create(string memberName)
    {
        return new(memberName);
    }

    public ConstructorDeclarationSyntax Build()
    {
        return ConstructorDeclaration(
                Identifier(_memberName))
            .WithModifiers(
                TokenList(
                    Token(SyntaxKind.PublicKeyword)))
            .WithParameters(Parameters)
            .WithBody(Body);
    }
}
