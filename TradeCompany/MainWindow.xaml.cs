using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TradeCompany.DAL.Interfaces;
using TradeCompany.Domain.Model;
using TradeCompany.Hash;

namespace TradeCompany
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        User CurrentUser { get; set; }

        private readonly IRepository<User> _UserRep;

        public MainWindow(User user, IRepository<User> users)
        {
            CurrentUser = user;
            InitializeComponent();

            _UserRep = users;
            InitializeUser(user);
        }


        private void InitializeUser(User user)
        {

            /*if (user.Id != 1 && user.Name != "Admin")
            {
                AdminGrid.Visibility = Visibility.Hidden;
                AddUser.Visibility = Visibility.Hidden;
                EditUser.Visibility = Visibility.Hidden;
                RemoveUser.Visibility = Visibility.Hidden;
            }*/

            var AccountingUnitFormRightAccess = user.Rights.FirstOrDefault(x => x.Form == FormType.AccountingUnitForm);
            AccessRightForm(AccountingUnitFormRightAccess, AccountingUnitsGrid, AddAccountingUnit, EditAccountingUnit, RemoveAccountingUnit);

            var BankFormRightAccess = user.Rights.FirstOrDefault(x => x.Form == FormType.BankForm);
            AccessRightForm(BankFormRightAccess, BanksGrid, AddBank, EditBank, RemoveBank);

            var CountryFormRightAccess = user.Rights.FirstOrDefault(x => x.Form == FormType.CountryForm);
            AccessRightForm(CountryFormRightAccess, CountriesGrid, AddCountrie, EditCountrie, RemoveCountrie);

            var GroupFormRightAccess = user.Rights.FirstOrDefault(x => x.Form == FormType.GroupForm);
            AccessRightForm(GroupFormRightAccess, GroupsGrid, AddGroup, EditGroup, RemoveGroup);

            var HeadPersonFormRightAccess = user.Rights.FirstOrDefault(x => x.Form == FormType.HeadPersonForm);
            AccessRightForm(HeadPersonFormRightAccess, HeadPersonsGrid, AddHeadPerson, EditHeadPerson, RemoveHeadPerson);

            var InvoiceFormRightAccess = user.Rights.FirstOrDefault(x => x.Form == FormType.InvoiceForm);
            AccessRightForm(InvoiceFormRightAccess, InvoicesGrid, AddInvoice, EditInvoice, RemoveInvoice);

            var ManufacturerFormRightAccess = user.Rights.FirstOrDefault(x => x.Form == FormType.ManufacturerForm);
            AccessRightForm(ManufacturerFormRightAccess, ManufacturersGrid, AddManufacturer, EditManufacturer, RemoveManufacturer);

            var OrderFormRightAccess = user.Rights.FirstOrDefault(x => x.Form == FormType.OrderForm);
            AccessRightForm(OrderFormRightAccess, OrdersGrid, AddOrder, EditOrder, RemoveOrder);

            var PartnerFormRightAccess = user.Rights.FirstOrDefault(x => x.Form == FormType.PartnerForm);
            AccessRightForm(PartnerFormRightAccess, PartnersGrid, AddPartner, EditPartner, RemovePartner);

            var ProductFormRightAccess = user.Rights.FirstOrDefault(x => x.Form == FormType.ProductForm);
            AccessRightForm(ProductFormRightAccess, ProductsGrid, AddProduct, EditProduct, RemoveProduct);

            var SoldProductFormRightAccess = user.Rights.FirstOrDefault(x => x.Form == FormType.SoldProductForm);
            AccessRightForm(SoldProductFormRightAccess, SoldProductsGrid, AddSoldProduct, EditSoldProduct, RemoveSoldProduct);

            var StoreFormRightAccess = user.Rights.FirstOrDefault(x => x.Form == FormType.StoreForm);
            AccessRightForm(StoreFormRightAccess, StoresGrid, AddStore, EditStore, RemoveStore);

            var AdminFormRightAccess = user.Rights.FirstOrDefault(x => x.Form == FormType.AdminForm);
            AccessRightForm(AdminFormRightAccess, AdminGrid, AddUser, EditUser, RemoveUser);
        }

        private void AccessRightForm(Right accessRight, Grid grid, Button addButton, Button editButton, Button deleteButton)
        {
            if (!accessRight.R)
            {
                grid.Visibility = Visibility.Hidden;
            }
            if (!accessRight.W)
            {
                addButton.Visibility = Visibility.Collapsed;
            }
            if (!accessRight.E)
            {
                editButton.Visibility = Visibility.Collapsed;
            }
            if (!accessRight.D)
            {
                deleteButton.Visibility = Visibility.Collapsed;
            }
        }

        private void ChangePassword(object sender, RoutedEventArgs e)
        {
            if (md5.hashPassword(OldPassword.Password) == CurrentUser.Password && NewPassword.Password.Length > 3 && NewPassword.Password == PassRepeat.Password && NewPassword.Password != OldPassword.Password)
            {
                CurrentUser.Password = md5.hashPassword(NewPassword.Password);
                //CurrentUser.Password
                _UserRep.Update(CurrentUser);
                MessageBox.Show("Пароль успешно изменён");
                OldPassword.Clear();
                NewPassword.Clear();
                PassRepeat.Clear();
            }
            else
            {
                MessageBox.Show("Не получилось изменить пароль", "Ошибка");
            }
        }

    }
}
