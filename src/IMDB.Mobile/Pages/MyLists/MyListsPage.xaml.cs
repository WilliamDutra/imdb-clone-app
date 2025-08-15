namespace IMDB.Mobile.Pages.MyLists;

public partial class MyListsPage : ContentPage
{
	public MyListsPage(MyListsPageViewModel myListsPageViewModel)
	{
		InitializeComponent();
		BindingContext = myListsPageViewModel;
	}
}