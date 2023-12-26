using Microsoft.EntityFrameworkCore;
using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Currency_rates_store
{
    internal class Program
    {
        static async Task Main()
        {
            try
            {
                var currencyRates = await GetCurrencyRatesAsync();

                using (var dbContext = new CurrencyDbContext())
                {
                    dbContext.Database.ExecuteSqlRaw("DELETE FROM CurrencyRates");

                    dbContext.CurrencyRates.AddRange(currencyRates);
                    dbContext.SaveChanges();
                }

                Console.WriteLine("Дані успішно оновлено в базі даних.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Помилка: {ex.Message}");
            }
        }

        static async Task<CurrencyRate[]> GetCurrencyRatesAsync()
        {
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetStringAsync("https://api.privatbank.ua/p24api/pubinfo?exchange&coursid=5");
                var currencyRates = JsonSerializer.Deserialize<CurrencyRate[]>(response);

                return currencyRates;
            }
        }
    }
}