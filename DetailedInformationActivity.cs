using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestAppLavrova.Logic;

namespace TestAppLavrova
{
    [Activity(Label = "DetailedInformationActivity")]
    public class DetailedInformationActivity : Activity
    {
        OfferService service = new OfferService();
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            var data = Intent.GetStringExtra("offerDetail");
            SetContentView(Resource.Layout.offer_detail);
            FindViewById<TextView>(Resource.Id.detailTextView).Text = data;
        }
    }
}