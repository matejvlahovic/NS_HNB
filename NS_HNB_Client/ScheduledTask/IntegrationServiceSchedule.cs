using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace NS_HNB_Client.ScheduledTask
{
    public class IntegrationServiceSchedule : IHostedService
    {
        private IConfiguration _configuration;

       public IntegrationServiceSchedule(IConfiguration Configuration)
        {
            _configuration = Configuration;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            TimeSpan interval = TimeSpan.FromHours(24);
            var nextRunTime = DateTime.Today.AddDays(1).AddHours(1);
            var curTime = DateTime.Now;
            var firstInterval = nextRunTime.Subtract(curTime);
			Action action = () =>
			{
				var t1 = Task.Delay(firstInterval);
				t1.Wait();
                HttpClient client = new HttpClient();
                client.GetAsync(_configuration["IntegrationMethod"]);
            };

			Task.Run(action);
			return Task.CompletedTask;
		}

        public Task StopAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
