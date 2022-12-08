using Microsoft.EntityFrameworkCore;
using Padrao.Api.Configurations;
using Padrao.Data.Context;

namespace Padrao.Api;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddDbContext<MeuDbContext>(
            context => context.UseLoggerFactory(LoggerFactory.Create(builder => builder.AddConsole()))
                              .UseSqlite(Configuration.GetConnectionString("Default"))
        );

        services.AddIdentityConfig(Configuration);

        services.AddApiConfig();

        services.AddSwaggerConfig();

        services.ResolveDependencies();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        app.UseApiConfig(env);

        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Padrao.API v1"));
        }


    }
}
