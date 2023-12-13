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
    internal class StoreEditViewModel : INotifyPropertyChanged
    {

        public string Title { get; set; }


        private string _ShelfLife;


        public string ShelfLife
        {
            get { return _ShelfLife; }
            set
            {
                _ShelfLife = value;
                OnPropertyChanged(nameof(ShelfLife));

            }
        }

        private Invoice _invoice;


        public Invoice invoice
        {
            get { return _invoice; }
            set
            {
                _invoice = value;
                OnPropertyChanged(nameof(invoice));

            }
        }

        private Product _product;


        public Product product
        {
            get { return _product; }
            set
            {
                _product = value;
                OnPropertyChanged(nameof(product));

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

        private string _PricePerUnit;


        public string PricePerUnit
        {
            get { return _PricePerUnit; }
            set
            {
                _PricePerUnit = value;
                OnPropertyChanged(nameof(PricePerUnit));

            }
        }

        public List<Product> Products { get; set; }

        public List<Invoice> Invoices { get; set; }


        public StoreEditViewModel(IRepository<Invoice> invoices, IRepository<Product> products)
        {
            Title = "Добавить резервы продуктов";

            Products = products.Items.ToList();
            Invoices = invoices.Items.ToList();

        }

        public StoreEditViewModel(IRepository<Invoice> invoices, IRepository<Product> products, Store store)
        {
            Title = "Редактировать резервы продуктов";

            Products = products.Items.ToList();
            Invoices = invoices.Items.ToList();

            ShelfLife = store.ShelfLife;
            invoice = store.Invoice;
            product = store.Product;
            Count = store.Count.ToString();
            PricePerUnit = store.PricePerUnit.ToString();

        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

    }
}
