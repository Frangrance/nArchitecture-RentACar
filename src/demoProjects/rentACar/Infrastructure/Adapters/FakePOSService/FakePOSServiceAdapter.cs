using Application.Services.POSService;
using Core.CrossCuttingConcerns.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Adapters.FakePOSService
{
    internal class FakePOSServiceAdapter : IPOSService
    {
        public Task Pay(string invoiceNo, decimal price)
        {
            Random random = new Random();
            bool result = Convert.ToBoolean(random.Next(2));
            if (!result) throw new BusinessException("Payment is not successful.");
            return Task.CompletedTask;
        }
    }
}
