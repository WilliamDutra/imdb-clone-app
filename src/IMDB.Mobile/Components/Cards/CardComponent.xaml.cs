namespace IMDB.Mobile.Components.Cards;

public partial class CardComponent : ContentView
{
	public static readonly BindableProperty TitleProperty = BindableProperty.Create("Title", typeof(string), typeof(CardComponent), string.Empty);

	public static readonly BindableProperty ImageProperty = BindableProperty.Create("Image", typeof(string), typeof (CardComponent), string.Empty);

	public string Title
	{
		get => (string)GetValue(TitleProperty);
		set => SetValue(TitleProperty, value);
	}

	public string Image
	{
		get => (string)GetValue(ImageProperty);
		set => SetValue(ImageProperty, value);
	}

	public CardComponent()
	{
		InitializeComponent();
	}
}