namespace IMDB.Mobile.Pages.Search;

public partial class SearchPage : ContentPage
{
	public SearchPage(SearchPageViewModel searchPageViewModel)
	{
		InitializeComponent();
		BindingContext = searchPageViewModel;
	}
}