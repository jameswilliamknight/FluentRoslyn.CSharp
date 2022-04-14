using FluentRoslyn.CSharp.Extensions;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace FluentRoslyn.CSharp.Model;

public record EntityName(string Singular, string Plural)
{
    public string SingularCamelCase => Singular.ToCamelCase();

    public IdentifierNameSyntax Identifier => SyntaxFactory.IdentifierName($"{Singular}Identity");
}