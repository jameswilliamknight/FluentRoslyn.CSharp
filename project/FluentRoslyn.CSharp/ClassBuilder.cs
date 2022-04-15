using FluentRoslyn.CSharp.SyntaxExtensions;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace FluentRoslyn.CSharp;

public class ClassBuilder
{
    internal bool IsReadOnly = false;

    private SyntaxKind[] BuildModifiers()
    {
        var modifiers = new List<SyntaxKind>
        {
            SyntaxKind.PublicKeyword
        };
        
        if (IsReadOnly)
        {
            modifiers.Add(SyntaxKind.ReadOnlyKeyword);
        }
        
        return modifiers.ToArray();
    }
    
    internal ConstructorDeclarationSyntax? Constructor = null;

    internal readonly string Name;

    internal BaseListSyntax? BaseList = null;

    private ClassBuilder(string name)
    {
        Name = name;
    }

    public readonly List<FieldDeclarationSyntax> Fields = new();
    
    public readonly List<MethodDeclarationSyntax> Methods = new();

    public static ClassBuilder Create(string name)
    {
        return new(name);
    }

    public ClassDeclarationSyntax Build()
    {
        var classDeclarationSyntax = ClassDeclaration(Name)
            .AddModifiers(BuildModifiers())
            .WithBaseList(BaseList)
            .WithFields(Fields)
            .WithConstructor(Constructor ?? throw new("Missing Constructor"))
            .WithMethods(Methods);
        
        return classDeclarationSyntax;
    }
}