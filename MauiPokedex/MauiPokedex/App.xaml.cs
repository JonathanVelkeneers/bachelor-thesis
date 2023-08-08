using MonkeyCache.FileStore;

namespace MauiPokedex;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();
        Barrel.ApplicationId = "MauiPokedex";
        MainPage = new AppShell();
	}
}
