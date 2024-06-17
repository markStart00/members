using members.Database.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace members.Api.Extensions
{
    public static class ServiceExtensions
    {

        public static IServiceCollection ConfigureApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {

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
