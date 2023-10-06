using Application.Interfaces;
using Application.Service;
using Application.Services;
using Application.Throtting;
using Domain.Entities.MemberAggregate;
using Infrastructure.Repository;
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
        services.AddScoped<IOTPService, OTPService>();
        services.AddScoped<IJWTService, JwtService>();
        services.AddScoped<ISMSService, KavenegarSmsService>();
        services.AddScoped<ISMSService, SignalCompanySmsService>();
        services.AddScoped<IThrottler, Throttler>();
        services.AddScoped<IMembershipService, MembershipService>();
        services.AddScoped<IMemberService, MemberService>();

        services.AddScoped<IMemberRepository, MemberRepository>();
    }
}
