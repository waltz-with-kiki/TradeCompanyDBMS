using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeCompany.Services.Interface
{
    interface IActionHandlerService
    {
        public bool Add<T>(T item);

        public bool Edit<T>(T item);

        bool ConfirmInformation(string Information, string Caption);
        bool ConfirmWarning(string Warning, string Caption);
        bool ConfirmError(string Error, string Caption);

    }
}
