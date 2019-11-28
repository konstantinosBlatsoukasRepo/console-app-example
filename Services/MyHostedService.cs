using Microsoft.Extensions.Hosting;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MyGenericHost.Services
{
    public class  MyHostedService : IHostedService, IDisposable
    {
        private readonly IComplexBusinessLogic _complexBusinessLogic;

        public MyHostedService(IComplexBusinessLogic complexBusinessLogic)
        {
            _complexBusinessLogic = complexBusinessLogic;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _complexBusinessLogic.PerformComplexLogic();
            Console.WriteLine("My super hosted service just started!!");
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            Console.WriteLine("My super hosted service just finished!!");
            return Task.CompletedTask;
        }

        public void Dispose()
        {
            Console.WriteLine("Do nothing");
        }
    }
}
