using IMDB.ApiClient.GetAccount;

namespace IMDB.Mobile.Pages;

public partial class AppShell : Shell
{
	
	public AppShell(AppShellViewModel appShellViewModel)
	{
		InitializeComponent();
		BindingContext = appShellViewModel;
	}

}