using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TradeCompany.DAL.Interfaces;
using TradeCompany.Domain.Model;
using TradeCompany.Hash;
using TradeCompany.Services.Interface;
using TradeCompany.ViewModels;
using TradeCompany.Views;

namespace TradeCompany.Services
{
    internal class ActionHandlerService : IActionHandlerService
    {
        public ValidationResult results;

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

        public bool Add<T>(T item)
        {
            switch (item)
            {
                case Bank bank:

                    var bank_editor_model = new BankEditViewModel();
                    var bank_editor_window = new BankEditView
                    {
                        DataContext = bank_editor_model
                    };

                    if (bank_editor_window.ShowDialog() != true) return false;

                    BankValidator BankValidator = new BankValidator();

                    results = BankValidator.Validate(bank_editor_model);

                    if (!results.IsValid)
                    {
                        MessageBox.Show(results.ToString(), "Ошибка добавления");
                        return false;
                    }

                    bank.Name = bank_editor_model.Name;

                    return true;

                case Manufacturer manufacturer:

                    var manufacturer_editor_model = new ManufacturerEditViewModel();
                    var manufacturer_editor_window = new ManufacturerEditView
                    {
                        DataContext = manufacturer_editor_model
                    };

                    if (manufacturer_editor_window.ShowDialog() != true) return false;

                    ManufacturerValidator ManufacturerValidator = new ManufacturerValidator();

                    results = ManufacturerValidator.Validate(manufacturer_editor_model);

                    if (!results.IsValid)
                    {
                        MessageBox.Show(results.ToString(), "Ошибка добавления");
                        return false;
                    }

                    manufacturer.Name = manufacturer_editor_model.Name;

                    return true;

                case Group group:

                    var group_editor_model = new GroupEditViewModel();
                    var group_editor_window = new GroupEditView
                    {
                        DataContext = group_editor_model
                    };

                    if (group_editor_window.ShowDialog() != true) return false;

                    GroupValidator GroupValidator = new GroupValidator();

                    results = GroupValidator.Validate(group_editor_model);

                    if (!results.IsValid)
                    {
                        MessageBox.Show(results.ToString(), "Ошибка добавления");
                        return false;
                    }

                    group.Name = group_editor_model.Name;

                    return true;

                case Country country:
                    var country_editor_model = new CountryEditViewModel();
                    var country_editor_window = new CountryEditView
                    {
                        DataContext = country_editor_model
                    };

                    if (country_editor_window.ShowDialog() != true) return false;


                    CountryValidator CountryValidator = new CountryValidator();

                    results = CountryValidator.Validate(country_editor_model);

                    if (!results.IsValid)
                    {
                        MessageBox.Show(results.ToString(), "Ошибка добавления");
                        return false;
                    }

                    country.Name = country_editor_model.Name;


                    return true;

                case AccountingUnit accountingUnit:
                    var accountingUnit_editor_model = new AccountingUnitEditViewModel();
                    var accountingUnit_editor_window = new AccountingUnitEditView
                    {
                        DataContext = accountingUnit_editor_model
                    };

                    if (accountingUnit_editor_window.ShowDialog() != true) return false;


                    AccountingUnitValidator AccountingUnitValidator = new AccountingUnitValidator();

                    results = AccountingUnitValidator.Validate(accountingUnit_editor_model);

                    if (!results.IsValid)
                    {
                        MessageBox.Show(results.ToString(), "Ошибка добавления");
                        return false;
                    }

                    accountingUnit.Name = accountingUnit_editor_model.Name;


                    return true;

                case HeadPerson headperson:
                    var headperson_editor_model = new HeadPersonEditViewModel();
                    var headperson_editor_window = new HeadPersonEditView
                    {
                        DataContext = headperson_editor_model
                    };

                    if (headperson_editor_window.ShowDialog() != true) return false;


                    HeadPersonValidator HeadPersonValidator = new HeadPersonValidator();

                    results = HeadPersonValidator.Validate(headperson_editor_model);

                    if (!results.IsValid)
                    {
                        MessageBox.Show(results.ToString(), "Ошибка добавления");
                        return false;
                    }

                    headperson.Name = headperson_editor_model.Name;
                    headperson.Surname = headperson_editor_model.Surname;


                    return true;

                case Product product:
                    var product_editor_model = new ProductEditViewModel(_RepGroups, _RepManufacturers, _RepAccountingUnits);
                    var product_editor_window = new ProductEditView
                    {
                        DataContext = product_editor_model
                    };

                    if (product_editor_window.ShowDialog() != true) return false;


                    ProductValidator ProductValidator = new ProductValidator();

                    results = ProductValidator.Validate(product_editor_model);

                    if (!results.IsValid)
                    {
                        MessageBox.Show(results.ToString(), "Ошибка добавления");
                        return false;
                    }

                    product.Name = product_editor_model.Name;
                    product.Group = product_editor_model.group;
                    product.Manufacturer = product_editor_model.manufacturer;
                    product.AccountingUnit = product_editor_model.accountingUnit;
                    product.GroupId = product_editor_model.group.Id;
                    product.ManufacturerId = product_editor_model.manufacturer.Id;
                    product.AccountingUnitId = product_editor_model.accountingUnit.Id;


                    return true;

                case Partner partner:

                    var partner_editor_model = new PartnerEditViewModel(_RepCountries, _RepHeadPersons, _RepBanks);
                    var partner_editor_window = new PartnerEditView
                    {
                        DataContext = partner_editor_model
                    };

                    if (partner_editor_window.ShowDialog() != true) return false;

                    PartnerValidator PartnerValidator = new PartnerValidator();

                    results = PartnerValidator.Validate(partner_editor_model);

                    if (!results.IsValid)
                    {
                        MessageBox.Show(results.ToString(), "Ошибка добавления");
                        return false;
                    }

                    partner.Name = partner_editor_model.Name;
                    partner.Country = partner_editor_model.country;
                    partner.CountryId = partner_editor_model.country.Id;
                    partner.HeadPerson = partner_editor_model.headPerson;
                    partner.HeadPersonId = partner_editor_model.headPerson.Id;
                    partner.LegalAddress = partner_editor_model.LegalAdress;
                    partner.Email = partner_editor_model.Email;
                    partner.PhoneNumber = partner_editor_model.PhoneNumber;
                    partner.Bank = partner_editor_model.bank;
                    partner.BankId = partner_editor_model.bank.Id;
                    partner.BankAccount = partner_editor_model.BankAccount;
                    partner.Inn = partner_editor_model.Inn;

                    return true;

                case Invoice invoice:
                    var invoice_editor_model = new InvoiceEditViewModel(_RepPartners);
                    var invoice_editor_window = new InvoiceEditView
                    {
                        DataContext = invoice_editor_model
                    };

                    if (invoice_editor_window.ShowDialog() != true) return false;


                    InvoiceValidator InvoiceValidator = new InvoiceValidator();

                    results = InvoiceValidator.Validate(invoice_editor_model);

                    if (!results.IsValid)
                    {
                        MessageBox.Show(results.ToString(), "Ошибка добавления");
                        return false;
                    }

                    //invoice.Name = invoice_editor_model.Name;
                    //invoice.Surname = invoice_editor_model.Surname;
                    invoice.Partner = invoice_editor_model.partner;
                    invoice.PartnerId = invoice_editor_model.partner.Id;
                    invoice.DeliveryDate = invoice_editor_model.DeliveryDate;




                    return true;

                case Store store:
                    var store_editor_model = new StoreEditViewModel(_RepInvoices, _RepProducts);
                    var store_editor_window = new StoreEditView
                    {
                        DataContext = store_editor_model
                    };

                    if (store_editor_window.ShowDialog() != true) return false;


                    StoreValidator StoreValidator = new StoreValidator();

                    results = StoreValidator.Validate(store_editor_model);

                    if (!results.IsValid)
                    {
                        MessageBox.Show(results.ToString(), "Ошибка добавления");
                        return false;
                    }

                    store.ShelfLife = store_editor_model.ShelfLife;
                    store.Invoice = store_editor_model.invoice;
                    store.InvoiceId = store_editor_model.invoice.Id;
                    store.Product = store_editor_model.product;
                    store.ProductId = store_editor_model.product.Id;
                    store.Count = Convert.ToInt32(store_editor_model.Count);
                    store.PricePerUnit = Convert.ToDecimal(store_editor_model.PricePerUnit);



                    return true;

                case Order order:
                    var order_editor_model = new OrderEditViewModel(_RepPartners);
                    var order_editor_window = new OrderEditView
                    {
                        DataContext = order_editor_model
                    };

                    if (order_editor_window.ShowDialog() != true) return false;


                    OrderValidator OrderValidator = new OrderValidator();

                    results = OrderValidator.Validate(order_editor_model);

                    if (!results.IsValid)
                    {
                        MessageBox.Show(results.ToString(), "Ошибка добавления");
                        return false;
                    }

                    order.Partner = order_editor_model.partner;
                    order.PartnerId = order_editor_model.partner.Id;
                    order.CompletionDate = order_editor_model.CompletionDate;



                    return true;


                case SoldProduct soldproduct:
                    var soldproduct_editor_model = new SoldProductEditViewModel(_RepOrders, _RepStores);
                    var soldproduct_editor_window = new SoldProductEditView
                    {
                        DataContext = soldproduct_editor_model
                    };

                    if (soldproduct_editor_window.ShowDialog() != true) return false;


                    SoldProductValidator SoldProductValidator = new SoldProductValidator();

                    results = SoldProductValidator.Validate(soldproduct_editor_model);

                    if (!results.IsValid)
                    {
                        MessageBox.Show(results.ToString(), "Ошибка добавления");
                        return false;
                    }

                    soldproduct.Store = soldproduct_editor_model.store;
                    soldproduct.StoreId = soldproduct_editor_model.store.Id;
                    soldproduct.Order = soldproduct_editor_model.order;
                    soldproduct.OrderId = soldproduct_editor_model.order.Id;
                    soldproduct.Count = Convert.ToInt32(soldproduct_editor_model.Count);


                    return true;

                case User user:
                    var user_editor_model = new UserEditViewModel();
                    var user_editor_window = new UserEditView
                    {
                        DataContext = user_editor_model
                    };

                    if (user_editor_window.ShowDialog() != true) return false;


                    UserValidator UserValidator = new UserValidator();

                    results = UserValidator.Validate(user_editor_model);

                    if (!results.IsValid)
                    {
                        MessageBox.Show(results.ToString(), "Ошибка добавления");
                        return false;
                    }

                    foreach (var newright in user_editor_model.rights)
                    {
                        newright.User = user;
                        _RepRights.Add(newright);
                    }

                    //_RepRights.Add(new_right);

                    user.Name = user_editor_model.Name;
                    user.Password = md5.hashPassword(user_editor_model.Password);
                    //user.Right = new_right;
                  

                    return true;



            }

                return false;
        }

        public bool Edit<T>(T item)
        {
            switch (item)
            {
                case Bank bank:
                    var bank_editor_model = new BankEditViewModel(bank);
                    var bank_editor_window = new BankEditView
                    {
                        DataContext = bank_editor_model
                    };

                    if (bank_editor_window.ShowDialog() != true) return false;


                    BankValidator BankValidator = new BankValidator();

                    results = BankValidator.Validate(bank_editor_model);

                    if (!results.IsValid)
                    {
                        MessageBox.Show(results.ToString(), "Ошибка редактирования");
                        return false;
                    }

                    bank.Name = bank_editor_model.Name;


                    return true;

                case Manufacturer manufacturer:

                    var manufacturer_editor_model = new ManufacturerEditViewModel(manufacturer);
                    var manufacturer_editor_window = new ManufacturerEditView
                    {
                        DataContext = manufacturer_editor_model
                    };

                    if (manufacturer_editor_window.ShowDialog() != true) return false;


                    ManufacturerValidator ManufacturerValidator = new ManufacturerValidator();

                    results = ManufacturerValidator.Validate(manufacturer_editor_model);

                    if (!results.IsValid)
                    {
                        MessageBox.Show(results.ToString(), "Ошибка редактирования");
                        return false;
                    }

                    manufacturer.Name = manufacturer_editor_model.Name;


                    return true;

                case Group group:

                    var group_editor_model = new GroupEditViewModel(group);
                    var group_editor_window = new GroupEditView
                    {
                        DataContext = group_editor_model
                    };

                    if (group_editor_window.ShowDialog() != true) return false;

                    GroupValidator GroupValidator = new GroupValidator();

                    results = GroupValidator.Validate(group_editor_model);

                    if (!results.IsValid)
                    {
                        MessageBox.Show(results.ToString(), "Ошибка редактирования");
                        return false;
                    }

                    group.Name = group_editor_model.Name;

                    return true;

                case Country country:
                    var country_editor_model = new CountryEditViewModel(country);
                    var country_editor_window = new CountryEditView
                    {
                        DataContext = country_editor_model
                    };

                    if (country_editor_window.ShowDialog() != true) return false;


                    CountryValidator CountryValidator = new CountryValidator();

                    results = CountryValidator.Validate(country_editor_model);

                    if (!results.IsValid)
                    {
                        MessageBox.Show(results.ToString(), "Ошибка редактировния");
                        return false;
                    }

                    country.Name = country_editor_model.Name;


                    return true;

                case AccountingUnit accountingUnit:
                    var accountingUnit_editor_model = new AccountingUnitEditViewModel(accountingUnit);
                    var accountingUnit_editor_window = new AccountingUnitEditView
                    {
                        DataContext = accountingUnit_editor_model
                    };

                    if (accountingUnit_editor_window.ShowDialog() != true) return false;


                    AccountingUnitValidator AccountingUnitValidator = new AccountingUnitValidator();

                    results = AccountingUnitValidator.Validate(accountingUnit_editor_model);

                    if (!results.IsValid)
                    {
                        MessageBox.Show(results.ToString(), "Ошибка редактирования");
                        return false;
                    }

                    accountingUnit.Name = accountingUnit_editor_model.Name;


                    return true;

                case HeadPerson headperson:
                    var headperson_editor_model = new HeadPersonEditViewModel(headperson);
                    var headperson_editor_window = new HeadPersonEditView
                    {
                        DataContext = headperson_editor_model
                    };

                    if (headperson_editor_window.ShowDialog() != true) return false;


                    HeadPersonValidator HeadPersonValidator = new HeadPersonValidator();

                    results = HeadPersonValidator.Validate(headperson_editor_model);

                    if (!results.IsValid)
                    {
                        MessageBox.Show(results.ToString(), "Ошибка редактирования");
                        return false;
                    }

                    headperson.Name = headperson_editor_model.Name;
                    headperson.Surname = headperson_editor_model.Surname;


                    return true;

                case Product product:
                    var product_editor_model = new ProductEditViewModel(_RepGroups, _RepManufacturers, _RepAccountingUnits, product);
                    var product_editor_window = new ProductEditView
                    {
                        DataContext = product_editor_model
                    };

                    if (product_editor_window.ShowDialog() != true) return false;


                    ProductValidator ProductValidator = new ProductValidator();

                    results = ProductValidator.Validate(product_editor_model);

                    if (!results.IsValid)
                    {
                        MessageBox.Show(results.ToString(), "Ошибка редактирования");
                        return false;
                    }

                    product.Name = product_editor_model.Name;
                    product.Group = product_editor_model.group;
                    product.Manufacturer = product_editor_model.manufacturer;
                    product.AccountingUnit = product_editor_model.accountingUnit;
                    product.GroupId = product_editor_model.group.Id;
                    product.ManufacturerId = product_editor_model.manufacturer.Id;
                    product.AccountingUnitId = product_editor_model.accountingUnit.Id;


                    return true;

                case Partner partner:

                    var partner_editor_model = new PartnerEditViewModel(_RepCountries, _RepHeadPersons, _RepBanks, partner);
                    var partner_editor_window = new PartnerEditView
                    {
                        DataContext = partner_editor_model
                    };

                    if (partner_editor_window.ShowDialog() != true) return false;

                    PartnerValidator PartnerValidator = new PartnerValidator();

                    results = PartnerValidator.Validate(partner_editor_model);

                    if (!results.IsValid)
                    {
                        MessageBox.Show(results.ToString(), "Ошибка редактирования");
                        return false;
                    }

                    partner.Name = partner_editor_model.Name;
                    partner.Country = partner_editor_model.country;
                    partner.CountryId = partner_editor_model.country.Id;
                    partner.HeadPerson = partner_editor_model.headPerson;
                    partner.HeadPersonId = partner_editor_model.headPerson.Id;
                    partner.LegalAddress = partner_editor_model.LegalAdress;
                    partner.Email = partner_editor_model.Email;
                    partner.PhoneNumber = partner_editor_model.PhoneNumber;
                    partner.Bank = partner_editor_model.bank;
                    partner.BankId = partner_editor_model.bank.Id;
                    partner.BankAccount = partner_editor_model.BankAccount;
                    partner.Inn = partner_editor_model.Inn;


                    return true;

                case Invoice invoice:
                    var invoice_editor_model = new InvoiceEditViewModel(_RepPartners, invoice);
                    var invoice_editor_window = new InvoiceEditView
                    {
                        DataContext = invoice_editor_model
                    };

                    if (invoice_editor_window.ShowDialog() != true) return false;


                    InvoiceValidator InvoiceValidator = new InvoiceValidator();

                    results = InvoiceValidator.Validate(invoice_editor_model);

                    if (!results.IsValid)
                    {
                        MessageBox.Show(results.ToString(), "Ошибка редактирования");
                        return false;
                    }

                    
                    invoice.Partner = invoice_editor_model.partner;
                    invoice.PartnerId = invoice_editor_model.partner.Id;
                    invoice.DeliveryDate = invoice_editor_model.DeliveryDate;




                    return true;

                case Store store:
                    var store_editor_model = new StoreEditViewModel(_RepInvoices, _RepProducts , store);
                    var store_editor_window = new StoreEditView
                    {
                        DataContext = store_editor_model
                    };

                    if (store_editor_window.ShowDialog() != true) return false;


                    StoreValidator StoreValidator = new StoreValidator();

                    results = StoreValidator.Validate(store_editor_model);

                    if (!results.IsValid)
                    {
                        MessageBox.Show(results.ToString(), "Ошибка редактирования");
                        return false;
                    }

                    store.ShelfLife = store_editor_model.ShelfLife;
                    store.Invoice = store_editor_model.invoice;
                    store.InvoiceId = store_editor_model.invoice.Id;
                    store.Product = store_editor_model.product;
                    store.ProductId = store_editor_model.product.Id;
                    store.Count = Convert.ToInt32(store_editor_model.Count);
                    store.PricePerUnit = Convert.ToDecimal(store_editor_model.PricePerUnit);


                    




                    return true;


                case Order order:
                    var order_editor_model = new OrderEditViewModel(_RepPartners, order);
                    var order_editor_window = new OrderEditView
                    {
                        DataContext = order_editor_model
                    };

                    if (order_editor_window.ShowDialog() != true) return false;


                    OrderValidator OrderValidator = new OrderValidator();

                    results = OrderValidator.Validate(order_editor_model);

                    if (!results.IsValid)
                    {
                        MessageBox.Show(results.ToString(), "Ошибка редактирования");
                        return false;
                    }

                    order.Partner = order_editor_model.partner;
                    order.PartnerId = order_editor_model.partner.Id;
                    order.CompletionDate = order_editor_model.CompletionDate;



                    return true;

                case SoldProduct soldproduct:
                    var soldproduct_editor_model = new SoldProductEditViewModel(_RepOrders, _RepStores, soldproduct);
                    var soldproduct_editor_window = new SoldProductEditView
                    {
                        DataContext = soldproduct_editor_model
                    };

                    if (soldproduct_editor_window.ShowDialog() != true) return false;


                    SoldProductRedValidator SoldProductRedValidator = new SoldProductRedValidator();

                    results = SoldProductRedValidator.Validate(soldproduct_editor_model);

                    if (!results.IsValid)
                    {
                        MessageBox.Show(results.ToString(), "Ошибка редактирования");
                        return false;
                    }


                    soldproduct.Store = soldproduct_editor_model.store;
                    soldproduct.StoreId = soldproduct_editor_model.store.Id;
                    soldproduct.Order = soldproduct_editor_model.order;
                    soldproduct.OrderId = soldproduct_editor_model.order.Id;
                    soldproduct.Count = Convert.ToInt32(soldproduct_editor_model.Count);


                    return true;

                case User user:
                    var user_editor_model = new UserEditViewModel(user);
                    var user_editor_window = new UserEditView
                    {
                        DataContext = user_editor_model
                    };

                    if (user_editor_window.ShowDialog() != true) return false;


                    UserValidator UserValidator = new UserValidator();

                    results = UserValidator.Validate(user_editor_model);

                    if (!results.IsValid)
                    {
                        MessageBox.Show(results.ToString(), "Ошибка редактирования");
                        return false;
                    }

                    user.Name = user_editor_model.Name;
                    user.Rights = user_editor_model.rights.ToList();
                    
                    return true;



            }

            return false;
        }


        public class BankValidator : AbstractValidator<BankEditViewModel>
        {
            public BankValidator()
            {
                RuleFor(bank => bank.Name).NotEmpty().MinimumLength(3);
            }
        }

        public class ManufacturerValidator : AbstractValidator<ManufacturerEditViewModel>
        {
            public ManufacturerValidator()
            {
                RuleFor(manufacturer => manufacturer.Name).NotEmpty().MinimumLength(3);
            }
        }

        public class GroupValidator : AbstractValidator<GroupEditViewModel>
        {
            public GroupValidator()
            {
                RuleFor(group => group.Name).NotEmpty().MinimumLength(3);
            }
        }

        public class CountryValidator : AbstractValidator<CountryEditViewModel>
        {
            public CountryValidator()
            {
                RuleFor(country => country.Name).NotEmpty().MinimumLength(3);
            }
        }

        

        public class AccountingUnitValidator : AbstractValidator<AccountingUnitEditViewModel>
        {
            public AccountingUnitValidator()
            {
                RuleFor(accountingUnit => accountingUnit.Name).NotEmpty().MinimumLength(3);
            }
        }

        public class HeadPersonValidator : AbstractValidator<HeadPersonEditViewModel>
        {
            public HeadPersonValidator()
            {
                RuleFor(headPerson => headPerson.Name).NotEmpty().MinimumLength(3);
            }
        }

        public class ProductValidator : AbstractValidator<ProductEditViewModel>
        {
            public ProductValidator()
            {
                RuleFor(product => product.Name).NotEmpty().MinimumLength(3);
                RuleFor(product => product.group).NotEmpty();
                RuleFor(product => product.manufacturer).NotEmpty();
                RuleFor(product => product.accountingUnit).NotEmpty();
            }
        }
        
        public class PartnerValidator : AbstractValidator<PartnerEditViewModel>
        {
            public PartnerValidator()
            {
                BigInteger res;
                ulong result;
                System.Text.RegularExpressions.Regex Phone = new System.Text.RegularExpressions.Regex(@"^\+?\d{11}$");
                RuleFor(partner => partner.Name).NotEmpty().MinimumLength(3);
                RuleFor(partner => partner.country).NotEmpty();
                RuleFor(partner => partner.headPerson).NotEmpty();
                RuleFor(partner => partner.LegalAdress).NotEmpty().MinimumLength(3);
                RuleFor(partner => partner.Email).NotEmpty().MinimumLength(3);
                RuleFor(partner => partner.PhoneNumber).Cascade(CascadeMode.Stop).Length(11, 12).WithMessage("Длина номера телефона должна быть от 11 до 12 символов").NotEmpty().WithMessage("PhoneNumber не должен быть пустым").Must(number => number == null || Phone.Match(number).Success).WithMessage("Неверный формат номера телефона, пример: (+79434789412 или 89544266676)");
                RuleFor(partner => partner.bank).NotEmpty();
                RuleFor(partner => partner.BankAccount).NotEmpty().Length(20).Must(bankacc => BigInteger.TryParse(bankacc, out res)).WithMessage("Неверный формат числа");
                RuleFor(partner => partner.Inn).Must(inn => ulong.TryParse(inn, out result)).WithMessage("Неверный формат ИНН, ввод должен содержать 12 цифр");

            }
        }
        
        public class InvoiceValidator : AbstractValidator<InvoiceEditViewModel>
        {
            public InvoiceValidator()
            {
                RuleFor(invoice => invoice.partner).NotEmpty();
                RuleFor(invoice => invoice.DeliveryDate).NotEmpty().Must(date => (date.Year >= 1975)).WithMessage("Дата имеет странное значение"); ;

            }
        }

        
        public class StoreValidator : AbstractValidator<StoreEditViewModel>
        {
            public StoreValidator()
            {
                BigInteger res;
                Decimal s;
                RuleFor(store => store.ShelfLife).NotEmpty().MinimumLength(3);
                RuleFor(store => store.invoice).NotEmpty();
                RuleFor(store => store.invoice).NotEmpty();
                RuleFor(store => store.product).NotEmpty();
                RuleFor(store => store.product).NotEmpty();
                RuleFor(store => store.Count).NotEmpty().Must(count => BigInteger.TryParse(count, out res)).WithMessage("Количество должено быть числом");
                RuleFor(store => store.PricePerUnit).Must(price => Decimal.TryParse(price, out s)).WithMessage("Цена должна быть числом, следует использовать запятую, для не целых чисел");


            }
        }

     
        public class OrderValidator : AbstractValidator<OrderEditViewModel>
        {
            public OrderValidator()
            {
                RuleFor(order => order.partner).NotEmpty();
                RuleFor(order => order.CompletionDate).NotEmpty().Must(date => (date.Year >= 1975)).WithMessage("Дата имеет странное значение");

            }
        }

       
        public class SoldProductValidator : AbstractValidator<SoldProductEditViewModel>
        {
            public SoldProductValidator()
            {
                BigInteger res;
                RuleFor(soldproduct => soldproduct.store).NotEmpty();
                RuleFor(soldproduct => soldproduct.order).NotEmpty();
                RuleFor(soldproduct => soldproduct.Count).NotEmpty().Must(count => BigInteger.TryParse(count, out res)).WithMessage("Количество должно быть числом");
                RuleFor(x => x)
                .Must((model, count) => IsCountValid(Convert.ToInt32(model.Count), model.MaxCount, model.store))
                .WithMessage("Сумма товаров и количество товаров на складе не должны превышать максимальное количество.")
                .When(soldproduct => !string.IsNullOrWhiteSpace(soldproduct.Count) && BigInteger.TryParse(soldproduct.Count, out _));

                bool IsCountValid(int count, int maxCount, Store store)
                {
                    int max = 0;

                    if (store != null && store.SoldProducts != null && store.SoldProducts.Any())
                    {
                        max = store?.SoldProducts.Sum(sp => sp.Count) ?? 0;
                    }
                    else
                    {
                        max = 0;
                    }

                    int currentTotalCount = count + max;
                    return currentTotalCount <= store.Count;
                }

            }
        }


        public class SoldProductRedValidator : AbstractValidator<SoldProductEditViewModel>
        {
            public SoldProductRedValidator()
            {
                BigInteger res;
                RuleFor(soldproduct => soldproduct.store).NotEmpty();
                RuleFor(soldproduct => soldproduct.order).NotEmpty();
                RuleFor(soldproduct => soldproduct.Count).NotEmpty().Must(count => BigInteger.TryParse(count, out res)).WithMessage("Количество должено быть числом");
                RuleFor(x => x)
                .Must((model, count) => IsCountValid(Convert.ToInt32(model.Count), model.MaxCount, model.store, model.StartCount))
                .WithMessage("Сумма товаров и количество товаров на складе не должны превышать максимальное количество.")
                .When(soldproduct => !string.IsNullOrWhiteSpace(soldproduct.Count) && BigInteger.TryParse(soldproduct.Count, out _));

                bool IsCountValid(int count, int maxCount, Store store, int startcount)
                {
                    int max = 0;

                    if (store != null && store.SoldProducts != null && store.SoldProducts.Any())
                    {
                        max = store?.SoldProducts.Sum(sp => sp.Count) ?? 0;
                    }
                    else
                    {
                        max = 0;
                    }

                    int currentTotalCount = count + max - startcount;
                    return currentTotalCount <= store.Count;
                }

            }
        }


        public class UserValidator : AbstractValidator<UserEditViewModel>
        {
            public UserValidator()
            {
                RuleFor(user => user.Name).NotEmpty().MinimumLength(4);
                RuleFor(user => user.Password).NotEmpty().MinimumLength(3);

            }
        }



        public bool ConfirmInformation(string Information, string Caption) => MessageBox
           .Show(
                Information, Caption,
                MessageBoxButton.YesNo,
                MessageBoxImage.Information)
                == MessageBoxResult.Yes;

        public bool ConfirmWarning(string Warning, string Caption) => MessageBox
           .Show(
                Warning, Caption,
                MessageBoxButton.YesNo,
                MessageBoxImage.Warning)
                == MessageBoxResult.Yes;

        public bool ConfirmError(string Error, string Caption) => MessageBox
           .Show(
                Error, Caption,
                MessageBoxButton.YesNo,
                MessageBoxImage.Error)
                == MessageBoxResult.Yes;

        public ActionHandlerService(
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
            IRepository<HeadPerson> headrepsons
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
        }
    }
}
