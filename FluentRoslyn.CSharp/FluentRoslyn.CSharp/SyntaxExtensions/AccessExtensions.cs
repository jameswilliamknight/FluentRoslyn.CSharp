using FluentRoslyn.CSharp.Model;
using Microsoft.CodeAnalysis.CSharp;

namespace FluentRoslyn.CSharp.SyntaxExtensions;

public static class AccessExtensions
{
    public static SyntaxKind AsSyntax(this Access access)
    {
        var syntaxKind = access switch
        {
            Access.Private => SyntaxKind.PrivateKeyword,
            Access.Public => SyntaxKind.PublicKeyword,
            _ => throw new ArgumentOutOfRangeException($"Cannot add accessibility modifier: {access}"),
        };
        return syntaxKind;
    }
}
