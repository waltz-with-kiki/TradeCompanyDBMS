using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradeCompany.DAL.Context;
using TradeCompany.DAL.Interfaces;
using TradeCompany.DAL.Repositories;
using TradeCompany.Domain.Model;

namespace TradeCompany.Services
{
    public static class RepositoryRegistrator
    {

        public static IServiceCollection AddRepositoryInDb(this IServiceCollection services) => services
            .AddTransient<IRepository<Structure>, DbRepository<Structure>>()
            .AddTransient<IRepository<Right>, RightRepository>()
            .AddTransient<IRepository<User>, UsersRepository>()
            .AddTransient<IRepository<SoldProduct>, SoldProductsRepository>()
            .AddTransient<IRepository<Order>, OrderRepository>()
            .AddTransient<IRepository<Store>, StoreRepository>()
            .AddTransient<IRepository<Invoice>, InvoiceRepository>()
            .AddTransient<IRepository<Product>, ProductRepository>()
            .AddTransient<IRepository<AccountingUnit>, DbRepository<AccountingUnit>>()
            .AddTransient<IRepository<Manufacturer>, DbRepository<Manufacturer>>()
            .AddTransient<IRepository<Group>, DbRepository<Group>>()
            .AddTransient<IRepository<Partner>, PartnerRepository>()
            .AddTransient<IRepository<Bank>, DbRepository<Bank>>()
            .AddTransient<IRepository<Country>, DbRepository<Country>>()
            .AddTransient<IRepository<HeadPerson>, DbRepository<HeadPerson>>()


            ;
    }


    class RightRepository : DbRepository<Right>
    {

        public override IQueryable<Right> Items => base.Items.Include(item => item.User);

        public RightRepository(CompanyDbContext db) : base(db)
        {
        }
    }


    class PartnerRepository : DbRepository<Partner>
    {

        public override IQueryable<Partner> Items => base.Items.Include(item => item.Bank).Include(item => item.Country).Include(item => item.HeadPerson);

        public PartnerRepository(CompanyDbContext db) : base(db)
        {
        }
    }

    class ProductRepository : DbRepository<Product>
    {

        public override IQueryable<Product> Items => base.Items.Include(item => item.AccountingUnit).Include(item => item.Manufacturer).Include(item => item.Group);

        public ProductRepository(CompanyDbContext db) : base(db)
        {
        }
    }

    class InvoiceRepository : DbRepository<Invoice>
    {

        public override IQueryable<Invoice> Items => base.Items.Include(item => item.Partner);

        public InvoiceRepository(CompanyDbContext db) : base(db)
        {
        }
    }

    class StoreRepository : DbRepository<Store>
    {

        public override IQueryable<Store> Items => base.Items.Include(item => item.Invoice).Include(item => item.Product);

        public StoreRepository(CompanyDbContext db) : base(db)
        {
        }
    }

    class OrderRepository : DbRepository<Order>
    {

        public override IQueryable<Order> Items => base.Items.Include(item => item.Partner);

        public OrderRepository(CompanyDbContext db) : base(db)
        {
        }
    }

    class SoldProductsRepository : DbRepository<SoldProduct>
    {

        public override IQueryable<SoldProduct> Items => base.Items.Include(item => item.Order).Include(item => item.Store);

        public SoldProductsRepository(CompanyDbContext db) : base(db)
        {
        }
    }

    class UsersRepository : DbRepository<User>
    {

        public override IQueryable<User> Items => base.Items.Include(item => item.Rights);

        public UsersRepository(CompanyDbContext db) : base(db)
        {
        }
    }
}

