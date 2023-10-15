using Application.Interfaces;
using Application.Service;
using Application.Services;
using Application.Throtting;
using Domain.Entities.MemberAggregate;
using Infrastructure.Repository;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Polly;

namespace Application.Extensions;

public static class IServiceCollectionExtensions
{
    public static void AddApplicationLayer(this IServiceCollection services, IConfiguration configuration, ILoggerFactory loggerFactory)
    {
        //services.AddAutoMapper();
        //services.AddMediator();
        //services.AddValidators();
        services.AddServices();
        services.AddPolicy(loggerFactory, configuration);
    }
    private static void AddServices(this IServiceCollection services)
    {
        services.AddScoped(typeof(IService<>), typeof(Service<>));
        services.AddScoped<IBookService, BookService>();
        services.AddScoped<IOTPService, OTPService>();
        services.AddScoped<IJWTService, JwtService>();
        services.AddScoped<ISmsProvider, KavenegarSmsService>();
        services.AddScoped<ISmsProvider, SignalCompanySmsService>();
        services.AddScoped<ISMSService, SMSService>();
        services.AddScoped<IThrottler, Throttler>();
        services.AddScoped<IMembershipService, MembershipService>();
        services.AddScoped<IMemberService, MemberService>();


        services.AddScoped<IMemberRepository, MemberRepository>();
    }
   private static void AddPolicy(this IServiceCollection services, ILoggerFactory loggerFactory, IConfiguration configuration)
    {
        // Register and configure the circuit breaker policy.
        
        services.AddHttpClient<ISMSService, SMSService>(client =>
        {
            client.BaseAddress = new Uri("http://localhost:56190/api/");
        })
                    .AddPolicyHandlers("PolicyConfig", loggerFactory, configuration);
    }
}
