using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
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

    static class DbContextRegistrator
    {
        public static IServiceCollection AddDataBase(this IServiceCollection services, IConfiguration Configuration) => services
            .AddDbContext<CompanyDbContext>(opt =>
            {
                opt.UseSqlServer(Configuration.GetConnectionString("MSSQL"));
                //opt.UseNpgsql(Configuration.GetConnectionString("POSTGRESQL"));
            })
            .AddTransient<DbInitializer>()
        .AddRepositoryInDb();
    }
}
