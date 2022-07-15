﻿
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace TravelWebsite.Business.Services
{
    public class ProvinceHostedService : IHostedService, IDisposable
    {
        private int executionCount = 0;
        private readonly ILogger<ProvinceHostedService> _logger;
        private Timer? _timer = null;

        public ProvinceHostedService(ILogger<ProvinceHostedService> logger)
        {
            _logger = logger;
        }

        public Task StartAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Timed Hosted Service running.");

            _timer = new Timer(DoWork, null, TimeSpan.Zero,
                TimeSpan.FromSeconds(5));

            return Task.CompletedTask;
        }

        private void DoWork(object? state)
        {
            var count = Interlocked.Increment(ref executionCount);

            _logger.LogInformation(
                "Timed Hosted Service is working. Count: {Count}", count);
        }

        public Task StopAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Timed Hosted Service is stopping.");

            _timer?.Change(Timeout.Infinite, 0);

            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }
    }
}
