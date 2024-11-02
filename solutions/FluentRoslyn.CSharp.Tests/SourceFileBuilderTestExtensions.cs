namespace FluentRoslyn.CSharp.Tests;

public static class SourceFileBuilderTestExtensions
{
    public static IReadOnlyCollection<string> BuildForTest(this SourceFileBuilder builder)
    {
        var fileContents = builder.Build();
        return TestHelpers.NormaliseSource(fileContents);
    }
}
