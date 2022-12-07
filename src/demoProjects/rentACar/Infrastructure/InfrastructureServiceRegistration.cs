using Application.Services.FindeksService;
using Application.Services.POSService;
using Infrastructure.Adapters.FakeFindeksService;
using Infrastructure.Adapters.FakePOSService;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddScoped<IFindeksService, FakeFindeksServiceAdapter>();
            services.AddScoped<IPOSService, FakePOSServiceAdapter>();
            //services.AddScoped<ImageServiceBase, CloudinaryImageServiceAdapter>();      
            return services;
        }
    }
}
