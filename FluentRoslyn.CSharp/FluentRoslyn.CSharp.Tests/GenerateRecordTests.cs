using FluentAssertions;
using FluentRoslyn.CSharp.Extensions;
using FluentRoslyn.CSharp.Model;
using Xunit;

namespace FluentRoslyn.CSharp.Tests;

public class GenerateRecordTests
{
    [Fact]
    public void GenerateRecord()
    {
        var entity = new Entity("Entity", "Entities");
        var sourceFileContents = SourceFileBuilder
            .Create("MyDomain.API.SDK.Clients.QueryResponses")
            .Using("MyDomain.Core.Identity")
            .AddRecord(entity.Name.Singular, rec => rec
                .WithImmutableProps(param => param
                    .AddParameter(entity.IdentifierType, "Identity")
                    .AddParameter(typeof(string), "Name")
                    .AddParameter(typeof(string), "Description")))
            .BuildForTest();

        var expected = TestHelpers.NormaliseSource(@"
            using MyDomain.Core.Identity;

            namespace MyDomain.API.SDK.Clients.QueryResponses;

            public record class Entity(EntityIdentity Identity, String Name, String Description);
        ");

        sourceFileContents.Should().BeEquivalentTo(expected);
    }

    [Fact]
    public void GenerateClass()
    {
        var entity = new Entity("Entity", "Entities");
        var entitySingularCamelCase = entity.Name.Singular.ToCamelCase();
        var sourceFileContents = SourceFileBuilder
            .Create($"MyDomain.Infrastructure.Queries.{entity.Name.Plural}")
            .Using(
                "System.Threading",
                "System.Threading.Tasks",
                "MediatR",
                "MyDomain.API.SDK.Clients.QueryResponses")
            .AddClass(entity.Name.Singular, @class => @class
                .WithBase($"IRequestHandler<Get{entity.Name.Singular}, Get{entity.Name.Singular}Response>")
                .AddField(
                    $"I{entity.Name.Singular}QueryRepository",
                    field => field
                        .WithAccessibility(Access.Private)
                        .AsReadOnly())
                .WithConstructor(ctor => ctor
                    .WithParameters(parameters => parameters
                        .AddParameter(
                            $"I{entity.Name.Singular}QueryRepository",
                            $"{entitySingularCamelCase}QueryRepository")
                    )
                    .WithBody(body => body
                        .AddStatement(
                            $"_{entitySingularCamelCase}QueryRepository = {entitySingularCamelCase}QueryRepository;")
                    )
                )
                .WithMethod(
                    "Handle",
                    method => method
                        .WithAccessibility(Access.Public)
                        .WithParameters(parameters => parameters
                            .AddParameter($"Get{entity.Name.Singular}", "query")
                            .AddParameter("CancellationToken"))
                        .WithBody(body => body
                            .AddStatement(
                                $"var entity = await _{entitySingularCamelCase}QueryRepository.GetAsync(query.Id);")
                            .AddStatement("return new(entity.Identity, entity.Name, entity.Description);")
                        )
                        .Returns($"Get{entity.Name.Singular}Response")
                        .AsAsync()
                )
            )
            .BuildForTest();

        var expected = TestHelpers.NormaliseSource(@"
            using System.Threading;
            using System.Threading.Tasks;
            using MediatR;
            using MyDomain.API.SDK.Clients.QueryResponses;

            namespace MyDomain.Infrastructure.Queries.Entities;
            public class Entity : IRequestHandler<GetEntity, GetEntityResponse>
            {
                private readonly IEntityQueryRepository _entityQueryRepository;
                public Entity(IEntityQueryRepository entityQueryRepository)
                {
                    _entityQueryRepository = entityQueryRepository;
                }

                public async Task<GetEntityResponse> Handle(GetEntity query, CancellationToken cancellationToken)
                {
                    var entity = await _entityQueryRepository.GetAsync(query.Id);
                    return new(entity.Identity, entity.Name, entity.Description);
                }
            }
        ");

        sourceFileContents.Should().BeEquivalentTo(expected);
    }
}
