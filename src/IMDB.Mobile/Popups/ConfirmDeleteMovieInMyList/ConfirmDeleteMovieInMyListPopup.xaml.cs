using CommunityToolkit.Maui.Views;

namespace IMDB.Mobile.Popups.ConfirmDeleteMovieInMyList;

public partial class ConfirmDeleteMovieInMyListPopup : Popup
{
	public ConfirmDeleteMovieInMyListPopup(ConfirmDeleteMovieInMyListPopupViewModel confirmDeleteMovieInMyListPopupViewModel)
	{
		InitializeComponent();
		BindingContext = confirmDeleteMovieInMyListPopupViewModel;
    }
}