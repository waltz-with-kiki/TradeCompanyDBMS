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
    internal class HeadPersonEditViewModel : INotifyPropertyChanged
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

        private string _Surname;


        public string Surname
        {
            get { return _Surname; }
            set
            {
                _Surname = value;
                OnPropertyChanged(nameof(Surname));

            }
        }


        public HeadPersonEditViewModel()
        {
            Title = "Добавление руководителя";

        }

        public HeadPersonEditViewModel(HeadPerson headperson)
        {
            Title = "Редактирование руководителя";

            Name = headperson.Name;
            Surname = headperson.Surname;

        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

    }
}
