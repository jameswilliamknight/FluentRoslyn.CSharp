using Microsoft.CodeAnalysis.CSharp.Syntax;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace FluentRoslyn.CSharp;

public static class RecordBuilderExtensions
{
    public static RecordBuilder WithParameters(this RecordBuilder builder,
        Func<ParametersBuilder, ParametersBuilder> classMethod)
    {
        var parametersBuilder = ParametersBuilder.Create();
        var parameters = classMethod(parametersBuilder).Build();
        builder.Parameters = parameters;
        return builder;
    }

    public static RecordBuilder WithBase(this RecordBuilder builder,
        params string[] inheritance)
    {
        builder.BaseList = BaseList(
            SingletonSeparatedList<BaseTypeSyntax>(
                SimpleBaseType(IdentifierName(inheritance.First()))));
        return builder;
    }
    
    public static RecordBuilder AsReadOnly(
        this RecordBuilder builder)
    {
        builder.IsReadOnly = true;
        return builder;
    }
}