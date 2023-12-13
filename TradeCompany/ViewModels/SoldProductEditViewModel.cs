using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using TradeCompany.DAL.Interfaces;
using TradeCompany.Domain.Model;
using TradeCompany.Services;

namespace TradeCompany.ViewModels
{
    internal class SoldProductEditViewModel : INotifyPropertyChanged
    {
        public int StartCount { get; set; }
        public string Title { get; set; }


        private int _maxCount;

        public int MaxCount
        {
            get { return _maxCount; }
            set
            {
                _maxCount = value;
                OnPropertyChanged(nameof(MaxCount));
            }
        }


        private string _Count;


        public string Count
        {
            get { return _Count; }
            set
            {
                _Count = value;
                OnPropertyChanged(nameof(Count));

            }
        }

        private Order _order;


        public Order order
        {
            get { return _order; }
            set
            {
                _order = value;
                OnPropertyChanged(nameof(order));

            }
        }

        private Store _store;


        public Store store
        {
            get { return _store; }
            set
            {
                _store = value;
                OnPropertyChanged(nameof(store));

            }
        }

        private ICommand _CalculateMaxCount;
        public ICommand CalculateMaxCount => _CalculateMaxCount
           ??= new RelayCommand(OnCalculateMaxCountCommandExecuted, CanCalculateMaxCountCommandExecute);

        private bool CanCalculateMaxCountCommandExecute(object arg) => true;

        private void OnCalculateMaxCountCommandExecuted(object obj)
        {
            if (store != null && store.SoldProducts != null && store.SoldProducts.Any())
            {
                MaxCount = store.Count - store.SoldProducts.Sum(sp => sp.Count);
            }
            else
            {
                MaxCount = store.Count;
            }
        }

        /*public void CalculateMaxCount()
        {
            MaxCount = store.Count - store.SoldProducts.Sum(sp => sp.Count);
        }*/

        public List<Store> Stores { get; set; }

        public List<Order> Orders { get; set; }

        public SoldProductEditViewModel(IRepository<Order> orders, IRepository<Store> stores)
        {
            Title = "Добавить проданные продукты";

            Stores = stores.Items.ToList();
            Orders = orders.Items.ToList();


        }

        public SoldProductEditViewModel(IRepository<Order> orders, IRepository<Store> stores, SoldProduct soldproduct)
        {
            Title = "Редактировать проданные продукты";

            Stores = stores.Items.ToList();
            Orders = orders.Items.ToList();

            order = soldproduct.Order;
            store = soldproduct.Store;
            StartCount = soldproduct.Count;
            Count = soldproduct.Count.ToString();
            //CalculateMaxCount();

            MaxCount = store.Count - store.SoldProducts.Sum(sp => sp.Count);

        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }


      

    }
}
