namespace IMDB.Mobile.Pages.MoviesByGenres;

public partial class MoviesByGenresPage : ContentPage
{
	public MoviesByGenresPage(MoviesByGenresPageViewModel moviesByGenresPageViewModel)
	{
		InitializeComponent();
		BindingContext = moviesByGenresPageViewModel;
	}
}