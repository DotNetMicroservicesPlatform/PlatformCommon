using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PlatformCommon.Settings;

namespace PlatformCommon.Data;

public static class Extensions
{
    public static IServiceCollection AddAppDbContext<TContext>(this IServiceCollection services, IConfiguration configuration)where TContext : DbContext
    {
        var dbSettings = configuration.GetSection(nameof(SqlDbSettings)).Get<SqlDbSettings>();
        
        if (dbSettings.Server != null)
        {
            services.AddDbContext<TContext>((opt) => opt.UseSqlServer(dbSettings.ConnectionString));
        }
        else
        {
            services.AddDbContext<TContext>((opt) => opt.UseInMemoryDatabase(dbSettings.DbName));
        }
        return services;
    }
}