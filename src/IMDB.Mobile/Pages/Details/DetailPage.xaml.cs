namespace IMDB.Mobile.Pages.Details;

public partial class DetailPage : ContentPage
{
	public DetailPage(DetailPageViewModel detailPageViewModel)
	{
		InitializeComponent();
		BindingContext = detailPageViewModel;
	}
}