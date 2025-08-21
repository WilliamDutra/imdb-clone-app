namespace IMDB.Mobile.Pages.MyLists.MyListDetail;

public partial class MyListDetailPage : ContentPage
{
	public MyListDetailPage(MyListDetailPageViewModel myListDetailPageViewModel)
	{
		InitializeComponent();
		BindingContext = myListDetailPageViewModel;
	}
}