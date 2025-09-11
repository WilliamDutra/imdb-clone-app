namespace IMDB.Mobile.Components.Cards;

public partial class CardSkeletonComponent : ContentView
{
    public static readonly BindableProperty CardWidthProperty = BindableProperty.Create("CardWidth", typeof(double), typeof(CardComponent), default(double));

    public static readonly BindableProperty CardHeightProperty = BindableProperty.Create("CardHeight", typeof(double), typeof(CardComponent), default(double));

    public new double CardWidth
    {
        get => (double)GetValue(CardWidthProperty);
        set => SetValue(CardWidthProperty, value);
    }

    public new double CardHeight
    {
        get => (double)GetValue(CardHeightProperty);
        set => SetValue(CardHeightProperty, value);
    }
    public CardSkeletonComponent()
	{
		InitializeComponent();
	}
}