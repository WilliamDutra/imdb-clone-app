using System.Windows.Input;

namespace IMDB.Mobile.Components.Cards;

public partial class CardComponent : ContentView
{
	public static readonly BindableProperty TitleProperty = BindableProperty.Create("Title", typeof(string), typeof(CardComponent), string.Empty);

	public static readonly BindableProperty ImageProperty = BindableProperty.Create("Image", typeof(ImageSource), typeof (CardComponent), null);

    public static readonly BindableProperty RatingProperty = BindableProperty.Create("Rating", typeof(string), typeof(CardComponent), string.Empty);

	public static readonly BindableProperty AddToListCommandProperty = BindableProperty.Create("AddToListCommand", typeof(ICommand), typeof(CardComponent));

	public static readonly BindableProperty AddToListCommandParameterProperty = BindableProperty.Create("AddToListCommandParameter", typeof(object), typeof(CardComponent), default(object));

    public string Title
	{
		get => (string)GetValue(TitleProperty);
		set => SetValue(TitleProperty, value);
	}

	public ImageSource Image
	{
		get => (ImageSource)GetValue(ImageProperty);
		set => SetValue(ImageProperty, value);
	}

    public string Rating
    {
        get => (string)GetValue(RatingProperty);
        set => SetValue(RatingProperty, value);
    }

	public ICommand AddToListCommand
	{
		get => (ICommand)GetValue(AddToListCommandProperty);
		set => SetValue(AddToListCommandProperty, value);
	}

	public object AddToListCommandParameter
	{
		get => (object)GetValue(AddToListCommandParameterProperty);
		set => SetValue(AddToListCommandParameterProperty, value);
	}

    public CardComponent()
	{
		InitializeComponent();
	}
}