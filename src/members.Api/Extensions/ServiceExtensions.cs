using members.Application.Interfaces;
using members.Application.Mappings;
using members.Application.Services;
using members.Database.Infrastructure.Persistence;
using members.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace members.Api.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection ConfigureApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddScoped<IMembersService, MembersService>();
            services.AddScoped<IMembersRepository, MembersRepository>();

            services.AddAutoMapper(typeof(MappingProfile));

            services.AddDbContext<MembersDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("MembersConnectionString"), provider =>
                {
                    provider.EnableRetryOnFailure();
                });
            });

            return services;

        }

    }
}
