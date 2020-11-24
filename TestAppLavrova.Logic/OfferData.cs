using System;
using System.Collections.Generic;
using System.Text;

namespace TestAppLavrova.Logic
{
    public class OfferData
    {
        public string PropertyName { get; }
        public string PropertyValue { get; }

        public OfferData(string propertyName, string propertyValue)
        {
            PropertyName = propertyName;
            PropertyValue = propertyValue;
        }
    }
}
