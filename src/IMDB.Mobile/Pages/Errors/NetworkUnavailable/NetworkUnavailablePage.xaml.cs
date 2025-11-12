namespace IMDB.Mobile.Pages.Errors.NetworkUnavailable;

public partial class NetworkUnavailablePage : ContentPage
{
	public NetworkUnavailablePage(NetworkUnavailablePageViewModel networkUnavailablePageViewModel)
	{
		InitializeComponent();
		BindingContext = networkUnavailablePageViewModel;
	}
}