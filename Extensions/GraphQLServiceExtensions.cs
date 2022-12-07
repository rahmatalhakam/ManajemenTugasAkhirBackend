
using ManajemenTugasAkhirGeologi.Commons.Models;
using ManajemenTugasAkhirGeologi.ErrorFilters;
using ManajemenTugasAkhirGeologi.GraphQL.Students.Mutations;
using ManajemenTugasAkhirGeologi.GraphQL.Students.Queries;

namespace ManajemenTugasAkhirGeologi.Extensions;

public static class GraphQLServiceExtensions
{
    public static IServiceCollection AddGraphQLService(this IServiceCollection services)
    {

        services.AddGraphQLServer()
            .RegisterDbContext<AppDbContext>()
            .AddFiltering()
            .AddSorting()
            .AddAuthorization()
            .AddQueryType(q => q.Name("Query"))
                .AddTypeExtension<StudentQuery>()
            .AddMutationType(m => m.Name("Mutation"))
                .AddTypeExtension<StudentMutation>()
                .AddTypeExtension<AuthorizationMutation>()
            .AddFairyBread();

        services.AddErrorFilter<GraphQLErrorFilter>();
        return services;
    }
}