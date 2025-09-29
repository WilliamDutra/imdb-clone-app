namespace IMDB.Mobile.Pages.ActorDetails;

public partial class ActorDetailPage : ContentPage
{
	public ActorDetailPage(ActorDetailPageViewModel actorDetailPageViewModel)
	{
		InitializeComponent();
		BindingContext = actorDetailPageViewModel;
	}
}