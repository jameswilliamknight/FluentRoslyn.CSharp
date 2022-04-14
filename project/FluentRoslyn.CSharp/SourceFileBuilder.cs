using FluentRoslyn.CSharp.SyntaxExtensions;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace FluentRoslyn.CSharp;

public class SourceFileBuilder
{
    internal readonly List<string> Usings = new();
    
    internal RecordDeclarationSyntax? SourceFileRecord = null;
    internal ClassDeclarationSyntax? SourceFileClass = null;

    private readonly string _namespace;

    private SourceFileBuilder(string @namespace)
    {
        _namespace = @namespace;
    }

    public static SourceFileBuilder Create(string @namespace)
    {
        return new(@namespace);
    }
    
    public string Build()
    {
        var records = SourceFileRecord as MemberDeclarationSyntax;
        var classes = SourceFileClass as MemberDeclarationSyntax;
        var type = records ?? 
                   classes ?? 
                   throw new("source files require a type");

        var sourceFileString = CompilationUnit()
            .WithNamespace(_namespace)
            .Using(Usings)
            .AddMembers(type)
            .NormalizeWhitespace()
            .ToFullString();
        
        return sourceFileString;
    }
}