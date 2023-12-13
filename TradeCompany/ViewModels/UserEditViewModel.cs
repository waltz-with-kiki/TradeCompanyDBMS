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
    internal class UserEditViewModel : INotifyPropertyChanged
    {
        public string Title { get; set; }


        public bool IsVisible { get; set; }


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

        private string _Password;


        public string Password
        {
            get { return _Password; }
            set
            {
                _Password = value;
                OnPropertyChanged(nameof(Password));

            }
        }

        public List<Right> rights { get; set; }

       // public Right[] rights { get; set; }

        public UserEditViewModel()
        {
            Title = "Добавление пользователя";
            IsVisible = true;

            rights = new List<Right>
                        {
                            new Right { R = false, W = false, E = false, D = false, Form = FormType.AdminForm},
                            new Right { R = false, W = false, E = false, D = false, Form = FormType.OrderForm},
                           new Right { R = false, W = false, E = false, D = false, Form = FormType.InvoiceForm},
                            new Right { R = false, W = false, E = false, D = false, Form = FormType.PartnerForm},
                            new Right { R = false, W = false, E = false, D = false, Form = FormType.SoldProductForm},
                            new Right { R = false, W = false, E = false, D = false, Form = FormType.StoreForm},
                            new Right { R = false, W = false, E = false, D = false, Form = FormType.ProductForm},
                            new Right { R = false, W = false, E = false, D = false, Form = FormType.HeadPersonForm},
                            new Right { R = false, W = false, E = false, D = false, Form = FormType.BankForm},
                            new Right { R = false, W = false, E = false, D = false, Form = FormType.CountryForm},
                            new Right { R = false, W = false, E = false, D = false, Form = FormType.GroupForm},
                            new Right { R = false, W = false, E = false, D = false, Form = FormType.ManufacturerForm},
                            new Right { R = false, W = false, E = false, D = false, Form = FormType.AccountingUnitForm},
                        };
        }

        public UserEditViewModel(User user)
        {
            Title = "Изменение пользователя";
            IsVisible = false;


            Name = user.Name;
            Password = user.Password;

            rights = user.Rights.ToList();


            /*
            rights[0] = user.Rights.FirstOrDefault(x => x.Form == FormType.AdminForm);
            rights[1] = user.Rights.FirstOrDefault(x => x.Form == FormType.OrderForm);
            rights[2] = user.Rights.FirstOrDefault(x => x.Form == FormType.InvoiceForm);
            rights[3] = user.Rights.FirstOrDefault(x => x.Form == FormType.PartnerForm);
            rights[4] = user.Rights.FirstOrDefault(x => x.Form == FormType.SoldProductForm);
            rights[5] = user.Rights.FirstOrDefault(x => x.Form == FormType.StoreForm);
            rights[6] = user.Rights.FirstOrDefault(x => x.Form == FormType.ProductForm);
            rights[7] = user.Rights.FirstOrDefault(x => x.Form == FormType.HeadPersonForm);
            rights[8] = user.Rights.FirstOrDefault(x => x.Form == FormType.BankForm);
            rights[9] = user.Rights.FirstOrDefault(x => x.Form == FormType.CountryForm);
            rights[10] = user.Rights.FirstOrDefault(x => x.Form == FormType.GroupForm);
            rights[11] = user.Rights.FirstOrDefault(x => x.Form == FormType.ManufacturerForm);
            rights[12] = user.Rights.FirstOrDefault(x => x.Form == FormType.AccountingUnitForm);*/
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

    }
}
