using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using System;
using System.Linq;
using Android.Content;
using Newtonsoft.Json;
using TestAppLavrova.Logic;


namespace TestAppLavrova
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : ListActivity
    {
        readonly OfferService _service = new OfferService();
        private Offer[] _offers;  
        protected override async void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            _offers = (await _service.GetOffersAsync());
            string[] offersIds = _offers.Select(offer => offer.Id.ToString()).ToArray();

            ListAdapter = new ArrayAdapter<string> (this, Resource.Layout.list_item, offersIds);

            ListView.TextFilterEnabled = true;

            ListView.ItemClick += ListView_ItemClick;
        }

        private void ListView_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            var offerDetail = new Intent(this, typeof(DetailedInformationActivity));
            Offer selectedOffer = _offers.FirstOrDefault(o =>
                o.Id.ToString() == Convert.ToString(ListView.GetItemAtPosition(e.Position)));
            offerDetail.PutExtra("offerDetail", JsonConvert.SerializeObject(selectedOffer, Formatting.Indented));
            StartActivity(offerDetail);
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}