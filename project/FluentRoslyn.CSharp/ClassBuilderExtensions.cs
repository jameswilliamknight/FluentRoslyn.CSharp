using Microsoft.CodeAnalysis.CSharp.Syntax;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace FluentRoslyn.CSharp;

public static class ClassBuilderExtensions
{
    public static ClassBuilder WithBase(this ClassBuilder builder, 
        params string[] inheritance)
    {
        builder.BaseList = BaseList(
            SingletonSeparatedList<BaseTypeSyntax>(
                SimpleBaseType(IdentifierName(inheritance.First()))));
        return builder;
    }
    
    public static ClassBuilder AddField(this ClassBuilder builder, string type,
        Func<FieldBuilder, FieldBuilder> classField)
    {
        var fieldBuilder = FieldBuilder.Create(type);
        var field = classField(fieldBuilder).Build();
        builder.Fields.Add(field);
        return builder;
    }
    
    public static ClassBuilder WithConstructor(this ClassBuilder builder,
        ConstructorBuilder constructorBuilder)
    {
        builder.Constructor = constructorBuilder.Build();
        return builder;
    }

    public static ClassBuilder WithMethod(this ClassBuilder builder,
        string methodName,
        Func<MethodBuilder, MethodBuilder> classMethod)
    {
        var methodBuilder = MethodBuilder.Create(methodName);
        var method = classMethod(methodBuilder).Build();
        builder.Methods.Add(method);
        return builder;
    }
    
    public static ClassBuilder AsReadOnly(this ClassBuilder builder)
    {
        builder.IsReadOnly = true;
        return builder;
    }
}