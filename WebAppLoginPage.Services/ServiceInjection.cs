using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using WebAppLoginPage.Services.Interface;
using WebAppLoginPage.Services.Implementation;
using Microsoft.Extensions.DependencyInjection;

namespace WebAppLoginPage.Services
{
    public static class ServiceInjection
    {
        public static IServiceCollection AddServiceInjection(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();

            return services;
        }

    }
}
