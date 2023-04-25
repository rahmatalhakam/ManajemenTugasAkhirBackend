
using ManajemenTugasAkhirGeologi.Service.Commons.Models;
using ManajemenTugasAkhirGeologi.Service.ErrorFilters;
using ManajemenTugasAkhirGeologi.Service.GraphQL.Students.Mutations;
using ManajemenTugasAkhirGeologi.Service.GraphQL.Students.Queries;

namespace ManajemenTugasAkhirGeologi.Service.Extensions;

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
            .AddFairyBread()
            .AddErrorFilter<GraphQLErrorFilter>()
            .AddDiagnosticEventListener<ErrorLoggingDiagnosticsEventListener>();

        return services;
    }
}