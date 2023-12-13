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
    internal class PartnerEditViewModel : INotifyPropertyChanged
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

        private Country _country;


        public Country country
        {
            get { return _country; }
            set
            {
                _country = value;
                OnPropertyChanged(nameof(country));

            }
        }

        private HeadPerson _headPerson;


        public HeadPerson headPerson
        {
            get { return _headPerson; }
            set
            {
                _headPerson = value;
                OnPropertyChanged(nameof(headPerson));

            }
        }

        private string _LegalAdress;


        public string LegalAdress
        {
            get { return _LegalAdress; }
            set
            {
                _LegalAdress = value;
                OnPropertyChanged(nameof(LegalAdress));

            }
        }

        private string _PhoneNumber;


        public string PhoneNumber
        {
            get { return _PhoneNumber; }
            set
            {
                _PhoneNumber = value;
                OnPropertyChanged(nameof(PhoneNumber));

            }
        }

        private string _Email;


        public string Email
        {
            get { return _Email; }
            set
            {
                _Email = value;
                OnPropertyChanged(nameof(Email));

            }
        }


        private Bank _bank;


        public Bank bank
        {
            get { return _bank; }
            set
            {
                _bank = value;
                OnPropertyChanged(nameof(bank));

            }
        }

        private string _BankAccount;


        public string BankAccount
        {
            get { return _BankAccount; }
            set
            {
                _BankAccount = value;
                OnPropertyChanged(nameof(BankAccount));

            }
        }

        private string _Inn;


        public string Inn
        {
            get { return _Inn; }
            set
            {
                _Inn = value;
                OnPropertyChanged(nameof(Inn));

            }
        }


        public List<Country> Countries { get; set; }

        public List<HeadPerson> HeadPersons { get; set; }

        public List<Bank> Banks { get; set; }



        public PartnerEditViewModel(IRepository<Country> countries, IRepository<HeadPerson> headpersons, IRepository<Bank> banks)
        {
            Title = "Добавить партнера";

            Countries = countries.Items.ToList();
            HeadPersons = headpersons.Items.ToList();
            Banks = banks.Items.ToList();
        }

        public PartnerEditViewModel(IRepository<Country> countries, IRepository<HeadPerson> headpersons, IRepository<Bank> banks, Partner partner)
        {
            Title = "Редактировать партнера";

            Countries = countries.Items.ToList();
            HeadPersons = headpersons.Items.ToList();
            Banks = banks.Items.ToList();

            Name = partner.Name;
            country = partner.Country;
            headPerson = partner.HeadPerson;
            LegalAdress = partner.LegalAddress;
            PhoneNumber = partner.PhoneNumber;
            Email = partner.Email;
            bank = partner.Bank;
            BankAccount = partner.BankAccount;
            Inn = partner.Inn;

        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }



    }
}
