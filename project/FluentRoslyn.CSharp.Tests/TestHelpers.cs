namespace FluentRoslyn.CSharp.Tests;

public static class TestHelpers
{
    public static IReadOnlyCollection<string> NormaliseSource(string fileContents)
    {
        return fileContents
            .Split(Environment.NewLine)
            .Where(line => !string.IsNullOrWhiteSpace(line))
            .Select(line => line.Trim())
            .ToArray();
    }
}