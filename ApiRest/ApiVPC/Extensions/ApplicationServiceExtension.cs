using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiVPC.Services;

namespace ApiVPC.Extensions
{
    public static class ApplicationServiceExtension
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<JourneyService>();
        }
    }
}