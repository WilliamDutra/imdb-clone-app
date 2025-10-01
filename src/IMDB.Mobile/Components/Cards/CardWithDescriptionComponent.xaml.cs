using System.Collections.ObjectModel;

namespace IMDB.Mobile.Components.Cards;

public partial class CardWithDescriptionComponent : ContentView
{
    public static readonly BindableProperty TitleProperty = BindableProperty.Create("Title", typeof(string), typeof(CardComponent), string.Empty);

    public static readonly BindableProperty ImageProperty = BindableProperty.Create("Image", typeof(ImageSource), typeof(CardComponent), null);

    public static readonly BindableProperty RatingProperty = BindableProperty.Create("Rating", typeof(string), typeof(CardComponent), string.Empty);

    public static readonly BindableProperty DescriptionProperty = BindableProperty.Create("Description", typeof(string), typeof(CardComponent), string.Empty);

    public static readonly BindableProperty CardWidthProperty = BindableProperty.Create("CardWidth", typeof(int), typeof(CardWithDescriptionComponent), default(int));

    public static readonly BindableProperty CardHeightProperty = BindableProperty.Create("CardHeight", typeof(int), typeof(CardWithDescriptionComponent), default(int));

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

    public string Description
    {
        get => (string)GetValue(DescriptionProperty);
        set => SetValue(DescriptionProperty, value);
    }

    public int CardHeight
    {
        get => (int)GetValue(CardHeightProperty);
        set => SetValue(CardHeightProperty, value);
    }

    public int CardWidth
    {
        get => (int)GetValue(CardWidthProperty);
        set => SetValue(CardWidthProperty, value);
    }
    public CardWithDescriptionComponent()
	{
		InitializeComponent();
	}

}