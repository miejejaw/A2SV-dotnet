using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using MediatR;

namespace Blog.Application;

public static class ApplicationServicesRegisteration{

    public static void ConfigureApplicationServices(this IServiceCollection services){
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddMediatR(Assembly.GetExecutingAssembly());
    }
}