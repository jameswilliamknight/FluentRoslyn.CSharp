using Microsoft.CodeAnalysis.CSharp.Syntax;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace FluentRoslyn.CSharp;

public class BodyBuilder
{
    internal readonly List<StatementSyntax> Statements = new();

    private BodyBuilder()
    {
    }

    public static BodyBuilder Create()
    {
        return new();
    }

    public BlockSyntax Build()
    {
        return Block(Statements);
    }
}
