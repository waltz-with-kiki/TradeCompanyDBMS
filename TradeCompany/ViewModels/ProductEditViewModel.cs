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
    internal class ProductEditViewModel : INotifyPropertyChanged
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

        private Manufacturer _manufacturer;


        public Manufacturer manufacturer
        {
            get { return _manufacturer; }
            set
            {
                _manufacturer = value;
                OnPropertyChanged(nameof(manufacturer));

            }
        }

        private Group _group;


        public Group group
        {
            get { return _group; }
            set
            {
                _group = value;
                OnPropertyChanged(nameof(group));

            }
        }

        private AccountingUnit _accountingUnit;


        public AccountingUnit accountingUnit
        {
            get { return _accountingUnit; }
            set
            {
                _accountingUnit = value;
                OnPropertyChanged(nameof(accountingUnit));

            }
        }


        // private readonly IRepository<Group> _Gros;

        public List<Group> Groups { get; set; }
        public List<Manufacturer> Manufacturers { get; set; }

        public List<AccountingUnit> AccountingUnits { get; set; }

        public ProductEditViewModel(IRepository<Group> groups, IRepository<Manufacturer> manufacturers, IRepository<AccountingUnit> accountingUnits)
        {
            Title = "Добавить продукт";

            Groups = groups.Items.ToList();
            Manufacturers = manufacturers.Items.ToList();
            AccountingUnits = accountingUnits.Items.ToList();
        }

        public ProductEditViewModel(IRepository<Group> groups, IRepository<Manufacturer> manufacturers, IRepository<AccountingUnit> accountingUnits, Product product)
        {
            Title = "Редактировать продукт";

            Groups = groups.Items.ToList();
            Manufacturers = manufacturers.Items.ToList();
            AccountingUnits = accountingUnits.Items.ToList();

            Name = product.Name;
            group = product.Group;
            manufacturer = product.Manufacturer;
            accountingUnit = product.AccountingUnit;


        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
