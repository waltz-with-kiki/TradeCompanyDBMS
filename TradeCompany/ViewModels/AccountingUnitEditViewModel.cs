using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using TradeCompany.Domain.Model;

namespace TradeCompany.ViewModels
{
    internal class AccountingUnitEditViewModel : INotifyPropertyChanged
    {

        public string Title { get; set; }


        private string _Name;


        public string Name
        {
            get { return _Name; }
            set
            {
                _Name = value;
                OnPropertyChanged(nameof(Name));

            }
        }

        public AccountingUnitEditViewModel()
        {
            Title = "Добавление единицы измерения";

        }

        public AccountingUnitEditViewModel(AccountingUnit accountingUnit)
        {
            Title = "Редактирование единицы измерения";

            Name = accountingUnit.Name;

        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
