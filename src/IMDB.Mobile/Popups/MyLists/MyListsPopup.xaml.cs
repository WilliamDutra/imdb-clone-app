using CommunityToolkit.Maui.Views;
using Plugin.Maui.BottomSheet;

namespace IMDB.Mobile.Popups.MyLists;

public partial class MyListsPopup : BottomSheet
{
	public MyListsPopup(MyListsPopupViewModel myListsPopupViewModel)
	{
		InitializeComponent();
		BindingContext = myListsPopupViewModel;
	}
}