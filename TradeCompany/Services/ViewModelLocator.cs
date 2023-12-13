using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradeCompany.ViewModels;

namespace TradeCompany.Services
{
    internal class ViewModelLocator
    {
        public MainViewModel Main => App.Services.GetRequiredService<MainViewModel>();
        public AuthorizationViewModel Authorization => App.Services.GetRequiredService<AuthorizationViewModel>();
    }
}
