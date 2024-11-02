using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace FluentRoslyn.CSharp.SyntaxExtensions;

public static class CompilationUnitSyntaxExtensions
{
    public static CompilationUnitSyntax WithNamespace(this CompilationUnitSyntax unit, string @namespace)
    {
        return unit.AddMembers(FileScopedNamespaceDeclaration(ParseName(@namespace)));
    }

    public static CompilationUnitSyntax Using(this CompilationUnitSyntax unit, IEnumerable<string> usings)
    {
        return unit.WithUsings(GenerateUsings(usings.ToArray()));
    }

    private static SyntaxList<UsingDirectiveSyntax> GenerateUsings(params string[] usings)
    {
        var usingDirectives = List(usings.Select(x => UsingDirective(ParseName(x))).ToArray());
        return usingDirectives;
    }
}
