﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Animation;
using TradeCompany.DAL.Interfaces;
using TradeCompany.Domain.Model;
using TradeCompany.Services;
using static System.Net.Mime.MediaTypeNames;

namespace TradeCompany.ViewModels
{
    internal class AuthorizationViewModel : INotifyPropertyChanged
    {
        public string Title { get; set; } = "Авторизация";

        private string _username;
        private string _password;
        private bool _isLoggedIn;
        private string _RegisterEror;
        private bool _LoginEror = false;
        private readonly IRepository<User> _UsersRepository;
        private readonly IRepository<Right> _RightsRepository;
        private readonly IRepository<Structure> _StructuresRepository;

        private string _ColorLabel;

        public string ColorLabel
        {
            get
            {
                return _ColorLabel;
            }
            set
            {
                if (_ColorLabel != value)
                {
                    _ColorLabel = value;
                    OnPropertyChanged(nameof(RegisterEror));
                }
            }
        }

        public string RegisterEror
        {
            get
            {
                return _RegisterEror;
            }
            set
            {
                if (_RegisterEror != value)
                {
                    _RegisterEror = value;
                    OnPropertyChanged(nameof(RegisterEror));
                }
            }
        }

        public bool IsVisible
        {
            get { return _LoginEror; }
            set
            {
                if (_LoginEror != value)
                {
                    _LoginEror = value;
                    OnPropertyChanged(nameof(IsVisible));
                }
            }
        }


        public event EventHandler CloseWindowRequested;


        bool isPresented = true;
        public bool IsPresented
        {
            get { return isPresented; }
            set { if (isPresented != value) { isPresented = value; OnPropertyChanged(); } }
        }


        public string Username
        {
            get { return _username; }
            set
            {
                _username = value;
                OnPropertyChanged();
            }
        }

        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                OnPropertyChanged();
            }
        }

        public bool IsLoggedIn
        {
            get { return _isLoggedIn; }
            set
            {
                _isLoggedIn = value;
                OnPropertyChanged();
            }
        }

        public string NewUsername
        {
            get { return _username; }
            set
            {
                _username = value;
                OnPropertyChanged();
            }
        }

        public string NewPassword
        {
            get { return _password; }
            set
            {
                _password = value;
                OnPropertyChanged();
            }
        }



        private ICommand _loginCommand;

        public ICommand LoginCommand
        {
            get
            {
                if (_loginCommand == null)
                {
                    _loginCommand = new RelayCommand(Login, CanLogin);
                }
                return _loginCommand;
            }
        }

        private ICommand _AddNewUser;

        public ICommand AddNewUserCommand => _AddNewUser
            ??= new RelayCommand(OnAddNewUserExecuted, CanAddNewUserCommandExecute);

        private bool CanAddNewUserCommandExecute(object arg)
        {
            return !string.IsNullOrEmpty(NewUsername) && !string.IsNullOrEmpty(NewPassword);
        }

        private void OnAddNewUserExecuted(object obj)
        {
            if (NewUsername.Length < 4 || NewPassword.Length < 4)
            {
                RegisterEror = "Не удалось зарегистрировать нового пользователя. Длина пароля/логина меньше 4 символов";
            }
            else
            {
                var new_user = new User
                {
                    Name = NewUsername,
                    Password = NewPassword,
                    Rights = new List<Right>
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
                        }
                };

                var Add = _UsersRepository.Items.Any(x => x.Name == NewUsername);

                if (Add)
                {
                    RegisterEror = "Пользователь с таким именем уже существует";
                }
                else
                {
                    foreach (var right in new_user.Rights)
                    {
                        right.User = new_user;
                        _RightsRepository.Add(right);
                    }

                    _UsersRepository.Add(new_user);
                    RegisterEror = "Пользователь удачно зарегистрирован";
                }

            }
        }



        public AuthorizationViewModel(IRepository<Right> Rights, IRepository<User> Users, IRepository<Structure> structures)
        {
            _RightsRepository = Rights;
            _UsersRepository = Users;
            _StructuresRepository = structures;
            _loginCommand = new RelayCommand(Login, CanLogin);
        }



        private bool CanLogin(object parameter)
        {

            return !string.IsNullOrEmpty(Username) && !string.IsNullOrEmpty(Password);
        }

        private void Login(object parameter)
        {



            var user = _UsersRepository.Items.Where(x => x.Name == Username && x.Password == Password).FirstOrDefault();

            if (user != null)
            {
                IsLoggedIn = true;
                var mainwindow = new MainWindow(user, _UsersRepository);
                mainwindow.Show();
                IsPresented = false;
                CloseWindowRequested?.Invoke(this, new CloseWindowEventArgs());
            }

            else
            {
                ShowLabel();
            }
        }



        public class CloseWindowEventArgs : EventArgs
        {

        }


        private void ShowLabel()
        {
            IsVisible = true;

            DoubleAnimation animation = new DoubleAnimation
            {
                From = 0,
                To = 1,
                Duration = TimeSpan.FromSeconds(2)
            };
            /*
             * 
            // Завершение анимации
            animation.Completed += (sender, e) =>
            {
                Thread.Sleep(10000);
                IsVisible = false;
            };

            */
            // Найти окно, чтобы получить доступ к его ресурсам
            Window window = System.Windows.Application.Current.Windows.OfType<Window>().SingleOrDefault(x => x.IsActive);

            // Запустить анимацию
            Label label = window?.FindName("LoginEror") as Label;
            label?.BeginAnimation(UIElement.OpacityProperty, animation);
        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


    }
}
