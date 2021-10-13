using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using WebAppLoginPage.Models.Data;
using Microsoft.Extensions.DependencyInjection;

namespace WebAppLoginPage.Models
{
    public static class ContextInjection
    {
        public static IServiceCollection AddDbContext(this IServiceCollection services)
        {
            services.AddSingleton<ILoginDbContext, LoginDbContext>();

            return services;
        }
    }
}
