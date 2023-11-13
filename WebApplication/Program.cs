using WebApplication;

var builder = Microsoft.AspNetCore.Builder.WebApplication.CreateBuilder(args);

var services = builder.Services;

services.AddGraphQLServer();

services
    .AddGraphQL()
    .AddMutationConventions()
    .ModifyOptions((options) =>
    {
        options.EnableOneOf = true;
    })
    .AddType<ParameterInput.ColorParameters>()
    .AddType<ParameterInput.FileParameters>()
    .AddType<ParameterInput.WebPaymentParameters>()
    .AddQueryType<Queries>()
    .AddMutationType<Mutations>()
;

var app = builder.Build();

app.MapGraphQL();

app.Run();