using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TradeCompany.Domain.Model.Base;

namespace TradeCompany.Domain.Model
{

    public class Structure : NamedEntity
    {

        public Structure? ParentStructure { get; set; }

        [NotMapped]
        public List<Structure>? Catalogs { get; set; }

        public string? DLLName { get; set; }

        [NotMapped]
        public ICommand? Command { get; set; }

        public string? function { get; set; }

        public int number { get; set; }
    }


    public class Right : Entity
    {

        public int? UserId { get; set; }

        public virtual User? User { get; set; }

        public bool R { get; set; } = false;

        public bool W { get; set; } = false;

        public bool E { get; set; } = false;

        public bool D { get; set; } = false;

        public FormType? Form
        {
            get;
            set;
        }

    }

    public enum FormType
    {
        AccountingUnitForm,
        BankForm,
        CountryForm,
        GroupForm,
        HeadPersonForm,
        InvoiceForm,
        ManufacturerForm,
        OrderForm,
        PartnerForm,
        ProductForm,
        SoldProductForm,
        StoreForm,
        AdminForm,
    }

    public class User : NamedEntity
    {
        public string? Password { get; set; }

        public virtual ICollection<Right>? Rights { get; set; } = new List<Right>();

        public override string ToString()
        {
            return Id.ToString();
        }

    }

    public class Partner : NamedEntity
    {

        public int? CountryId { get; set; }

        public int? HeadPersonId { get; set; }

        public string? LegalAddress { get; set; }

        public string? PhoneNumber { get; set; }

        public string? Email { get; set; }

        public int? BankId { get; set; }

        public string? BankAccount { get; set; }

        public string? Inn { get; set; }


        public virtual ICollection<Invoice>? Invoices { get; set; } 


        public virtual Bank? Bank { get; set; }


        public virtual Country? Country { get; set; }

        public virtual HeadPerson? HeadPerson { get; set; }

        public virtual ICollection<Order>? Orders { get; set; }

        public override string ToString()
        {
            return Name.ToString();
        }


    }

    public class Invoice : Entity, INotifyPropertyChanged
    {
        public int? PartnerId { get; set; }

        [Column(TypeName = "date")]
        public DateTime DeliveryDate { get; set; }

        public virtual Partner? Partner { get; set;}

        private ObservableCollection<Store>? stores;
        public ObservableCollection<Store>? Stores
        {
            get { return stores; }
            set
            {
                if (stores != value)
                {
                    stores = value;
                    OnPropertyChanged(nameof(Stores));
                }
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }

    public class Store : Entity
    {

        public string? ShelfLife { get; set; }

        public int? InvoiceId { get; set; }

        public int? ProductId { get; set; }

        public int Count { get; set; }


        [Column(TypeName = "decimal(18,2)")]
        public decimal PricePerUnit { get; set; }

        public virtual Invoice? Invoice { get; set; }

        public virtual Product? Product { get; set; }

        public virtual ICollection<SoldProduct>? SoldProducts { get; set; }
    }

    public class Bank : NamedEntity
    {
        public virtual ICollection<Partner>? Partners { get; set; }

        public override string ToString()
        {
            return Name.ToString();
        }
    }

    public class Country : NamedEntity
    {
        public virtual ICollection<Partner>? Partners { get; set; }

        public override string ToString()
        {
            return Name.ToString();
        }
    }

    public class HeadPerson : NamedEntity
    {
        public string? Surname { get; set; }

        public virtual ICollection<Partner>? Partners { get; set; }

        public override string ToString()
        {
            return (Name + " " + Surname).ToString();
        }

    }

    public class Order : Entity, INotifyPropertyChanged
    {
        public int? PartnerId { get; set; }

        public DateTime CompletionDate { get; set; }

        public virtual Partner? Partner { get; set; }

        private ObservableCollection<SoldProduct>? soldproducts;
        public ObservableCollection<SoldProduct>? SoldProducts
        {
            get { return soldproducts; }
            set
            {
                if (soldproducts != value)
                {
                    soldproducts = value;
                    OnPropertyChanged(nameof(SoldProducts));
                }
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class SoldProduct : Entity
    {

        public int Count { get; set; }

        public int? StoreId { get; set; }

        public int? OrderId { get; set; }

        [ForeignKey("OrderId")]
        public virtual Order? Order { get; set; }
        
        [ForeignKey("StoreId")]
        public virtual Store? Store { get; set; }
    }

    public class Product : NamedEntity
    {

        public int? GroupId { get; set; }

        public int? ManufacturerId { get; set; }

        public int? AccountingUnitId { get; set; }

       //public int? ImageId { get; set; }

        public virtual AccountingUnit? AccountingUnit { get; set; }

        public virtual Group? Group { get; set; }

       // public virtual Image? Image { get; set; }

        public virtual Manufacturer? Manufacturer { get; set; }

        public virtual ICollection<Store>? Stores { get; set; }

        public override string ToString()
        {
            return Name.ToString();
        }

    }

    public class AccountingUnit : NamedEntity
    {
        public virtual ICollection<Product>? Products { get; set; }

        public override string ToString()
        {
            return Name.ToString();
        }
    }

    public class Group : NamedEntity
    {
        public virtual ICollection<Product>? Products { get; set; }

        public override string ToString()
        {
            return Name.ToString();
        }

    }

    public class Manufacturer : NamedEntity
    {
        public virtual ICollection<Product>? Products { get; set; }

        public override string ToString()
        {
            if (Name != null)
                return Name.ToString();

            return base.ToString(); // Или вернуть что-то еще, если Name равно null
        }
    }

}
