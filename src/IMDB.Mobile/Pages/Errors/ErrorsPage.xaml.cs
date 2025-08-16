namespace IMDB.Mobile.Pages.Errors;

public partial class ErrorsPage : ContentPage
{
	public ErrorsPage(ErrorsPageViewModel errorsPageViewModel)
	{
		InitializeComponent();
		BindingContext = errorsPageViewModel;
	}
}