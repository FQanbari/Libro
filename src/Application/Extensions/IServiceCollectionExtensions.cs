using Application.Interfaces;
using Application.Service;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Extensions;

public static class IServiceCollectionExtensions
{
    public static void AddApplicationLayer(this IServiceCollection services)
    {
        //services.AddAutoMapper();
        //services.AddMediator();
        //services.AddValidators();
        services.AddServices();
    }
    private static void AddServices(this IServiceCollection services)
    {
        services.AddScoped(typeof(IService<>), typeof(Service<>));
        services.AddScoped<IBookService, BookService>();
    }
}
