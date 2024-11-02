namespace FluentRoslyn.CSharp.Model;

public record ProjectInfo(ProjectName Name, string DirectoryPath)
{
    public string SdkName => $"{Name}.API.SDK";

    public FileInfo GetInfo(string path)
    {
        var fullPath = Path.Join(DirectoryPath, path);
        var info = new FileInfo(fullPath);
        return info;
    }
}
