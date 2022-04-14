namespace FluentRoslyn.CSharp.Model;

public record ProjectName(string Name)
{
    public override string ToString()
    {
        return Name;
    }
}