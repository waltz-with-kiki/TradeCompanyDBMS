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
using System.Windows.Shapes;
using TradeCompany.Hash;
using TradeCompany.ViewModels;

namespace TradeCompany
{
    /// <summary>
    /// Логика взаимодействия для Authorization.xaml
    /// </summary>
    public partial class Authorization : Window
    {
        public Authorization()
        {
            InitializeComponent();
            AuthorizationViewModel viewModel = DataContext as AuthorizationViewModel;
            viewModel.CloseWindowRequested += ViewModel_CloseWindowRequested;
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (DataContext is AuthorizationViewModel viewModel)
            {
                PasswordBox passwordBox = (PasswordBox)sender;
                viewModel.Password = md5.hashPassword(passwordBox.Password);
            }
        }

        private void PasswordBox_NewUserPassword(object sender, RoutedEventArgs e)
        {
            if (DataContext is AuthorizationViewModel viewModel)
            {
                PasswordBox NewPasswordBox = (PasswordBox)sender;
                viewModel.NewPassword = md5.hashPassword(NewPasswordBox.Password);
            }
        }


        private void ViewModel_CloseWindowRequested(object sender, EventArgs e)
        {
             Close();
         
        }
    }
}
