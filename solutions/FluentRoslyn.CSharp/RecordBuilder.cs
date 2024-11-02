using FluentRoslyn.CSharp.SyntaxExtensions;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace FluentRoslyn.CSharp;

public class RecordBuilder : MemberBuilderBase
{
    internal ParameterListSyntax? Parameters = null;

    private readonly string _memberName;

    internal BaseListSyntax? BaseList = null;

    private RecordBuilder(string name)
    {
        _memberName = name;
    }

    public static RecordBuilder Create(string name)
    {
        return new(name);
    }

    public RecordDeclarationSyntax Build()
    {
        return RecordDeclaration(
                Token(SyntaxKind.RecordKeyword),
                Identifier(_memberName))
            .WithClassOrStructKeyword(Token(SyntaxKind.ClassKeyword))
            .AddModifiers(BuildModifiers())
            .WithParameterList(Parameters ?? throw new("Missing Parameters") /* require >= 1 */)
            .WithBaseList(BaseList)
            .WithSemicolonToken(Token(SyntaxKind.SemicolonToken));
    }
}
