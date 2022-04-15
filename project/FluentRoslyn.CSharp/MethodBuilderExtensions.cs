using FluentRoslyn.CSharp.Model;

namespace FluentRoslyn.CSharp;

public static class MethodBuilderExtensions
{
    public static MethodBuilder WithParameters(this MethodBuilder builder,
        Func<ParametersBuilder, ParametersBuilder> methodParameters)
    {
        var parametersBuilder = ParametersBuilder.Create();
        var parameters = methodParameters(parametersBuilder).Build();
        builder.Parameters = parameters;
        return builder;
    }

    public static MethodBuilder WithBody(this MethodBuilder builder,
        Func<BodyBuilder, BodyBuilder> methodBody)
    {
        var bodyBuilder = BodyBuilder.Create();
        var body = methodBody(bodyBuilder).Build();
        builder.Body = body;
        return builder;
    }

    public static MethodBuilder Returns(this MethodBuilder builder,
        string returnType)
    {
        builder.ReturnType = returnType;
        return builder;
    }

    public static MethodBuilder AsAsync(this MethodBuilder builder)
    {
        builder.IsAsync = true;
        return builder;
    }

    public static MethodBuilder WithAccessibility(this MethodBuilder builder,
        Access access)
    {
        builder.Access = access;
        return builder;
    }
}
