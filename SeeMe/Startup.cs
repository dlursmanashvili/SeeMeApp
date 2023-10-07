using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using SeeMeDataAccess.DBAdcess;
using SeeMeDataAccess;

public class Startup
{
    public IConfiguration Configuration { get; }

    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        // Добавьте здесь сервисы и зависимости, которые вам нужны
        

        services.AddControllers();
        services.AddScoped<MyMongoRepository>();

        // Настройка MongoDB и других сервисов
        services.AddSingleton(sp => new MongoClient(Configuration.GetConnectionString("MongoDB")));
        services.AddScoped(sp => new MyMongoDbContext(Configuration));
services.AddScoped<IMyMongoRepository, MyMongoRepository>();
        // Другие настройки
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();
        app.UseAuthorization();
        app.UseRouting();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}
