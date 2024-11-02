using FluentRoslyn.CSharp.Extensions;

namespace FluentRoslyn.CSharp.Model;

/// <seealso cref="Entity"/>
public record EntityName(string Singular, string Plural)
{
    public string SingularCamelCase => Singular.ToCamelCase();
}
