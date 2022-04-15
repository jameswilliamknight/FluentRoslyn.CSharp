namespace FluentRoslyn.CSharp;

public static class SourceFileBuilderExtensions
{
    public static SourceFileBuilder AddRecord(this SourceFileBuilder builder,
        string recordName,
        Func<RecordBuilder, RecordBuilder> sourceFileRecord)
    {
        var recordBuilder = RecordBuilder.Create(recordName);
        var record = sourceFileRecord(recordBuilder).Build();
        builder.SourceFileRecord = record;
        return builder;
    }

    public static SourceFileBuilder AddClass(this SourceFileBuilder builder,
        string className,
        Func<ClassBuilder, ClassBuilder> sourceFileClass)
    {
        var classBuilder = ClassBuilder.Create(className);
        var @class = sourceFileClass(classBuilder).Build();
        builder.SourceFileClass = @class;
        return builder;
    }

    public static SourceFileBuilder Using(this SourceFileBuilder builder,
        params string[] usings)
    {
        builder.Usings.AddRange(usings);
        return builder;
    }
}
