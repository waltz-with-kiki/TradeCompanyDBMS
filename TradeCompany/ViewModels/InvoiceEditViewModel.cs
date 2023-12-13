using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using TradeCompany.DAL.Interfaces;
using TradeCompany.Domain.Model;

namespace TradeCompany.ViewModels
{
    internal class InvoiceEditViewModel : INotifyPropertyChanged
    {
        public string Title { get; set; }


        private Partner _partner;

        public Partner partner
        {
            get { return _partner; }
            set
            {
                _partner = value;
                OnPropertyChanged(nameof(partner));

            }
        }
        private Order _Order;

        public Order Order
        {
            get { return _Order; }
            set
            {
                _Order = value;
                OnPropertyChanged(nameof(Order));

            }
        }

        private DateTime _DeliveryDate; 

        public DateTime DeliveryDate
        {
            get { return _DeliveryDate; }
            set
            {
                _DeliveryDate = value;
                OnPropertyChanged(nameof(DeliveryDate));

            }
        }

        public List<Partner> Partners { get; set; }

        public InvoiceEditViewModel(IRepository<Partner> partners)
        {
            Title = "Добавление накладной";

            DeliveryDate = DateTime.Now.Date;
            Partners = partners.Items.ToList();

        }

        public InvoiceEditViewModel(IRepository<Partner> partners,Invoice invoice)
        {
            Title = "Редактирование накладной";

            Partners = partners.Items.ToList();

            partner = invoice.Partner;
            DeliveryDate = invoice.DeliveryDate;

        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }





    }
}
