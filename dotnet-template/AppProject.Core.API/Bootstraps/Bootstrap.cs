using System;

namespace AppProject.Core.API.Bootstraps;

public static class Bootstrap
{
    public static WebApplicationBuilder AddApiServices(this WebApplicationBuilder builder)
    {
        var mvcBuilder = builder.Services.AddControllers();
        return builder;
    }

    public static WebApplication UseApiPipeline(this WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            app.MapOpenApi();
        }

        app.UseHttpsRedirection();
        app.MapControllers();
        return app;
    }
}
