using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace FluentRoslyn.CSharp.SyntaxExtensions;

public static class ClassDeclarationSyntaxExtensions
{
    public static ClassDeclarationSyntax WithConstructor(this ClassDeclarationSyntax syntax,
        ConstructorDeclarationSyntax constructorSyntax)
    {
        syntax = syntax.AddMembers(constructorSyntax);
        return syntax;
    }

    public static ClassDeclarationSyntax AddModifiers(this ClassDeclarationSyntax syntax, params SyntaxKind[] kinds)
    {
        syntax = syntax.WithModifiers(TokenList(kinds.Select(Token).ToArray()));
        return syntax;
    }

    public static ClassDeclarationSyntax WithFields(this ClassDeclarationSyntax syntax,
        IEnumerable<FieldDeclarationSyntax> fields)
    {
        syntax = syntax.AddMembers(fields.Select(x => x as MemberDeclarationSyntax).ToArray());
        return syntax;
    }

    public static ClassDeclarationSyntax WithMethods(this ClassDeclarationSyntax syntax,
        IEnumerable<MethodDeclarationSyntax> methods)
    {
        syntax = syntax.AddMembers(methods.Select(x => x as MemberDeclarationSyntax).ToArray());
        return syntax;
    }
}
