using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using TradeCompany.DAL.Interfaces;
using TradeCompany.Domain.Model;
using TradeCompany.Services;
using TradeCompany.Services.Interface;


namespace TradeCompany.ViewModels
{
    internal class MainViewModel : INotifyPropertyChanged
    {
        private readonly IRepository<Structure> _RepStructures;
        private readonly IRepository<User> _RepUsers;
        private readonly IRepository<Right> _RepRights;
        private readonly IRepository<SoldProduct> _RepSoldProducts;
        private readonly IRepository<Order> _RepOrders;
        private readonly IRepository<Store> _RepStores;
        private readonly IRepository<Invoice> _RepInvoices;
        private readonly IRepository<Product> _RepProducts;
        private readonly IRepository<AccountingUnit> _RepAccountingUnits;
        private readonly IRepository<Group> _RepGroups;
        private readonly IRepository<Partner> _RepPartners;
        private readonly IRepository<Bank> _RepBanks;
        private readonly IRepository<Country> _RepCountries;
        private readonly IRepository<HeadPerson> _RepHeadPersons;
        private readonly IRepository<Manufacturer> _RepManufacturers;
        private readonly IActionHandlerService _UserDialog;



        private bool _IsDataLoaded = false;

        public bool IsDataLoaded
        {
            get { return _IsDataLoaded; }
            set
            {
                _IsDataLoaded = value;
                OnPropertyChanged(nameof(IsDataLoaded));
            }
        }

        private ObservableCollection<User> _Users;


        private CollectionViewSource _UsersViewSource;

        public ICollectionView UsersView => _UsersViewSource?.View;

        public ObservableCollection<User> Users
        {
            get => _Users;
            set
            {
                _Users = value;

                _UsersViewSource = new CollectionViewSource
                {
                    Source = _Users,
                };

                _UsersViewSource.View.Refresh();

                OnPropertyChanged(nameof(UsersView));
                OnPropertyChanged();
            }
        }


        private ObservableCollection<Bank> _Banks;


        private CollectionViewSource _BanksViewSource;

        public ICollectionView BanksView => _BanksViewSource?.View;

        public ObservableCollection<Bank> Banks
        {
            get => _Banks;
            set
            {
                _Banks = value;

                _BanksViewSource = new CollectionViewSource
                {
                    Source = _Banks,
                };

                _BanksViewSource.View.Refresh();

                OnPropertyChanged(nameof(BanksView));
                OnPropertyChanged();
            }
        }

        private ObservableCollection<Partner> _Partners;


        private CollectionViewSource _PartnersViewSource;

        public ICollectionView PartnersView => _PartnersViewSource?.View;

        public ObservableCollection<Partner> Partners
        {
            get => _Partners;
            set
            {
                _Partners = value;

                _PartnersViewSource = new CollectionViewSource
                {
                    Source = _Partners,
                };

                _PartnersViewSource.View.Refresh();

                OnPropertyChanged(nameof(PartnersView));
                OnPropertyChanged();
            }
        }

        private ObservableCollection<Order> _Orders;


        private CollectionViewSource _OrdersViewSource;

        public ICollectionView OrdersView => _OrdersViewSource?.View;

        public ObservableCollection<Order> Orders
        {
            get => _Orders;
            set
            {
                _Orders = value;

                _OrdersViewSource = new CollectionViewSource
                {
                    Source = _Orders,
                };

                _OrdersViewSource.View.Refresh();

                OnPropertyChanged(nameof(OrdersView));
                OnPropertyChanged();
            }
        }

        private ObservableCollection<Invoice> _Invoices;


        public CollectionViewSource _InvoicesViewSource;

        public ICollectionView InvoicesView => _InvoicesViewSource?.View;

        public ObservableCollection<Invoice> Invoices
        {
            get => _Invoices;
            set
            {
                _Invoices = value;

                _InvoicesViewSource = new CollectionViewSource
                {
                    Source = _Invoices,
                };

                _InvoicesViewSource.View.Refresh();

                OnPropertyChanged(nameof(Invoices));
                OnPropertyChanged(nameof(InvoicesView));
            }
        }

        private ObservableCollection<Store> _Stores;


        private CollectionViewSource _StoresViewSource;

        public ICollectionView StoresView => _StoresViewSource?.View;

        public ObservableCollection<Store> Stores
        {
            get => _Stores;
            set
            {
                _Stores = value;

                _StoresViewSource = new CollectionViewSource
                {
                    Source = _Stores,
                };

                _StoresViewSource.View.Refresh();

                OnPropertyChanged(nameof(Stores));
                OnPropertyChanged(nameof(StoresView));
            }
        }

        private ObservableCollection<SoldProduct> _SoldProducts;


        private CollectionViewSource _SoldProductsViewSource;

        public ICollectionView SoldProductsView => _SoldProductsViewSource?.View;

        public ObservableCollection<SoldProduct> SoldProducts
        {
            get => _SoldProducts;
            set
            {
                _SoldProducts = value;

                _SoldProductsViewSource = new CollectionViewSource
                {
                    Source = _SoldProducts,
                };

                _SoldProductsViewSource.View.Refresh();

                OnPropertyChanged(nameof(SoldProductsView));
                OnPropertyChanged();
            }
        }

        private ObservableCollection<Product> _Products;


        private CollectionViewSource _ProductsViewSource;

        public ICollectionView ProductsView => _ProductsViewSource?.View;

        public ObservableCollection<Product> Products
        {
            get => _Products;
            set
            {
                _Products = value;

                _ProductsViewSource = new CollectionViewSource
                {
                    Source = _Products,
                };

                _ProductsViewSource.View.Refresh();

                OnPropertyChanged(nameof(ProductsView));
                OnPropertyChanged();
            }
        }

        private ObservableCollection<HeadPerson> _HeadPersons;


        private CollectionViewSource _HeadPersonsViewSource;

        public ICollectionView HeadPersonsView => _HeadPersonsViewSource?.View;

        public ObservableCollection<HeadPerson> HeadPersons
        {
            get => _HeadPersons;
            set
            {
                _HeadPersons = value;

                _HeadPersonsViewSource = new CollectionViewSource
                {
                    Source = _HeadPersons,
                };

                _HeadPersonsViewSource.View.Refresh();

                OnPropertyChanged(nameof(HeadPersonsView));
                OnPropertyChanged();
            }
        }

        private ObservableCollection<Manufacturer> _Manufacturers;


        private CollectionViewSource _ManufacturersViewSource;

        public ICollectionView ManufacturersView => _ManufacturersViewSource?.View;

        public ObservableCollection<Manufacturer> Manufacturers
        {
            get => _Manufacturers;
            set
            {
                _Manufacturers = value;

                _ManufacturersViewSource = new CollectionViewSource
                {
                    Source = _Manufacturers,
                };

                _ManufacturersViewSource.View.Refresh();

                OnPropertyChanged(nameof(ManufacturersView));
                OnPropertyChanged();
            }
        }


        private ObservableCollection<Group> _Groups;


        private CollectionViewSource _GroupsViewSource;

        public ICollectionView GroupsView => _GroupsViewSource?.View;

        public ObservableCollection<Group> Groups
        {
            get => _Groups;
            set
            {
                _Groups = value;

                _GroupsViewSource = new CollectionViewSource
                {
                    Source = _Groups,
                };

                _GroupsViewSource.View.Refresh();

                OnPropertyChanged(nameof(GroupsView));
                OnPropertyChanged();
            }
        }
        private ObservableCollection<Country> _Countries;


        private CollectionViewSource _CountriesViewSource;

        public ICollectionView CountriesView => _CountriesViewSource?.View;

        public ObservableCollection<Country> Countries
        {
            get => _Countries;
            set
            {
                _Countries = value;

                _CountriesViewSource = new CollectionViewSource
                {
                    Source = _Countries,
                };

                _CountriesViewSource.View.Refresh();

                OnPropertyChanged(nameof(CountriesView));
                OnPropertyChanged();
            }
        }

        private ObservableCollection<AccountingUnit> _AccountingUnits;


        private CollectionViewSource _AccountingUnitsViewSource;

        public ICollectionView AccountingUnitsView => _AccountingUnitsViewSource?.View;

        public ObservableCollection<AccountingUnit> AccountingUnits
        {
            get => _AccountingUnits;
            set
            {
                _AccountingUnits = value;

                _AccountingUnitsViewSource = new CollectionViewSource
                {
                    Source = _AccountingUnits,
                };

                _AccountingUnitsViewSource.View.Refresh();

                OnPropertyChanged(nameof(AccountingUnitsView));
                OnPropertyChanged();
            }
        }

        private async Task LoadAccountingUnits()
        {

            AccountingUnits = new ObservableCollection<AccountingUnit>(await _RepAccountingUnits.Items.ToArrayAsync());
            _AccountingUnitsViewSource.Source = AccountingUnits;
        }



        private async Task LoadCountries()
        {

            Countries = new ObservableCollection<Country>(await _RepCountries.Items.ToArrayAsync());
            _CountriesViewSource.Source = Countries;
        }



        private async Task LoadGroups()
        {

            Groups = new ObservableCollection<Group>(await _RepGroups.Items.ToArrayAsync());
            _GroupsViewSource.Source = Groups;
        }



        private async Task LoadManufacturers()
        {

            Manufacturers = new ObservableCollection<Manufacturer>(await _RepManufacturers.Items.ToArrayAsync());
            _ManufacturersViewSource.Source = Manufacturers;
        }



        private async Task LoadHeadPersons()
        {

            HeadPersons = new ObservableCollection<HeadPerson>(await _RepHeadPersons.Items.ToArrayAsync());
            _HeadPersonsViewSource.Source = HeadPersons;
        }





        private async Task LoadProducts()
        {

            Products = new ObservableCollection<Product>(await _RepProducts.Items.ToArrayAsync());
            _ProductsViewSource.Source = Products;
        }



        private async Task LoadSoldProducts()
        {

            SoldProducts = new ObservableCollection<SoldProduct>(await _RepSoldProducts.Items.ToArrayAsync());
            _SoldProductsViewSource.Source = SoldProducts;
        }



        private async Task LoadStores()
        {

            Stores = new ObservableCollection<Store>(await _RepStores.Items.ToArrayAsync());
            _StoresViewSource.Source = Stores;
        }



        private async Task LoadInvoices()
        {

            Invoices = new ObservableCollection<Invoice>(await _RepInvoices.Items.ToArrayAsync());
            _InvoicesViewSource.Source = Invoices;
        }


        private async Task LoadUsers()
        {

            Users = new ObservableCollection<User>(await _RepUsers.Items.ToArrayAsync());
            _UsersViewSource.Source = Users;
        }


        private async Task LoadBanks()
        {

            Banks = new ObservableCollection<Bank>(await _RepBanks.Items.ToArrayAsync());
            _BanksViewSource.Source = Banks;
        }

        private async Task LoadPartners()
        {

            Partners = new ObservableCollection<Partner>(await _RepPartners.Items.ToArrayAsync());
            _PartnersViewSource.Source = Partners;
        }

        private async Task LoadOrders()
        {

            Orders = new ObservableCollection<Order>(await _RepOrders.Items.ToArrayAsync());
            _OrdersViewSource.Source = Orders;
        }


        public ICollection<Structure> GetCatalogs(Structure currentstruct)
        {
            return _RepStructures.Items.Where(x => x.ParentStructure == currentstruct).ToList();
        }

        public List<Structure> PointsStruct
        {
            get
            {
                return _RepStructures.Items.ToList();
            }

        }


        public List<Structure> Structures
        {
            get
            {
                return _RepStructures.Items.Where(x => x.number != 0).OrderBy(x => x.number).ToList();
            }
        }


        public string Title { get; set; } = "Торгово-посредническая фирма";

        public MainViewModel(
            IRepository<Structure> structures,
            IRepository<User> users,
            IRepository<Right> rights,
            IRepository<SoldProduct> soldproducts,
            IRepository<Order> orders,
            IRepository<Store> stores,
            IRepository<Invoice> invoices,
            IRepository<Product> products,
            IRepository<AccountingUnit> accountingunits,
            IRepository<Group> groups,
            IRepository<Partner> partners,
            IRepository<Bank> banks,
            IRepository<Country> counties,
            IRepository<Manufacturer> manufacturers,
            IRepository<HeadPerson> headrepsons,
            IActionHandlerService userdialog
            )
        {
        _RepStructures = structures;
        _RepUsers = users;
        _RepRights = rights;
        _RepSoldProducts = soldproducts;
        _RepOrders = orders;
        _RepStores = stores;
        _RepInvoices = invoices;
        _RepProducts = products;
        _RepAccountingUnits = accountingunits;
        _RepGroups = groups;
        _RepPartners = partners;
        _RepBanks = banks;
        _RepCountries = counties;
        _RepHeadPersons = headrepsons;
        _RepManufacturers = manufacturers;
        _UserDialog = userdialog;
        }

        private ICommand _LoadDataCommand;
        public ICommand LoadDataCommand => _LoadDataCommand
            ??= new RelayCommand(OnLoadDataCommandExecuted, CanLoadDataCommandExecute);

        private bool CanLoadDataCommandExecute(object arg) => true;

        private async void OnLoadDataCommandExecuted(object obj)
        {

            LoadStructures();

            await LoadUsers();

            await LoadHeadPersons();

            await LoadManufacturers();

            await LoadSoldProducts();

            await LoadGroups();

            await LoadCountries();

            await LoadOrders();

            await LoadInvoices();

            await LoadProducts();

            await LoadStores();

            await LoadBanks();

            await LoadPartners();

            await LoadAccountingUnits();

            //_RepManufacturers.Add(new Manufacturer { Name = "Производитель умер" });

           // _RepStructures.Add(new Structure { Name = "Панель Администратора", function = "catalogUsers", number = 12});

            

            IsDataLoaded = true;
            RefTabOpen= true;
        }

        #region Меню структуры

        private void LoadStructures()
        {
            foreach (var item in Structures)
            {
                item.Catalogs = GetCatalogs(item).ToList();

            }

            List<Structure> Catalogs = new List<Structure>();

            Catalogs = PointsStruct.Where(x => x.number == 0 || x.Catalogs.Count() == 0).ToList();



            foreach (var item in Catalogs)
            {
                switch (item.function)
                {
                    case "catalogBanks":
                        item.Command = BanksTabVisibility;
                        break;
                    case "catalogPartners":
                        item.Command = PartnersTabVisibility;
                        break;
                    case "catalogOrders":
                        item.Command = OrdersTabVisibility;
                        break;
                    case "catalogInvoces":
                        item.Command = InvoicesTabVisibility;
                        break;
                    case "catalogStores":
                        item.Command = StoresTabVisibility;
                        break;
                    case "catalogSoldProducts":
                        item.Command = SoldProductsTabVisibility;
                        break;
                    case "catalogProducts":
                        item.Command = ProductsTabVisibility;
                        break;
                    case "catalogHeadPersons":
                        item.Command = HeadPersonsTabVisibility;
                        break;
                    case "catalogManufacturers":
                        item.Command = ManufacturersTabVisibility;
                        break;
                    case "catalogGroups":
                        item.Command = GroupsTabVisibility;
                        break;
                    case "catalogCountries":
                        item.Command = CountriesTabVisibility;
                        break;
                    case "catalogAccountingUnits":
                        item.Command = AccountingUnitsTabVisibility;
                        break;

                    case "catalogDocs":
                        item.Command = DocsTabVisibility;
                        break;
                    case "catalogChangePass":
                        item.Command = ChangePassTabVisibility;
                        break;
                    case "catalogRef":
                        item.Command = RefTabVisibility;
                        break;
                    case "catalogUsers":
                        item.Command = UsersTabVisibility;
                        break;

                        

                }
            }


        }


        private bool _AccountingUnitsTabOpen = false;

        public bool AccountingUnitsTabOpen
        {
            get { return _AccountingUnitsTabOpen; }
            set
            {
                _AccountingUnitsTabOpen = value;
                OnPropertyChanged(nameof(AccountingUnitsTabOpen));
            }
        }

        private bool _BanksTabOpen = false;

        public bool BanksTabOpen
        {
            get { return _BanksTabOpen; }
            set
            {
                _BanksTabOpen = value;
                OnPropertyChanged(nameof(BanksTabOpen));
            }
        }

        private bool _PartnersTabOpen = false;

        public bool PartnersTabOpen
        {
            get { return _PartnersTabOpen; }
            set
            {
                _PartnersTabOpen = value;
                OnPropertyChanged(nameof(PartnersTabOpen));
            }
        }

        private bool _OrdersTabOpen = false;

        public bool OrdersTabOpen
        {
            get { return _OrdersTabOpen; }
            set
            {
                _OrdersTabOpen = value;
                OnPropertyChanged(nameof(OrdersTabOpen));
            }
        }

        private bool _InvoicesTabOpen = false;

        public bool InvoicesTabOpen
        {
            get { return _InvoicesTabOpen; }
            set
            {
                _InvoicesTabOpen = value;
                OnPropertyChanged(nameof(InvoicesTabOpen));
            }
        }

        private bool _StoresTabOpen = false;

        public bool StoresTabOpen
        {
            get { return _StoresTabOpen; }
            set
            {
                _StoresTabOpen = value;
                OnPropertyChanged(nameof(StoresTabOpen));
            }
        }

        private bool _SoldProductsTabOpen = false;

        public bool SoldProductsTabOpen
        {
            get { return _SoldProductsTabOpen; }
            set
            {
                _SoldProductsTabOpen = value;
                OnPropertyChanged(nameof(SoldProductsTabOpen));
            }
        }

        private bool _ProductsTabOpen = false;

        public bool ProductsTabOpen
        {
            get { return _ProductsTabOpen; }
            set
            {
                _ProductsTabOpen = value;
                OnPropertyChanged(nameof(ProductsTabOpen));
            }
        }

        private bool _HeadPersonsTabOpen = false;

        public bool HeadPersonsTabOpen
        {
            get { return _HeadPersonsTabOpen; }
            set
            {
                _HeadPersonsTabOpen = value;
                OnPropertyChanged(nameof(HeadPersonsTabOpen));
            }
        }

        private bool _ManufacturersTabOpen = false;

        public bool ManufacturersTabOpen
        {
            get { return _ManufacturersTabOpen; }
            set
            {
                _ManufacturersTabOpen = value;
                OnPropertyChanged(nameof(ManufacturersTabOpen));
            }
        }

        private bool _GroupsTabOpen = false;

        public bool GroupsTabOpen
        {
            get { return _GroupsTabOpen; }
            set
            {
                _GroupsTabOpen = value;
                OnPropertyChanged(nameof(GroupsTabOpen));
            }
        }

        private bool _CountriesTabOpen = false;

        public bool CountriesTabOpen
        {
            get { return _CountriesTabOpen; }
            set
            {
                _CountriesTabOpen = value;
                OnPropertyChanged(nameof(CountriesTabOpen));
            }
        }

        private bool _DocsTabOpen = false;

        public bool DocsTabOpen
        {
            get { return _DocsTabOpen; }
            set
            {
                _DocsTabOpen = value;
                OnPropertyChanged(nameof(DocsTabOpen));
            }
        }

        private bool _ChangePassTabOpen = false;

        public bool ChangePassTabOpen
        {
            get { return _ChangePassTabOpen; }
            set
            {
                _ChangePassTabOpen = value;
                OnPropertyChanged(nameof(ChangePassTabOpen));
            }
        }

        private bool _RefTabOpen = false;

        public bool RefTabOpen
        {
            get { return _RefTabOpen; }
            set
            {
                _RefTabOpen = value;
                OnPropertyChanged(nameof(RefTabOpen));
            }
        }

        private bool _UsersTabOpen = false;

        public bool UsersTabOpen
        {
            get { return _UsersTabOpen; }
            set
            {
                _UsersTabOpen = value;
                OnPropertyChanged(nameof(UsersTabOpen));
            }
        }


        private ICommand? _UsersTabVisibility;
        public ICommand UsersTabVisibility => _UsersTabVisibility ??=
            new RelayCommand(OnUsersTabVisibilityCommandExecuted, CanUsersTabVisibilityCommandExecute);

        private bool CanUsersTabVisibilityCommandExecute(object arg) => true;
        private void OnUsersTabVisibilityCommandExecuted(object sender)
        {

            UsersTabOpen = true;

        }


        private ICommand? _BanksTabVisibility;
        public ICommand BanksTabVisibility => _BanksTabVisibility ??=
            new RelayCommand(OnBanksTabVisibilityCommandExecuted, CanBanksTabVisibilityCommandExecute);

        private bool CanBanksTabVisibilityCommandExecute(object arg) => true;
        private void OnBanksTabVisibilityCommandExecuted(object sender)
        {
            
            BanksTabOpen = true;

        }

        private ICommand _PartnersTabVisibility;
        public ICommand PartnersTabVisibility => _PartnersTabVisibility
           ??= new RelayCommand(OnPartnersTabVisibilityCommandExecuted, CanPartnersTabVisibilityCommandExecute);

        private bool CanPartnersTabVisibilityCommandExecute(object arg) => true;

        private void OnPartnersTabVisibilityCommandExecuted(object obj)
        {
            PartnersTabOpen = true;
        }

        private ICommand _OrdersTabVisibility;
        public ICommand OrdersTabVisibility => _OrdersTabVisibility
           ??= new RelayCommand(OnOrdersTabVisibilityCommandExecuted, CanOrdersTabVisibilityCommandExecute);

        private bool CanOrdersTabVisibilityCommandExecute(object arg) => true;

        private void OnOrdersTabVisibilityCommandExecuted(object obj)
        {
            OrdersTabOpen = true;
        }

        private bool _isEditingStore = true;

        private ICommand _InvoicesTabVisibility;
        public ICommand InvoicesTabVisibility => _InvoicesTabVisibility
           ??= new RelayCommand(OnInvoicesTabVisibilityCommandExecuted, CanInvoicesTabVisibilityCommandExecute);

        private bool CanInvoicesTabVisibilityCommandExecute(object arg) => _isEditingStore;

        private void OnInvoicesTabVisibilityCommandExecuted(object obj)
        {
            InvoicesTabOpen = true;
        }

        private ICommand _StoresTabVisibility;
        public ICommand StoresTabVisibility => _StoresTabVisibility
           ??= new RelayCommand(OnStoresTabVisibilityCommandExecuted, CanStoresTabVisibilityCommandExecute);

        private bool CanStoresTabVisibilityCommandExecute(object arg) => true;

        private void OnStoresTabVisibilityCommandExecuted(object obj)
        {
            StoresTabOpen = true;
        }
        

            private ICommand _SoldProductsTabVisibility;
        public ICommand SoldProductsTabVisibility => _SoldProductsTabVisibility
           ??= new RelayCommand(OnSoldProductsTabVisibilityCommandExecuted, CanSoldProductsTabVisibilityCommandExecute);

        private bool CanSoldProductsTabVisibilityCommandExecute(object arg) => true;

        private void OnSoldProductsTabVisibilityCommandExecuted(object obj)
        {
            SoldProductsTabOpen = true;
        }

        

            private ICommand _ProductsTabVisibility;
        public ICommand ProductsTabVisibility => _ProductsTabVisibility
           ??= new RelayCommand(OnProductsTabVisibilityCommandExecuted, CanProductsTabVisibilityCommandExecute);

        private bool CanProductsTabVisibilityCommandExecute(object arg) => true;

        private void OnProductsTabVisibilityCommandExecuted(object obj)
        {
            ProductsTabOpen = true;
        }

        

            private ICommand _HeadPersonsTabVisibility;
        public ICommand HeadPersonsTabVisibility => _HeadPersonsTabVisibility
           ??= new RelayCommand(OnHeadPersonsTabVisibilityCommandExecuted, CanHeadPersonsTabVisibilityCommandExecute);

        private bool CanHeadPersonsTabVisibilityCommandExecute(object arg) => true;

        private void OnHeadPersonsTabVisibilityCommandExecuted(object obj)
        {
            HeadPersonsTabOpen = true;
        }

        private ICommand _ManufacturersTabVisibility;
        public ICommand ManufacturersTabVisibility => _ManufacturersTabVisibility
           ??= new RelayCommand(OnManufacturersTabVisibilityCommandExecuted, CanManufacturersTabVisibilityCommandExecute);

        private bool CanManufacturersTabVisibilityCommandExecute(object arg) => true;

        private void OnManufacturersTabVisibilityCommandExecuted(object obj)
        {
            ManufacturersTabOpen = true;
        }

        private ICommand _GroupsTabVisibility;
        public ICommand GroupsTabVisibility => _GroupsTabVisibility
           ??= new RelayCommand(OnGroupsTabVisibilityCommandExecuted, CanGroupsTabVisibilityCommandExecute);

        private bool CanGroupsTabVisibilityCommandExecute(object arg) => true;

        private void OnGroupsTabVisibilityCommandExecuted(object obj)
        {
            GroupsTabOpen = true;
        }

        private ICommand _CountriesTabVisibility;
        public ICommand CountriesTabVisibility => _CountriesTabVisibility
           ??= new RelayCommand(OnCountriesTabVisibilityCommandExecuted, CanCountriesTabVisibilityCommandExecute);

        private bool CanCountriesTabVisibilityCommandExecute(object arg) => true;

        private void OnCountriesTabVisibilityCommandExecuted(object obj)
        {
            CountriesTabOpen = true;
        }

        


            private ICommand _DocsTabVisibility;
        public ICommand DocsTabVisibility => _DocsTabVisibility
           ??= new RelayCommand(OnDocsTabVisibilityCommandExecuted, CanDocsTabVisibilityCommandExecute);

        private bool CanDocsTabVisibilityCommandExecute(object arg) => true;

        private void OnDocsTabVisibilityCommandExecuted(object obj)
        {
            DocsTabOpen = true;
        }

        private ICommand _AccountingUnitsTabVisibility;
        public ICommand AccountingUnitsTabVisibility => _AccountingUnitsTabVisibility
           ??= new RelayCommand(OnAccountingUnitsTabVisibilityCommandExecuted, CanAccountingUnitsTabVisibilityCommandExecute);

        private bool CanAccountingUnitsTabVisibilityCommandExecute(object arg) => true;

        private void OnAccountingUnitsTabVisibilityCommandExecuted(object obj)
        {
            AccountingUnitsTabOpen = true;
        }

        private ICommand _ChangePassTabVisibility;
        public ICommand ChangePassTabVisibility => _ChangePassTabVisibility
           ??= new RelayCommand(OnChangePassTabVisibilityCommandExecuted, CanChangePassTabVisibilityCommandExecute);

        private bool CanChangePassTabVisibilityCommandExecute(object arg) => true;

        private void OnChangePassTabVisibilityCommandExecuted(object obj)
        {
            ChangePassTabOpen = true;
        }


        private ICommand _RefTabVisibility;
        public ICommand RefTabVisibility => _RefTabVisibility
           ??= new RelayCommand(OnRefTabVisibilityCommandExecuted, CanRefTabVisibilityCommandExecute);

        private bool CanRefTabVisibilityCommandExecute(object arg) => true;

        private void OnRefTabVisibilityCommandExecuted(object obj)
        {
            RefTabOpen = true;
        }
        #endregion

       

        private Order _SelectedOrder;

        public Order SelectedOrder
        {
            get { return _SelectedOrder; }
            set
            {
                _SelectedOrder = value;
                OnPropertyChanged(nameof(SelectedOrder));
            }
        }


        private ICommand _AddNewOrder;

        public ICommand AddNewOrder => _AddNewOrder
           ??= new RelayCommand(OnAddNewOrderCommandExecuted, CanAddNewOrderCommandExecute);

        private bool CanAddNewOrderCommandExecute(object arg) => true;

        private void OnAddNewOrderCommandExecuted(object obj)
        {
            var new_order = new Order();

            if (!_UserDialog.Add(new_order))
                return;

            Orders.Add(_RepOrders.Add(new_order));

            SelectedOrder = new_order;
        }

        private ICommand _EditOrder;

        public ICommand EditOrder => _EditOrder
           ??= new RelayCommand(OnEditOrderCommandExecuted, CanEditOrderCommandExecute);

        private bool CanEditOrderCommandExecute(object arg) => SelectedOrder != null;

        private void OnEditOrderCommandExecuted(object obj)
        {
            var new_order = SelectedOrder;

            if (!_UserDialog.Edit(new_order))
                return;

            Orders.Remove(SelectedOrder);

            Orders.Add(new_order);

            _RepOrders.Update(new_order);

            //LoadCargos();

            SelectedOrder = new_order;

        }

        private ICommand _DeleteOrder;

        public ICommand DeleteOrder => _DeleteOrder
            ??= new RelayCommand(OnDeleteOrderCommandExecuted, CanDeleteOrderCommandExecute);

        private bool CanDeleteOrderCommandExecute(object arg) => SelectedOrder != null;

        private void OnDeleteOrderCommandExecuted(object obj)
        {
            var order_to_remove = SelectedOrder;

            if (!_UserDialog.ConfirmWarning($"Вы хотите удалить заказ номер {order_to_remove.Id}?", "Удаление заказа"))
                return;

            _RepOrders.Remove(order_to_remove.Id);

            Orders.Remove(order_to_remove);
            if (ReferenceEquals(SelectedOrder, order_to_remove))
                SelectedOrder = null;

            //LoadCargos();

        }

        private Bank _SelectedBank;

        public Bank SelectedBank
        {
            get { return _SelectedBank; }
            set
            {
                _SelectedBank = value;
                OnPropertyChanged(nameof(SelectedBank));
            }
        }


        private ICommand _AddNewBank;

        public ICommand AddNewBank => _AddNewBank
           ??= new RelayCommand(OnAddNewBankCommandExecuted, CanAddNewBankCommandExecute);

        private bool CanAddNewBankCommandExecute(object arg) => true;

        private void OnAddNewBankCommandExecuted(object obj)
        {
            var new_order = new Bank();

            if (!_UserDialog.Add(new_order))
                return;

            Banks.Add(_RepBanks.Add(new_order));

            SelectedBank = new_order;
        }

        private ICommand _EditBank;

        public ICommand EditBank => _EditBank
           ??= new RelayCommand(OnEditBankCommandExecuted, CanEditBankCommandExecute);

        private bool CanEditBankCommandExecute(object arg) => SelectedBank != null;

        private void OnEditBankCommandExecuted(object obj)
        {
            var new_order = SelectedBank;

            if (!_UserDialog.Edit(new_order))
                return;

            Banks.Remove(SelectedBank);

            Banks.Add(new_order);

            _RepBanks.Update(new_order);

            PartnersView.Refresh();

            SelectedBank = new_order;

        }

        private ICommand _DeleteBank;

        public ICommand DeleteBank => _DeleteBank
            ??= new RelayCommand(OnDeleteBankCommandExecuted, CanDeleteBankCommandExecute);

        private bool CanDeleteBankCommandExecute(object arg) => SelectedBank != null;

        private void OnDeleteBankCommandExecuted(object obj)
        {
            var order_to_remove = SelectedBank;

            if (!_UserDialog.ConfirmWarning($"Вы хотите удалить банк {order_to_remove.ToString()}?", "Удаление банка"))
                return;

            _RepBanks.Remove(order_to_remove.Id);

            Banks.Remove(order_to_remove);
            if (ReferenceEquals(SelectedBank, order_to_remove))
                SelectedBank = null;

            PartnersView.Refresh();

        }


        private Manufacturer _SelectedManufacturer;

        public Manufacturer SelectedManufacturer
        {
            get { return _SelectedManufacturer; }
            set
            {
                _SelectedManufacturer = value;
                OnPropertyChanged(nameof(SelectedManufacturer));
            }
        }


        private ICommand _AddNewManufacturer;

        public ICommand AddNewManufacturer => _AddNewManufacturer
           ??= new RelayCommand(OnAddNewManufacturerCommandExecuted, CanAddNewManufacturerCommandExecute);

        private bool CanAddNewManufacturerCommandExecute(object arg) => true;

        private void OnAddNewManufacturerCommandExecuted(object obj)
        {
            var new_manufacturer = new Manufacturer();

            if (!_UserDialog.Add(new_manufacturer))
                return;

            Manufacturers.Add(_RepManufacturers.Add(new_manufacturer));

            SelectedManufacturer = new_manufacturer;
        }

        private ICommand _EditManufacturer;

        public ICommand EditManufacturer => _EditManufacturer
           ??= new RelayCommand(OnEditManufacturerCommandExecuted, CanEditManufacturerCommandExecute);

        private bool CanEditManufacturerCommandExecute(object arg) => SelectedManufacturer != null;

        private void OnEditManufacturerCommandExecuted(object obj)
        {
            var new_manufacturer = SelectedManufacturer;

            if (!_UserDialog.Edit(new_manufacturer))
                return;

            Manufacturers.Remove(SelectedManufacturer);

            Manufacturers.Add(new_manufacturer);

            _RepManufacturers.Update(new_manufacturer);

            ProductsView.Refresh();

            SelectedManufacturer = new_manufacturer;

        }

        private ICommand _DeleteManufacturer;

        public ICommand DeleteManufacturer => _DeleteManufacturer
            ??= new RelayCommand(OnDeleteManufacturerCommandExecuted, CanDeleteManufacturerCommandExecute);

        private bool CanDeleteManufacturerCommandExecute(object arg) => SelectedManufacturer != null;

        private void OnDeleteManufacturerCommandExecuted(object obj)
        {
            var manufacturer_to_remove = SelectedManufacturer;

            if (!_UserDialog.ConfirmWarning($"Вы хотите удалить производителя {manufacturer_to_remove.Name}?", "Удаление производителя"))
                return;

            _RepManufacturers.Remove(manufacturer_to_remove.Id);

            Manufacturers.Remove(manufacturer_to_remove);
            if (ReferenceEquals(SelectedManufacturer, manufacturer_to_remove))
                SelectedManufacturer = null;

            ProductsView.Refresh();

        }

        private Group _SelectedGroup;

        public Group SelectedGroup
        {
            get { return _SelectedGroup; }
            set
            {
                _SelectedGroup = value;
                OnPropertyChanged(nameof(SelectedGroup));
            }
        }


        private ICommand _AddNewGroup;

        public ICommand AddNewGroup => _AddNewGroup
           ??= new RelayCommand(OnAddNewGroupCommandExecuted, CanAddNewGroupCommandExecute);

        private bool CanAddNewGroupCommandExecute(object arg) => true;

        private void OnAddNewGroupCommandExecuted(object obj)
        {
            var new_group = new Group();

            if (!_UserDialog.Add(new_group))
                return;

            Groups.Add(_RepGroups.Add(new_group));

            SelectedGroup = new_group;
        }

        private ICommand _EditGroup;

        public ICommand EditGroup => _EditGroup
           ??= new RelayCommand(OnEditGroupCommandExecuted, CanEditGroupCommandExecute);

        private bool CanEditGroupCommandExecute(object arg) => SelectedGroup != null;

        private void OnEditGroupCommandExecuted(object obj)
        {
            var new_group = SelectedGroup;

            if (!_UserDialog.Edit(new_group))
                return;

            Groups.Remove(SelectedGroup);

            Groups.Add(new_group);

            _RepGroups.Update(new_group);

            ProductsView.Refresh();

            SelectedGroup = new_group;

        }

        private ICommand _DeleteGroup;

        public ICommand DeleteGroup => _DeleteGroup
            ??= new RelayCommand(OnDeleteGroupCommandExecuted, CanDeleteGroupCommandExecute);

        private bool CanDeleteGroupCommandExecute(object arg) => SelectedGroup != null;

        private void OnDeleteGroupCommandExecuted(object obj)
        {
            var group_to_remove = SelectedGroup;

            if (!_UserDialog.ConfirmWarning($"Вы хотите удалить группу {group_to_remove.Name}?", "Удаление группы"))
                return;

            _RepGroups.Remove(group_to_remove.Id);

            Groups.Remove(group_to_remove);
            if (ReferenceEquals(SelectedGroup, group_to_remove))
                SelectedGroup = null;

            ProductsView.Refresh();

        }


        private Country _SelectedCountry;

        public Country SelectedCountry
        {
            get { return _SelectedCountry; }
            set
            {
                _SelectedCountry = value;
                OnPropertyChanged(nameof(SelectedCountry));
            }
        }


        private ICommand _AddNewCountry;

        public ICommand AddNewCountry => _AddNewCountry
           ??= new RelayCommand(OnAddNewCountryCommandExecuted, CanAddNewCountryCommandExecute);

        private bool CanAddNewCountryCommandExecute(object arg) => true;

        private void OnAddNewCountryCommandExecuted(object obj)
        {
            var new_country = new Country();

            if (!_UserDialog.Add(new_country))
                return;

            Countries.Add(_RepCountries.Add(new_country));

            SelectedCountry = new_country;
        }

        private ICommand _EditCountry;

        public ICommand EditCountry => _EditCountry
           ??= new RelayCommand(OnEditCountryCommandExecuted, CanEditCountryCommandExecute);

        private bool CanEditCountryCommandExecute(object arg) => SelectedCountry != null;

        private void OnEditCountryCommandExecuted(object obj)
        {
            var new_country = SelectedCountry;

            if (!_UserDialog.Edit(new_country))
                return;

            Countries.Remove(SelectedCountry);

            Countries.Add(new_country);

            _RepCountries.Update(new_country);

            PartnersView.Refresh();

            SelectedCountry = new_country;

        }

        private ICommand _DeleteCountry;

        public ICommand DeleteCountry => _DeleteCountry
            ??= new RelayCommand(OnDeleteCountryCommandExecuted, CanDeleteCountryCommandExecute);

        private bool CanDeleteCountryCommandExecute(object arg) => SelectedCountry != null;

        private void OnDeleteCountryCommandExecuted(object obj)
        {
            var country_to_remove = SelectedCountry;

            if (!_UserDialog.ConfirmWarning($"Вы хотите удалить страну {country_to_remove.Name}?", "Удаление страны"))
                return;

            _RepCountries.Remove(country_to_remove.Id);

            Countries.Remove(country_to_remove);
            if (ReferenceEquals(SelectedCountry, country_to_remove))
                SelectedCountry = null;

             PartnersView.Refresh();

        }


        private AccountingUnit _SelectedAccountingUnit;

        public AccountingUnit SelectedAccountingUnit
        {
            get { return _SelectedAccountingUnit; }
            set
            {
                _SelectedAccountingUnit = value;
                OnPropertyChanged(nameof(SelectedAccountingUnit));
            }
        }


        private ICommand _AddNewAccountingUnit;

        public ICommand AddNewAccountingUnit => _AddNewAccountingUnit
           ??= new RelayCommand(OnAddNewAccountingUnitCommandExecuted, CanAddNewAccountingUnitCommandExecute);

        private bool CanAddNewAccountingUnitCommandExecute(object arg) => true;

        private void OnAddNewAccountingUnitCommandExecuted(object obj)
        {
            var new_accountingunits = new AccountingUnit();

            if (!_UserDialog.Add(new_accountingunits))
                return;

            AccountingUnits.Add(_RepAccountingUnits.Add(new_accountingunits));

            SelectedAccountingUnit = new_accountingunits;
        }

        private ICommand _EditAccountingUnit;

        public ICommand EditAccountingUnit => _EditAccountingUnit
           ??= new RelayCommand(OnEditAccountingUnitCommandExecuted, CanEditAccountingUnitCommandExecute);

        private bool CanEditAccountingUnitCommandExecute(object arg) => SelectedAccountingUnit != null;

        private void OnEditAccountingUnitCommandExecuted(object obj)
        {
            var new_accountingunits = SelectedAccountingUnit;

            if (!_UserDialog.Edit(new_accountingunits))
                return;

            AccountingUnits.Remove(SelectedAccountingUnit);

            AccountingUnits.Add(new_accountingunits);

            _RepAccountingUnits.Update(new_accountingunits);

            ProductsView.Refresh();

            SelectedAccountingUnit = new_accountingunits;

        }

        private ICommand _DeleteAccountingUnit;

        public ICommand DeleteAccountingUnit => _DeleteAccountingUnit
            ??= new RelayCommand(OnDeleteAccountingUnitCommandExecuted, CanDeleteAccountingUnitCommandExecute);

        private bool CanDeleteAccountingUnitCommandExecute(object arg) => SelectedAccountingUnit != null;

        private void OnDeleteAccountingUnitCommandExecuted(object obj)
        {
            var accountingunits_to_remove = SelectedAccountingUnit;

            if (!_UserDialog.ConfirmWarning($"Вы хотите удалить единицу измерения {accountingunits_to_remove.Name}?", "Удаление единицы измерения"))
                return;

            _RepAccountingUnits.Remove(accountingunits_to_remove.Id);

            AccountingUnits.Remove(accountingunits_to_remove);
            if (ReferenceEquals(SelectedAccountingUnit, accountingunits_to_remove))
                SelectedAccountingUnit = null;

            ProductsView.Refresh();

        }

        private HeadPerson _SelectedHeadPerson;

        public HeadPerson SelectedHeadPerson
        {
            get { return _SelectedHeadPerson; }
            set
            {
                _SelectedHeadPerson = value;
                OnPropertyChanged(nameof(SelectedHeadPerson));
            }
        }


        private ICommand _AddNewHeadPerson;

        public ICommand AddNewHeadPerson => _AddNewHeadPerson
           ??= new RelayCommand(OnAddNewHeadPersonCommandExecuted, CanAddNewHeadPersonCommandExecute);

        private bool CanAddNewHeadPersonCommandExecute(object arg) => true;

        private void OnAddNewHeadPersonCommandExecuted(object obj)
        {
            var new_headperson = new HeadPerson();

            if (!_UserDialog.Add(new_headperson))
                return;

            HeadPersons.Add(_RepHeadPersons.Add(new_headperson));

            SelectedHeadPerson = new_headperson;
        }

        private ICommand _EditHeadPerson;

        public ICommand EditHeadPerson => _EditHeadPerson
           ??= new RelayCommand(OnEditHeadPersonCommandExecuted, CanEditHeadPersonCommandExecute);

        private bool CanEditHeadPersonCommandExecute(object arg) => SelectedHeadPerson != null;

        private void OnEditHeadPersonCommandExecuted(object obj)
        {
            var new_headperson = SelectedHeadPerson;

            if (!_UserDialog.Edit(new_headperson))
                return;

            HeadPersons.Remove(SelectedHeadPerson);

            HeadPersons.Add(new_headperson);

            _RepHeadPersons.Update(new_headperson);

            PartnersView.Refresh();

            SelectedHeadPerson = new_headperson;

        }

        private ICommand _DeleteHeadPerson;

        public ICommand DeleteHeadPerson => _DeleteHeadPerson
            ??= new RelayCommand(OnDeleteHeadPersonCommandExecuted, CanDeleteHeadPersonCommandExecute);

        private bool CanDeleteHeadPersonCommandExecute(object arg) => SelectedHeadPerson != null;

        private void OnDeleteHeadPersonCommandExecuted(object obj)
        {
            var headperson_to_remove = SelectedHeadPerson;

            if (!_UserDialog.ConfirmWarning($"Вы хотите удалить руководителя {headperson_to_remove.ToString()}?", "Удаление руководителя"))
                return;

            _RepHeadPersons.Remove(headperson_to_remove.Id);

            HeadPersons.Remove(headperson_to_remove);
            if (ReferenceEquals(SelectedHeadPerson, headperson_to_remove))
                SelectedHeadPerson = null;

              PartnersView.Refresh();

        }

        private Product _SelectedProduct;

        public Product SelectedProduct
        {
            get { return _SelectedProduct; }
            set
            {
                _SelectedProduct = value;
                OnPropertyChanged(nameof(SelectedProduct));
            }
        }


        private ICommand _AddNewProduct;

        public ICommand AddNewProduct => _AddNewProduct
           ??= new RelayCommand(OnAddNewProductCommandExecuted, CanAddNewProductCommandExecute);

        private bool CanAddNewProductCommandExecute(object arg) => true;

        private void OnAddNewProductCommandExecuted(object obj)
        {
            var new_product = new Product();

            if (!_UserDialog.Add(new_product))
                return;

            Products.Add(_RepProducts.Add(new_product));

            SelectedProduct = new_product;
        }

        private ICommand _EditProduct;

        public ICommand EditProduct => _EditProduct
           ??= new RelayCommand(OnEditProductCommandExecuted, CanEditProductCommandExecute);

        private bool CanEditProductCommandExecute(object arg) => SelectedProduct != null;

        private void OnEditProductCommandExecuted(object obj)
        {
            var new_product = SelectedProduct;

            if (!_UserDialog.Edit(new_product))
                return;

            Products.Remove(SelectedProduct);

            Products.Add(new_product);

            _RepProducts.Update(new_product);

            StoresView.Refresh();

            SelectedProduct = new_product;

        }

        private ICommand _DeleteProduct;

        public ICommand DeleteProduct => _DeleteProduct
            ??= new RelayCommand(OnDeleteProductCommandExecuted, CanDeleteProductCommandExecute);

        private bool CanDeleteProductCommandExecute(object arg) => SelectedProduct != null;

        private void OnDeleteProductCommandExecuted(object obj)
        {
            var product_to_remove = SelectedProduct;

            if (!_UserDialog.ConfirmWarning($"Вы хотите удалить Продукт {product_to_remove.Name}?", "Удаление продукта"))
                return;

            _RepProducts.Remove(product_to_remove.Id);

            Products.Remove(product_to_remove);
            if (ReferenceEquals(SelectedProduct, product_to_remove))
                SelectedProduct = null;

            StoresView.Refresh();

           // ProductsView.Refresh();

        }

        private Partner _SelectedPartner;

        public Partner SelectedPartner
        {
            get { return _SelectedPartner; }
            set
            {
                _SelectedPartner = value;
                OnPropertyChanged(nameof(SelectedPartner));
            }
        }


        private ICommand _AddNewPartner;

        public ICommand AddNewPartner => _AddNewPartner
           ??= new RelayCommand(OnAddNewPartnerCommandExecuted, CanAddNewPartnerCommandExecute);

        private bool CanAddNewPartnerCommandExecute(object arg) => true;

        private void OnAddNewPartnerCommandExecuted(object obj)
        {
            var new_partner = new Partner();

            if (!_UserDialog.Add(new_partner))
                return;

            Partners.Add(_RepPartners.Add(new_partner));

            SelectedPartner = new_partner;
        }

        private ICommand _EditPartner;

        public ICommand EditPartner => _EditPartner
           ??= new RelayCommand(OnEditPartnerCommandExecuted, CanEditPartnerCommandExecute);

        private bool CanEditPartnerCommandExecute(object arg) => SelectedPartner != null;

        private void OnEditPartnerCommandExecuted(object obj)
        {
            var new_partner = SelectedPartner;

            if (!_UserDialog.Edit(new_partner))
                return;

            Partners.Remove(SelectedPartner);

            Partners.Add(new_partner);

            _RepPartners.Update(new_partner);

            OrdersView.Refresh();

            InvoicesView.Refresh();

            SelectedPartner = new_partner;

        }

        private ICommand _DeletePartner;

        public ICommand DeletePartner => _DeletePartner
            ??= new RelayCommand(OnDeletePartnerCommandExecuted, CanDeletePartnerCommandExecute);

        private bool CanDeletePartnerCommandExecute(object arg) => SelectedPartner != null;

        private void OnDeletePartnerCommandExecuted(object obj)
        {
            var partner_to_remove = SelectedPartner;

            if (!_UserDialog.ConfirmWarning($"Вы хотите удалить контрагента {partner_to_remove.Name}?", "Удаление контрагента"))
                return;

            _RepPartners.Remove(partner_to_remove.Id);

            Partners.Remove(partner_to_remove);
            if (ReferenceEquals(SelectedPartner, partner_to_remove))
                SelectedPartner = null;

            OrdersView.Refresh();

            InvoicesView.Refresh();

            // PartnersView.Refresh();

        }

        private Invoice _SelectedInvoice;

        public Invoice SelectedInvoice
        {
            get { return _SelectedInvoice; }
            set
            {
                _SelectedInvoice = value;
                OnPropertyChanged(nameof(SelectedInvoice));
            }
        }


        private ICommand _AddNewInvoice;

        public ICommand AddNewInvoice => _AddNewInvoice
           ??= new RelayCommand(OnAddNewInvoiceCommandExecuted, CanAddNewInvoiceCommandExecute);

        private bool CanAddNewInvoiceCommandExecute(object arg) => true;

        private void OnAddNewInvoiceCommandExecuted(object obj)
        {
            var new_invoice = new Invoice();

            if (!_UserDialog.Add(new_invoice))
                return;

            Invoices.Add(_RepInvoices.Add(new_invoice));

            SelectedInvoice = new_invoice;
        }

        private ICommand _EditInvoice;

        public ICommand EditInvoice => _EditInvoice
           ??= new RelayCommand(OnEditInvoiceCommandExecuted, CanEditInvoiceCommandExecute);

        private bool CanEditInvoiceCommandExecute(object arg) => SelectedInvoice != null;

        private void OnEditInvoiceCommandExecuted(object obj)
        {
            var new_invoice = SelectedInvoice;

            if (!_UserDialog.Edit(new_invoice))
                return;

            Invoices.Remove(SelectedInvoice);

            Invoices.Add(new_invoice);

            _RepInvoices.Update(new_invoice);

            StoresView.Refresh();

            //InvoicesView.Refresh();

            SelectedInvoice = new_invoice;

        }

        private ICommand _DeleteInvoice;

        public ICommand DeleteInvoice => _DeleteInvoice
            ??= new RelayCommand(OnDeleteInvoiceCommandExecuted, CanDeleteInvoiceCommandExecute);

        private bool CanDeleteInvoiceCommandExecute(object arg) => SelectedInvoice != null;

        private void OnDeleteInvoiceCommandExecuted(object obj)
        {
            var invoice_to_remove = SelectedInvoice;

            if (!_UserDialog.ConfirmWarning($"Вы хотите удалить накладную {invoice_to_remove.Id}?", "Удаление накладной"))
                return;

            _RepInvoices.Remove(invoice_to_remove.Id);

            Invoices.Remove(invoice_to_remove);
            if (ReferenceEquals(SelectedInvoice, invoice_to_remove))
                SelectedInvoice = null;


            StoresView.Refresh();
            // InvoicesView.Refresh();

        }

        private Store _SelectedStore;

        public Store SelectedStore
        {
            get { return _SelectedStore; }
            set
            {
                _SelectedStore = value;
                OnPropertyChanged(nameof(SelectedStore));
            }
        }


        private ICommand _AddNewStore;

        public ICommand AddNewStore => _AddNewStore
           ??= new RelayCommand(OnAddNewStoreCommandExecuted, CanAddNewStoreCommandExecute);

        private bool CanAddNewStoreCommandExecute(object arg) => true;

        private void OnAddNewStoreCommandExecuted(object obj)
        {
            var new_store = new Store();

            if (!_UserDialog.Add(new_store))
                return;

            Stores.Add(_RepStores.Add(new_store));

            InvoicesView.Refresh();

            SelectedStore = new_store;
        }


      

        private ICommand _EditStore;

        public ICommand EditStore => _EditStore
           ??= new AsyncRelayCommand(OnEditStoreCommandExecuted, CanEditStoreCommandExecute);

        private bool CanEditStoreCommandExecute(object arg) => SelectedStore != null;

        private async Task OnEditStoreCommandExecuted(object obj)
        {
            var new_store = SelectedStore;

            //private bool CanInvoicesTabVisibilityCommandExecute(object arg) => true;

            _isEditingStore = false;

            if (!_UserDialog.Edit(new_store))
                return;

            Stores.Remove(SelectedStore);

            Stores.Add(new_store);

            _RepStores.Update(new_store);

            InvoicesView.Refresh();
            

            _isEditingStore = true;
            SelectedStore = new_store;

        }

        private ICommand _DeleteStore;

        public ICommand DeleteStore => _DeleteStore
            ??= new RelayCommand(OnDeleteStoreCommandExecuted, CanDeleteStoreCommandExecute);

        private bool CanDeleteStoreCommandExecute(object arg) => SelectedStore != null;

        private void OnDeleteStoreCommandExecuted(object obj)
        {
            var store_to_remove = SelectedStore;

            if (!_UserDialog.ConfirmWarning($"Вы хотите удалить резерв {store_to_remove.Id}?", "Удаление резерва"))
                return;

            _RepStores.Remove(store_to_remove.Id);

            Stores.Remove(store_to_remove);
            if (ReferenceEquals(SelectedStore, store_to_remove))
                SelectedStore = null;

           
            InvoicesView.Refresh();


        }


        private SoldProduct _SelectedSoldProduct;

        public SoldProduct SelectedSoldProduct
        {
            get { return _SelectedSoldProduct; }
            set
            {
                _SelectedSoldProduct = value;
                OnPropertyChanged(nameof(SelectedSoldProduct));
            }
        }


        private ICommand _AddNewSoldProduct;

        public ICommand AddNewSoldProduct => _AddNewSoldProduct
           ??= new RelayCommand(OnAddNewSoldProductCommandExecuted, CanAddNewSoldProductCommandExecute);

        private bool CanAddNewSoldProductCommandExecute(object arg) => true;

        private void OnAddNewSoldProductCommandExecuted(object obj)
        {
            var new_soldproduct = new SoldProduct();

            if (!_UserDialog.Add(new_soldproduct))
                return;

            SoldProducts.Add(_RepSoldProducts.Add(new_soldproduct));

            LoadSoldProducts();

            OrdersView.Refresh();

            StoresView.Refresh();

            SelectedSoldProduct = new_soldproduct;
        }

        private ICommand _EditSoldProduct;

        public ICommand EditSoldProduct => _EditSoldProduct
           ??= new RelayCommand(OnEditSoldProductCommandExecuted, CanEditSoldProductCommandExecute);

        private bool CanEditSoldProductCommandExecute(object arg) => SelectedSoldProduct != null;

        private void OnEditSoldProductCommandExecuted(object obj)
        {
            var new_soldproduct = SelectedSoldProduct;

            if (!_UserDialog.Edit(new_soldproduct))
                return;

            SoldProducts.Remove(SelectedSoldProduct);

            SoldProducts.Add(new_soldproduct);

            _RepSoldProducts.Update(new_soldproduct);

            OrdersView.Refresh();

            StoresView.Refresh();

            SelectedSoldProduct = new_soldproduct;

        }

        private ICommand _DeleteSoldProduct;

        public ICommand DeleteSoldProduct => _DeleteSoldProduct
            ??= new RelayCommand(OnDeleteSoldProductCommandExecuted, CanDeleteSoldProductCommandExecute);

        private bool CanDeleteSoldProductCommandExecute(object arg) => SelectedSoldProduct != null;

        private void OnDeleteSoldProductCommandExecuted(object obj)
        {
            var soldproduct_to_remove = SelectedSoldProduct;

            if (!_UserDialog.ConfirmWarning($"Вы хотите удалить заказ номер {soldproduct_to_remove.Id}?", "Удаление заказа"))
                return;

            _RepSoldProducts.Remove(soldproduct_to_remove.Id);

            SoldProducts.Remove(soldproduct_to_remove);
            if (ReferenceEquals(SelectedSoldProduct, soldproduct_to_remove))
                SelectedSoldProduct = null;

            OrdersView.Refresh();

            StoresView.Refresh();

            //LoadCargos();

        }


        private User _SelectedUser;

        public User SelectedUser
        {
            get { return _SelectedUser; }
            set
            {
                _SelectedUser = value;
                OnPropertyChanged(nameof(SelectedUser));
            }
        }


        private ICommand _AddNewUser;

        public ICommand AddNewUser => _AddNewUser
           ??= new RelayCommand(OnAddNewUserCommandExecuted, CanAddNewUserCommandExecute);

        private bool CanAddNewUserCommandExecute(object arg) => true;

        private void OnAddNewUserCommandExecuted(object obj)
        {
            var new_user = new User();

            if (!_UserDialog.Add(new_user))
                return;

            Users.Add(_RepUsers.Add(new_user));

            SelectedUser = new_user;
        }

        private ICommand _EditUser;

        public ICommand EditUser => _EditUser
           ??= new RelayCommand(OnEditUserCommandExecuted, CanEditUserCommandExecute);

        private bool CanEditUserCommandExecute(object arg) => SelectedUser != null;

        private void OnEditUserCommandExecuted(object obj)
        {
            var new_user = SelectedUser;

            if (!_UserDialog.Edit(new_user))
                return;

            Users.Remove(SelectedUser);

            Users.Add(new_user);

            _RepUsers.Update(new_user);

            //LoadCargos();

            SelectedUser = new_user;

        }

        private ICommand _DeleteUser;

        public ICommand DeleteUser => _DeleteUser
            ??= new RelayCommand(OnDeleteUserCommandExecuted, CanDeleteUserCommandExecute);

        private bool CanDeleteUserCommandExecute(object arg) => SelectedUser != null;

        private void OnDeleteUserCommandExecuted(object obj)
        {
            var user_to_remove = SelectedUser;

            if (!_UserDialog.ConfirmWarning($"Вы хотите удалить пользователя {user_to_remove.Name}?", "Удаление пользователя"))
                return;
            if (user_to_remove.Name == "Admin")
            {
                MessageBox.Show("Пользователь Admin нельзя удалять");
                return;
            }
            _RepUsers.Remove(user_to_remove.Id);

            Users.Remove(user_to_remove);
            if (ReferenceEquals(SelectedUser, user_to_remove))
                SelectedUser = null;

            //LoadCargos();

        }








        public string SearchTextPartner { get; set; }

        private ICommand _SearchPartner;

        public ICommand SearchPartner => _SearchPartner
           ??= new RelayCommand(OnSearchPartnerCommandExecuted, CanSearchPartnerCommandExecute);

        private bool CanSearchPartnerCommandExecute(object arg) => true;

        private void OnSearchPartnerCommandExecuted(object obj)
        {

            if (PartnersView != null)
            {
                if (string.IsNullOrWhiteSpace(SearchTextPartner))
                {
                    PartnersView.Filter = null; // Очищаем фильтр
                }
                else
                {
                    PartnersView.Filter = o =>
                    {
                        if (o is Partner partner)
                        {
                            return (partner.Id != null && partner.Id.ToString().Contains(SearchTextPartner)) ||
                                   (!string.IsNullOrEmpty(partner.Name) && partner.Name.Contains(SearchTextPartner)) ||
                                   (!string.IsNullOrEmpty(partner.LegalAddress) && partner.LegalAddress.Contains(SearchTextPartner)) ||
                                   (partner.HeadPerson != null && partner.HeadPerson.ToString().Contains(SearchTextPartner)) ||
                                   (!string.IsNullOrEmpty(partner.Inn) && partner.Inn.Contains(SearchTextPartner)) ||
                                   (!string.IsNullOrEmpty(partner.BankAccount) && partner.BankAccount.Contains(SearchTextPartner)) ||
                                   (partner.Country != null && partner.Country.ToString().Contains(SearchTextPartner));
                        }
                        return false;
                    };
                }
            }
        }


        #region Экпорт Word


        private string _FileName;

        public string FileName
        {
            get { return _FileName; }
            set
            {
                _FileName = value;
                OnPropertyChanged(nameof(FileName));
            }
        }

        private ICommand _WordExport;

        public ICommand WordExport => _WordExport
           ??= new RelayCommand(OnWordExportCommandExecuted, CanWordExportCommandExecute);

        private bool CanWordExportCommandExecute(object arg) => true;

        private void OnWordExportCommandExecuted(object obj)
        {
            if (FileName == null) { MessageBox.Show("Пустое название файла", "Ошибка"); return; }
            if (!_UserDialog.ConfirmWarning("Точно хотите экспортировать базу данных?", "Экпорт")) { return; }

            string fileName = FileName;
            string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads", fileName);


            Microsoft.Office.Interop.Word.Document wordApp = new Microsoft.Office.Interop.Word.Document();
            if (wordApp == null)
            {
                MessageBox.Show("Word установлен неправильно!!");
                return;
            }

            object start = 0, end = 0;

            Microsoft.Office.Interop.Word.Range rng = wordApp.Range(ref start, ref end);

            rng.InsertBefore("Таблица Контрагентов");
            rng.Font.Name = "Verdana";
            rng.Font.Size = 16;
            rng.InsertParagraphAfter();
            rng.InsertParagraphAfter();
            rng.SetRange(rng.End, rng.End);

            object missing = System.Reflection.Missing.Value;

            // Add the table.
            rng.Tables.Add(wordApp.Paragraphs[2].Range, _RepPartners.Items.Count() + 1, 9, ref missing, ref missing);


            Microsoft.Office.Interop.Word.Table tblCargo = wordApp.Tables[1];
            tblCargo.Range.Font.Size = 12;
            tblCargo.Columns.DistributeWidth();



            tblCargo.Cell(1, 1).Range.Text = "Название фирмы";
            tblCargo.Cell(1, 2).Range.Text = "Страна";
            tblCargo.Cell(1, 3).Range.Text = "Руководитель";
            tblCargo.Cell(1, 4).Range.Text = "Юридический адрес";
            tblCargo.Cell(1, 5).Range.Text = "Номер телефона";
            tblCargo.Cell(1, 6).Range.Text = "Email";
            tblCargo.Cell(1, 7).Range.Text = "Банк";
            tblCargo.Cell(1, 8).Range.Text = "Номер счёта";
            tblCargo.Cell(1, 9).Range.Text = "ИНН";

            int row = 2;

            foreach (var item in _RepPartners.Items)
            {
                tblCargo.Cell(row, 1).Range.Text = item.Name;
                tblCargo.Cell(row, 2).Range.Text = item.Country.ToString();
                tblCargo.Cell(row, 3).Range.Text = item.HeadPerson.ToString();
                tblCargo.Cell(row, 4).Range.Text = item.LegalAddress.ToString();
                tblCargo.Cell(row, 5).Range.Text = item.PhoneNumber.ToString();
                tblCargo.Cell(row, 6).Range.Text = item.Email.ToString();
                tblCargo.Cell(row, 7).Range.Text = item.Bank.ToString();
                tblCargo.Cell(row, 8).Range.Text = item.BankAccount.ToString();
                tblCargo.Cell(row, 9).Range.Text = item.Inn.ToString();
                row++;
            }

            tblCargo.Borders.Enable = 1; // Включение границ

            // Установка стиля границ
            tblCargo.Borders.InsideLineStyle = Microsoft.Office.Interop.Word.WdLineStyle.wdLineStyleSingle;
            tblCargo.Borders.OutsideLineStyle = Microsoft.Office.Interop.Word.WdLineStyle.wdLineStyleSingle;


            Microsoft.Office.Interop.Word.Range rng2 = wordApp.Range(ref start, ref end);

            rng2.InsertBefore("Таблица руководителей");
            rng2.Font.Name = "Verdana";
            rng2.Font.Size = 16;
            rng2.InsertParagraphAfter();
            rng2.InsertParagraphAfter();
            rng2.SetRange(rng2.End, rng2.End);

            // Вставка заголовка "Следующая таблица"
            rng2.InsertParagraphAfter();
            rng2.InsertParagraphAfter();
            rng2.InsertAfter("Следующая таблица");
            rng2.InsertParagraphAfter();
            rng2.InsertParagraphAfter();

            // Вставка второй таблицы
            rng2.Tables.Add(wordApp.Paragraphs[2].Range, _RepHeadPersons.Items.Count() + 1, 2, ref missing, ref missing);



            // Форматирование второй таблицы и применение стиля
            Microsoft.Office.Interop.Word.Table tbl2 = wordApp.Tables[1];
            tbl2.Range.Font.Size = 12;
            tbl2.Columns.DistributeWidth();

            // Вставка значений в ячейки второй таблицы

            tbl2.Cell(1, 1).Range.Text = "Имя";
            tbl2.Cell(1, 2).Range.Text = "Фамилия";

            row = 2;

            foreach (var item in _RepHeadPersons.Items)
            {
                tbl2.Cell(row, 1).Range.Text = item.Name;
                tbl2.Cell(row, 2).Range.Text = item.Surname;


                row++;
            }

            tbl2.Borders.Enable = 1; // Включение границ

            // Установка стиля границ
            tbl2.Borders.InsideLineStyle = Microsoft.Office.Interop.Word.WdLineStyle.wdLineStyleSingle;
            tbl2.Borders.OutsideLineStyle = Microsoft.Office.Interop.Word.WdLineStyle.wdLineStyleSingle;


            Microsoft.Office.Interop.Word.Range rng3 = wordApp.Range(ref start, ref end);

            // Вставка заголовка "Следующая таблица"
            rng3.InsertParagraphAfter();
            rng3.InsertParagraphAfter();
            rng3.InsertAfter("Следующая таблица");
            rng3.InsertParagraphAfter();
            rng3.InsertParagraphAfter();

            // Вставка второй таблицы




            wordApp.SaveAs(filePath);
            wordApp.Close();

            //wordApp.Quit();
            MessageBox.Show("Файл word был создан, вы можете найти его в загрузках");

        }
        #endregion


        private ICommand _ExcelExport;

        public ICommand ExcelExport => _ExcelExport
           ??= new RelayCommand(OnExcelExportCommandExecuted, CanExcelExportCommandExecute);

        private bool CanExcelExportCommandExecute(object arg) => true;

        private void OnExcelExportCommandExecuted(object obj)
        {
            if (FileName == null) { MessageBox.Show("Пустое название файла", "Ошибка"); return; }
            if (!_UserDialog.ConfirmWarning("Точно хотите экспортировать базу данных?", "Экпорт")) { return; }


            string fileName = FileName;
            string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads", fileName);

            Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();
            if (xlApp == null)
            {
                MessageBox.Show("Excel установлен неправильно!!");
                return;
            }
            Microsoft.Office.Interop.Excel.Workbook xlWorkBook;
            Microsoft.Office.Interop.Excel.Worksheet xlWorkSheet;
            object misValue = System.Reflection.Missing.Value;
            xlWorkBook = xlApp.Workbooks.Add(misValue);
            xlWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

            Microsoft.Office.Interop.Excel.Sheets worksheets = xlWorkBook.Worksheets;

            var xlCargos = (Microsoft.Office.Interop.Excel.Worksheet)worksheets.Add(worksheets[1], Type.Missing, Type.Missing, Type.Missing);
            xlCargos.Name = "Партнёры";
            xlCargos.Cells[1, 1] = "Название фирмы";
            xlCargos.Cells[1, 2] = "Страна";
            xlCargos.Cells[1, 3] = "Руководитель";
            xlCargos.Cells[1, 4] = "Юридический адрес";
            xlCargos.Cells[1, 5] = "Номер телефона";
            xlCargos.Cells[1, 6] = "Email";
            xlCargos.Cells[1, 7] = "Банк";
            xlCargos.Cells[1, 8] = "Номер счёта";
            xlCargos.Cells[1, 9] = "ИНН";

            int row = 2;

            foreach (var item in _RepPartners.Items)
            {
                xlCargos.Cells[row, 1] = item.Name;
                xlCargos.Cells[row, 2] = item.Country.ToString();
                xlCargos.Cells[row, 3] = item.HeadPerson.ToString();
                xlCargos.Cells[row, 4] = item.LegalAddress.ToString();
                xlCargos.Cells[row, 5] = item.PhoneNumber.ToString();
                xlCargos.Cells[row, 6] = item.Email.ToString();
                xlCargos.Cells[row, 7] = item.Bank.ToString();
                xlCargos.Cells[row, 8] = item.BankAccount.ToString();
                xlCargos.Cells[row, 9] = item.Inn.ToString();
                row++;
            }

            var xlUnits = (Microsoft.Office.Interop.Excel.Worksheet)worksheets.Add(worksheets[1], Type.Missing, Type.Missing, Type.Missing);
            xlUnits.Name = "Руководители";
            xlUnits.Cells[1, 1] = "Имя";
            xlUnits.Cells[1, 2] = "Фамилия";

            row = 2;

            foreach (var item in _RepHeadPersons.Items)
            {
                xlUnits.Cells[row, 1] = item.Name;
                xlUnits.Cells[row, 2] = item.Surname;
                row++;
            }

            var xlBanks = (Microsoft.Office.Interop.Excel.Worksheet)worksheets.Add(worksheets[1], Type.Missing, Type.Missing, Type.Missing);
            xlBanks.Name = "Банки";
            xlBanks.Cells[1, 1] = "Название";

            row = 2;

            foreach (var item in _RepBanks.Items)
            {
                xlBanks.Cells[row, 1] = item.Name;
                row++;
            }


            xlWorkBook.SaveAs(filePath, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
            xlWorkBook.Close(true, misValue, misValue);
            xlApp.Quit();
            Marshal.ReleaseComObject(xlWorkSheet);
            Marshal.ReleaseComObject(worksheets);
            Marshal.ReleaseComObject(xlWorkBook);
            Marshal.ReleaseComObject(xlApp);
            MessageBox.Show("Файл excel был создан, вы можете найти его в загрузках");



        }






        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }


    }
}
