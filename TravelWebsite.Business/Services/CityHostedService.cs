
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using TravelWebsite.Business.Models.DTO;
using TravelWebsite.DataAccess.EF;
using TravelWebsite.DataAccess.Entities;

namespace TravelWebsite.Business.Services
{
    public class CityHostedService : IHostedService, IDisposable
    {
        private int executionCount = 0;
        private readonly ILogger<CityHostedService> _logger;
        private readonly IHttpClientFactory _httpClientFactory;
        private IServiceProvider _serviceProvider;
        private Timer? _timer = null;
        private Task _executingTask;
        private readonly CancellationTokenSource _stoppingCts = new CancellationTokenSource();

        public CityHostedService(ILogger<CityHostedService> logger, IHttpClientFactory httpClientFactory, IServiceProvider serviceProvider)
        {
            _logger = logger;
            _httpClientFactory = httpClientFactory;
            _serviceProvider = serviceProvider;
        }

        public Task StartAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Timed Hosted Service running.");

            _timer = new Timer(ExecuteTask, null, TimeSpan.Zero,
                TimeSpan.FromDays(49));

            return Task.CompletedTask;
        }

        private async Task DoWorkAsync(object? state)
        {
            ITravelDbContext travelDb = _serviceProvider.CreateScope().ServiceProvider.GetRequiredService<ITravelDbContext>();
            var httpClient = _httpClientFactory.CreateClient();
            var httpResponseMessage = await httpClient.GetAsync("https://provinces.open-api.vn/api/?depth=1");
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                var content =
                    await httpResponseMessage.Content.ReadAsStringAsync();
                var cities = JsonConvert.DeserializeObject
                    <IEnumerable<CityDTO>>(content);
                if (cities != null)
                {
                    foreach (var city in cities)
                    {
                        var existed = travelDb.Cities.FirstOrDefault(item => item.Code == city.Code);
                        if (existed == null)
                        {
                            travelDb.Cities.Add(new City
                            {
                                Name = city.Name,
                                Description = "xyzabc",
                                Link = "https://cf.bstatic.com/xdata/images/city/max500/689422.webp?k=2595c93e7e067b9ba95f90713f80ba6e5fa88a66e6e55600bd27a5128808fdf2&o=",
                                Code = city.Code
                            });
                        }
                    }
                    await travelDb.SaveChangesAsync();
                }
            }
            var count = Interlocked.Increment(ref executionCount);

            _logger.LogInformation(
                "Timed Hosted Service is working. Count: {Count}", count);
        }

        private void ExecuteTask(object? state)
        {
            _timer?.Change(Timeout.Infinite, 0);
            _executingTask = ExecuteTaskAsync(_stoppingCts.Token);
        }

        private async Task ExecuteTaskAsync(CancellationToken stoppingToken)
        {
            await DoWorkAsync(stoppingToken);
            _timer.Change(TimeSpan.FromSeconds(30), TimeSpan.FromMilliseconds(-1));
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
