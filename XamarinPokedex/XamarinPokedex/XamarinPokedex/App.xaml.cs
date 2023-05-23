using System;
using MonkeyCache.FileStore;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinPokedex
{
    public partial class App : Application
    {

        public App ()
        {
            InitializeComponent();
            Barrel.ApplicationId = "XamarinPokedex";
            MainPage = new AppShell();
        }

        protected override void OnStart ()
        {
        }

        protected override void OnSleep ()
        {
        }

        protected override void OnResume ()
        {
        }
    }
}

