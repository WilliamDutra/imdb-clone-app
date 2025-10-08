using CommunityToolkit.Maui.Views;

namespace IMDB.Mobile.Popups.ConfirmDeleteMyList;

public partial class ConfirmDeleteMyListPopup : Popup
{
	public ConfirmDeleteMyListPopup(ConfirmDeleteMyListPopupViewModel confirmDeleteMyListPopupViewModel)
	{
		InitializeComponent();
		BindingContext = confirmDeleteMyListPopupViewModel;
	}
}