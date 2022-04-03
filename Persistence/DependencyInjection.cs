using Application.Common.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using System;
using Persistence.Identity;
using Microsoft.AspNetCore.Identity;

namespace Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistance(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<SportAppDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("SportAppDbContextConnectionString"),
                b => b.MigrationsAssembly(typeof(SportAppDbContext).Assembly.FullName
            )));
            services.AddScoped<ISportAppDbContext>(provider => provider.GetService<SportAppDbContext>());
            services
                .AddDefaultIdentity<ApplicationUser>()
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<SportAppDbContext>();
            services.AddIdentityServer()
                .AddApiAuthorization<ApplicationUser, SportAppDbContext>();
            return services;
        }
    }
}