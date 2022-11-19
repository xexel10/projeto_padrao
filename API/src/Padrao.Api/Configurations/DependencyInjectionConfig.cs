//using CertWall.Api.Extensions;
//using CertWall.Business.Notifications;
using AutoMapper;
using Padrao.Api.DTOs.AutoMapper;
using Padrao.Business.Interfaces;
using Padrao.Data.Repository;
using Padrao.Api.Contratos;
using ProEventos.Application;

using ProEventos.Application.Contratos;

namespace Padrao.Api.Configurations;
public static class DependencyInjectionConfig
{
    public static IServiceCollection ResolveDependencies(this IServiceCollection services)
    {
        //services.AddScoped<INotifier, Notifier>();

        services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

        //services.AddScoped<IUser, AspNetUser>();

        var mappingConfig = new MapperConfiguration(mc =>
        {
            mc.AddProfile(new AutoMapperConfig());
        });
        IMapper mapper = mappingConfig.CreateMapper();
        services.AddSingleton(mapper);

        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IAccountService, AccountService>();
        services.AddScoped<ITokenService, TokenService>();
        services.AddScoped<IGeralPersist, GeralPersist>();
        services.AddScoped<IUserPersist, UserPersist>();

        //services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();


        return services;
    }
}

