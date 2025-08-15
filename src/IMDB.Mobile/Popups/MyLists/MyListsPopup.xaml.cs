using CommunityToolkit.Maui.Views;

namespace IMDB.Mobile.Popups.MyLists;

public partial class MyListsPopup : Popup
{
	public MyListsPopup(MyListsPopupViewModel myListsPopupViewModel)
	{
		InitializeComponent();
		BindingContext = myListsPopupViewModel;
	}
}