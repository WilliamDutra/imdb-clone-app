namespace IMDB.Mobile.Components.Labels;

public partial class TitleComponent : ContentView
{

	public static readonly BindableProperty TextValueProperty = BindableProperty.Create(nameof(TextValue), typeof(string), typeof(TitleComponent), string.Empty);

	public string TextValue
	{
		get => (string)GetValue(TextValueProperty);
		set => SetValue(TextValueProperty, value);
	}

	public TitleComponent()
	{
		InitializeComponent();
	}
}