using System;
using System.Collections.Generic;
using Xamarin.Forms;
using XamarinPokedex.Pages;

namespace XamarinPokedex
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(MainPage), typeof(MainPage));
            Routing.RegisterRoute(nameof(MyDexPage), typeof(MyDexPage));
            Routing.RegisterRoute(nameof(StatsPage), typeof(StatsPage));
        }
    }
}

