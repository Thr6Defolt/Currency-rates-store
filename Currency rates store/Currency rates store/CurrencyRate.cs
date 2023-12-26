using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Currency_rates_store
{
    public class CurrencyRate
    {
        public string Currency { get; set; }
        public decimal BuyRate { get; set; }
        public decimal SaleRate { get; set; }
    }
}
