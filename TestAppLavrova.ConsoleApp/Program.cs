using Newtonsoft.Json;
using System;
using System.Linq;
using System.Threading.Tasks;
using TestAppLavrova.Logic;

namespace TestAppLavrova.ConsoleApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            OfferService service = new OfferService();
            Offer[] g = await service.GetOffersAsync();
            Console.WriteLine(g.Length);
            foreach (string id in g.Select(offer => offer.Id.ToString()).ToArray())
                Console.WriteLine(id);
            Console.WriteLine(JsonConvert.SerializeObject(g[0], Formatting.Indented));
        }
    }
}
