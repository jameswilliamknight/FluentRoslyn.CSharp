using Microsoft.CodeAnalysis.CSharp;

namespace FluentRoslyn.CSharp;

public abstract class MemberBuilderBase
{
    internal bool IsReadOnly = false;

    protected SyntaxKind[] BuildModifiers()
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
}
