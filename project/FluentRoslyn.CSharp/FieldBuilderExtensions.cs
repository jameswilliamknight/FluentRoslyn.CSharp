using FluentRoslyn.CSharp.Model;

namespace FluentRoslyn.CSharp;

public static class FieldBuilderExtensions
{
    public static FieldBuilder WithAccessibility(this FieldBuilder builder, Access access)
    {
        builder.Access = access;
        return builder;
    }

    public static FieldBuilder AsReadOnly(this FieldBuilder builder)
    {
        builder.IsReadOnly = true;
        return builder;
    }
}
