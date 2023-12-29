using SimpleApiDI.Services;
using SimpleApiDI.Services.Contracts;
using SimpleApiDI.Services.Interfaces;

namespace SimpleApiDI.Extensions;

public static class Extensions
{
    public static IServiceCollection Services(this IServiceCollection services)
    {
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        services.AddTransient<IOperationTransient, Operation>();
        services.AddScoped<IOperationScoped, Operation>();
        services.AddSingleton<IOperationSingleton, Operation>();
        services.AddTransient<FirstService, FirstService>();
        services.AddTransient<SecondService, SecondService>();
        
        

        return services;
    }
}