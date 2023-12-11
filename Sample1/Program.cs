using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using Sample1;
using Sample1.Library;
using Sample1.Models;

var host = new HostBuilder()
    .ConfigureFunctionsWebApplication(builder =>
    {
        //builder.Services.Add
        //builder.Services.AddFunctionsWorkerCore();
        //builder.Services.AddFunctionsWorkerDefaults();
        // can still register middleware and use this extension method the same way
        // .ConfigureFunctionsWorkerDefaults() is used
        //builder.UseWhen<RoutingMiddleware>((context) =>
        //{
        //    // We want to use this middleware only for http trigger invocations.
        //    return context.FunctionDefinition.InputBindings.Values
        //        .First(a => a.Type.EndsWith("Trigger")).Type == "httpTrigger";
        //});
    })
    .ConfigureServices(services =>
    {
        services.TryAddSingleton<ICrudService<FooCreate, Foo>, FooService>();
    })
    .Build();

host.Run();
