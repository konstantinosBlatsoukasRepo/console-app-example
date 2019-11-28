using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace MyGenericHost.Services
{
    public class ComplexBusinessLogic : IComplexBusinessLogic
    {
        private readonly IConfiguration _configuration;

        public ComplexBusinessLogic(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void PerformComplexLogic()
        {
            var alo = _configuration.GetSection("Logging");
            Console.WriteLine("Some really complex logic is performed...");
            Console.WriteLine("AR, AI, VAR and many other super distributed ops");
        }
    }
}
