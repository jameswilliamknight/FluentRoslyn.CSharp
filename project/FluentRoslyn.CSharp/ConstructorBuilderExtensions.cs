namespace FluentRoslyn.CSharp;

public static class ConstructorBuilderExtensions
{
    public static ConstructorBuilder WithParameters(this ConstructorBuilder builder,
        Func<ParametersBuilder, ParametersBuilder> methodParameters)
    {
        var parametersBuilder = ParametersBuilder.Create();
        var parameters = methodParameters(parametersBuilder).Build();
        builder.Parameters = parameters;
        return builder;
    }

    public static ConstructorBuilder WithBody(this ConstructorBuilder builder,
        Func<BodyBuilder, BodyBuilder> constructorBody)
    {
        var bodyBuilder = BodyBuilder.Create();
        var body = constructorBody(bodyBuilder).Build();
        builder.Body = body;
        return builder;
    }
}
