using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace XamarinPokedex.Models
{
    public class ChartDataModel
    {
        public string Label { get; set; }

        public string Key { get; set; }
        public double Value { get; set; }

        public ChartDataModel(string label, string key, double value)
        {
            Label = label;
            Key = key;
            Value = value;
        }
    }
}
