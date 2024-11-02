namespace FluentRoslyn.CSharp.Model;

public record GeneratedFile(FileInfo Info, string Contents)
{
    public string Path => Info.FullName;
    public bool Exists => Info.Exists;
}
