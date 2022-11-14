//using CertWall.Api.Extensions;
//using CertWall.Business.Notifications;
using AutoMapper;
using Padrao.Api.DTOs.AutoMapper;
using Padrao.Business.Interfaces;
using Padrao.Business.Repository;
using Padrao.Data.Context;
using Padrao.Data.Repository;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;

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

        //services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();


        return services;
    }
}

