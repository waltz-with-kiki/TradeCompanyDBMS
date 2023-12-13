using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradeCompany.DAL.Context;
using TradeCompany.Domain.Model;
using TradeCompany.Hash;

namespace TradeCompany.Services
{
    internal class DbInitializer
    {
        private readonly CompanyDbContext _db;

        public DbInitializer(CompanyDbContext db)
        {
            _db = db;
        }

        public async Task InitializeAsync()
        {

            await _db.Database.MigrateAsync().ConfigureAwait(false);

            if (await _db.Users.AnyAsync()) return;

            await InitializeStructures();
            //await InitializeRights();
            await InitializeUsers();


        }

        private Structure[] Structures;
        private Structure[] catalogs;

        private async Task InitializeStructures()
        {
            Structures = new Structure[] {
                new Structure { Name = "Партнёры", function = "catalogPartners", number = 1, },
                new Structure { Name = "Заказы", function = "catalogOrders", number = 2, },
                new Structure { Name = "Накладные", function = "catalogInvoces", number = 3, },
                new Structure { Name = "Резерв", function = "catalogStores", number = 4, },
                new Structure { Name = "Проданные продукты", function = "catalogSoldProducts", number = 5, },
                new Structure { Name = "Продукты", function = "catalogProducts", number = 6, },
                new Structure { Name = "Руководители", function = "catalogHeadPersons", number = 7, },
                new Structure { Name = "Справочники", number = 8, },
                new Structure { Name = "Документы", function = "catalogDocs", number = 9, },

                new Structure { Name = "Смена пароля", function = "catalogChangePass", number = 10, },

                new Structure { Name = "Справка", function = "catalogRef", number = 11, },

                new Structure { Name = "Панель Администратора", function = "catalogUsers", number = 12}




        };

            catalogs = new Structure[]
            {
                new Structure { Name = "Единицы измерения", function = "catalogAccountingUnits", number = 0, ParentStructure = Structures[7]},
                new Structure { Name = "Производители", function = "catalogManufacturers", number = 0, ParentStructure = Structures[7]},

            new Structure { Name = "Группы продуктов", function = "catalogGroups", number = 0, ParentStructure = Structures[7]},

            new Structure { Name = "Страны", function = "catalogCountries", number = 0, ParentStructure = Structures[7]},

            new Structure { Name = "Банки", function = "catalogBanks", number = 0, ParentStructure = Structures[7]}


        };


            await _db.Structures.AddRangeAsync(Structures);
            await _db.Structures.AddRangeAsync(catalogs);
            await _db.SaveChangesAsync();

        }



        private User[] Users;

        private async Task InitializeUsers()
        {

            Users = new User[]{
                           new User
                    {
                        Name = "Admin",
                        Password = md5.hashPassword("1234"),
                        Rights = new List<Right>
                        {
                             new Right { R = true, W = true, E = true, D = true, Form = FormType.AdminForm},
                             new Right { R = true, W = true, E = true, D = true, Form = FormType.OrderForm},
                             new Right { R = true, W = true, E = true, D = true, Form = FormType.InvoiceForm},
                             new Right { R = true, W = true, E = true, D = true, Form = FormType.PartnerForm},
                             new Right { R = true, W = true, E = true, D = true, Form = FormType.SoldProductForm},
                             new Right { R = true, W = true, E = true, D = true, Form = FormType.StoreForm},
                             new Right { R = true, W = true, E = true, D = true, Form = FormType.ProductForm},
                             new Right { R = true, W = true, E = true, D = true, Form = FormType.HeadPersonForm},
                             new Right { R = true, W = true, E = true, D = true, Form = FormType.BankForm},
                             new Right { R = true, W = true, E = true, D = true, Form = FormType.CountryForm},
                             new Right { R = true, W = true, E = true, D = true, Form = FormType.GroupForm},
                             new Right { R = true, W = true, E = true, D = true, Form = FormType.ManufacturerForm},
                             new Right { R = true, W = true, E = true, D = true, Form = FormType.AccountingUnitForm},
                        }
                    },
                    new User
                    {
                        Name = "User",
                        Password = md5.hashPassword("1234"),
                        Rights = new List<Right>
                        {
                             new Right { R = false, W = false, E = false, D = false, Form = FormType.AdminForm},
                             new Right { R = true, W = false, E = false, D = false, Form = FormType.OrderForm},
                             new Right { R = true, W = false, E = false, D = false, Form = FormType.InvoiceForm},
                             new Right { R = true, W = false, E = false, D = false, Form = FormType.PartnerForm},
                             new Right { R = true, W = false, E = false, D = false, Form = FormType.SoldProductForm},
                             new Right { R = true, W = false, E = false, D = false, Form = FormType.StoreForm},
                             new Right { R = true, W = false, E = false, D = false, Form = FormType.ProductForm},
                             new Right { R = true, W = false, E = false, D = false, Form = FormType.HeadPersonForm},
                             new Right { R = true, W = false, E = false, D = false, Form = FormType.BankForm},
                             new Right { R = true, W = false, E = false, D = false, Form = FormType.CountryForm},
                             new Right { R = true, W = false, E = false, D = false, Form = FormType.GroupForm},
                             new Right { R = true, W = false, E = false, D = false, Form = FormType.ManufacturerForm},
                             new Right { R = true, W = false, E = false, D = false, Form = FormType.AccountingUnitForm},
                        }
                    },

            };

            await _db.Users.AddRangeAsync(Users);
            await _db.SaveChangesAsync();


        }


    }
}
