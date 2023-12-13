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
    internal class OrderEditViewModel : INotifyPropertyChanged
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

        private DateTime _CompletionDate;


        public DateTime CompletionDate
        {
            get { return _CompletionDate; }
            set
            {
                _CompletionDate = value;
                OnPropertyChanged(nameof(CompletionDate));

            }
        }

        public List<Partner> Partners { get; set; }



        public OrderEditViewModel(IRepository<Partner> partners)
        {
            Title = "Добавить заказ";

            Partners = partners.Items.ToList();

            CompletionDate = DateTime.Now.Date;


        }

        public OrderEditViewModel(IRepository<Partner> partners, Order order)
        {
            Title = "Редактировать заказ";

            Partners = partners.Items.ToList();

            partner = order.Partner;
            CompletionDate = order.CompletionDate;

        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

    }
}
