using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using MyWallet_2._0.Models;

namespace MyWallet_2._0
{
    class ApplicationContext : DbContext
    {
        public DbSet<User> Users {get; set;}

        public DbSet<Total> Totals { get; set; }

        public DbSet<UserSpend> UserSpends { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<UserIncome> UserIncomes { get; set; }

        public DbSet<IncomeCategory> IncomeCategories { get; set; }

        public DbSet<Image> Images { get; set; }

        public ApplicationContext() : base("DefaultConnection") { }





    }
}
