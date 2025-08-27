namespace IMDB.Mobile.Components.Cards;

public partial class CardViewActorComponent : ContentView
{
	public static readonly BindableProperty PhotoProperty = BindableProperty.Create("Photo", typeof(ImageSource), typeof(CardViewActorComponent), null);

	public static readonly BindableProperty NameProperty = BindableProperty.Create("Name", typeof(string), typeof(CardViewActorComponent), null);

	public static readonly BindableProperty CardWidthProperty = BindableProperty.Create("CardWidth", typeof(double), typeof(CardViewActorComponent), default(double));

	public static readonly BindableProperty CardHeightProperty = BindableProperty.Create("CardHeight", typeof(double), typeof(CardViewActorComponent), default(double));

    public ImageSource Photo 
	{
		get => (ImageSource)GetValue(PhotoProperty); 
		set => SetValue(PhotoProperty, value);
	}

	public string Name
	{
		get => (string)GetValue(NameProperty);
		set => SetValue(NameProperty, value);
	}

	public double CardWidth
	{
		get => (double)GetValue(CardWidthProperty); 
		set => SetValue(CardWidthProperty, value);
	}

	public double CardHeight
	{
		get => (double)GetValue(CardHeightProperty); 
		set => SetValue(CardHeightProperty, value);
	}

    public CardViewActorComponent()
	{
		InitializeComponent();
	}
}