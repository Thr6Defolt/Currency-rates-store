using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Currency_rates_store
{

    public class CurrencyDbContext : DbContext
    {
        public DbSet<CurrencyRate> CurrencyRates { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("your_connection_string");
        }
    }

}
