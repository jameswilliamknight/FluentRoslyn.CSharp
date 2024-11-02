using FluentRoslyn.CSharp.Model;
using FluentRoslyn.CSharp.SyntaxExtensions;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace FluentRoslyn.CSharp;

public class MethodBuilder
{
    //internal List<ParameterSyntax> Parameters = new();
    internal ParameterListSyntax? Parameters = null;

    private readonly string _methodName;

    public bool IsAsync = false;

    private MethodBuilder(string methodName)
    {
        _methodName = methodName;
    }

    public readonly List<MethodDeclarationSyntax> Methods = new();
    public BlockSyntax? Body = null;
    public string ReturnType = "void";

    public Access Access = Access.Public;

    public static MethodBuilder Create(string name)
    {
        return new(name);
    }

    public MethodDeclarationSyntax Build()
    {
        if (IsAsync)
        {
            ReturnType = ReturnType == "void"
                ? "Task"
                : $"Task<{ReturnType}>";
        }

        return MethodDeclaration(
                IdentifierName(ReturnType),
                Identifier(_methodName))
            .WithParameters(Parameters)
            .WithAccessibility(Access)
            .ConfigureAsync(IsAsync)
            .WithBody(Body);
    }
}
