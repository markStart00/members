using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace members.Apitests
{
    public class TestApplicationFactory : WebApplicationFactory<Program>
    {
        private readonly Action<IServiceCollection> _serviceOverride;

        public TestApplicationFactory(Action<IServiceCollection> serviceOverride)
        {
            _serviceOverride = serviceOverride;
        }

        protected override IHost CreateHost(IHostBuilder builder)
        {
            builder.ConfigureServices(_serviceOverride);
            return base.CreateHost(builder);
        }

    }
}