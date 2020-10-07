using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Primitives;

namespace Configmap
{
    internal class ConfigurationService : BackgroundService
    {
        private readonly ILogger<ConfigurationService> _logger;
        private readonly IConfiguration _configuration;

        public ConfigurationService(ILogger<ConfigurationService> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;

            ChangeToken.OnChange(_configuration.GetReloadToken, ConfigurationChanged);
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Executed");
            return Task.CompletedTask;
        }

        private void ConfigurationChanged()
        {
            _logger.LogInformation("Configuration changed");
        }
    }
}