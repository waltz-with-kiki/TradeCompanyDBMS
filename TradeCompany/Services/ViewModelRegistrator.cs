using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradeCompany.ViewModels;

namespace TradeCompany.Services
{
    static class ViewModelRegistration
    {
        public static IServiceCollection AddViewModels(this IServiceCollection services) => services
           .AddScoped<MainViewModel>()
            .AddScoped<AuthorizationViewModel>()
        ;
    }
}
