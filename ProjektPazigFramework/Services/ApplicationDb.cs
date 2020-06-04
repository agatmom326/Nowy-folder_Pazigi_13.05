using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Text.RegularExpressions;
using ProjektPazigFramework.Model;

namespace ProjektPazigFramework.Services
{
    class ApplicationDb :DbContext
    {
        public ApplicationDb() : base("name=DefaultConnection")
        {
            //Database.SetInitializer(new ApplicationDbInitializer());
        }
        public DbSet<Person> People { get; set; }
        public DbSet<ProjektPazigFramework.Model.Group> Groups { get; set; }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<Debtor> Debtors { get; set; }
        public DbSet<Debet> Debets { get; set; }


    }
}

    
