using System;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Text.Json;
using System.Xml;

namespace TestAppLavrova.Logic
{
    public class OfferService
    {
        private const string urlString = "http://partner.market.yandex.ru/pages/help/YML.xml";

        public async Task<Offer[]> GetOffersAsync()
        {
            HttpClient client = new HttpClient();
            
            var data = await client.GetByteArrayAsync(urlString);
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            var dataString = Encoding.GetEncoding(1251).GetString(data);

            XmlReader reader = XmlReader.Create(new StringReader(dataString),
                new XmlReaderSettings()
                {
                    DtdProcessing = DtdProcessing.Ignore
                });

            var catalog = XElement.Load(reader);
            Offer[] offers = (from offer in catalog.Descendants("offer")
                select ParseToOfferModel(offer)).ToArray();
            return offers;
        }

        private Offer ParseToOfferModel(XElement offerX)
        {
            Offer parsedOffer = new Offer();
            parsedOffer.Id = ParseIntData(offerX, "id");
            parsedOffer.Type = (string) offerX.Attribute("type");
            parsedOffer.Bid = ParseIntData(offerX, "bid");
            parsedOffer.Cbid = ParseIntData(offerX, "cbid");
            parsedOffer.Available = (bool) offerX.Attribute("available");
            foreach (XElement element in offerX.Descendants())
                parsedOffer.Data.Add(new OfferData(element.Name.ToString(), element.Value));
            return parsedOffer;
        }

        private int ParseIntData(XElement offerX, string attributeName)
        {
            string value = (string) offerX.Attribute(attributeName);
            if (String.IsNullOrEmpty(value))
                return 0;

            return Int32.Parse(value);
        }
    }
}