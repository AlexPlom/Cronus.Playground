using Elders.Cronus;
using Elders.Cronus.Api;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace Cronus.Host
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly ICronusHost cronusHost;

        public Worker(IServiceProvider provider, ICronusHost cronusHost, ILogger<Worker> logger)
        {
            _logger = logger;
            this.cronusHost = cronusHost;
            CronusBooter.BootstrapCronus(provider);
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Starting service...");

            Activity.DefaultIdFormat = ActivityIdFormat.W3C;

            cronusHost.Start();

            _logger.LogInformation("Service started");
        }

        public override Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Stopping service...");

            cronusHost.Stop();

            _logger.LogInformation("Service stopped!");
            return Task.CompletedTask;
        }
    }
}
