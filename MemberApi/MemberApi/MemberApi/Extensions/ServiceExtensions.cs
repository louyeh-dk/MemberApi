using MemberApi.DAL.Data;
using MemberApi.DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MemberApi.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            });
        }

        public static void ConfigureDALServices(this IServiceCollection services, string connectionString)
        {
            services.ConfigureCors();
            services.AddScoped<IMemberRepository, MemberRepository>();
            services.AddDbContext<MemberContext>(option => option.UseSqlServer(connectionString));
            services.AddAutoMapper(typeof(MemberApi.Mappings.MappingProfile));

        }
    }
}

