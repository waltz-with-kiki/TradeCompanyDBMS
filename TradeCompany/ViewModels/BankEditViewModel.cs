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
    internal class BankEditViewModel : INotifyPropertyChanged
    {
        public string Title { get; set; }


        private string _Name;


        public string Name { get { return _Name; } set
            {
                _Name = value;
                OnPropertyChanged(nameof(Name));
            
            } 
        }

        public BankEditViewModel()
        {
            Title = "Добавление банка";

        }

        public BankEditViewModel(Bank bank)
        {
            Title = "Редактирование банка";

            Name = bank.Name;

        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

    }
}
