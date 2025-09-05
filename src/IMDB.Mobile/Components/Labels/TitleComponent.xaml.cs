namespace IMDB.Mobile.Components.Labels;

public partial class TitleComponent : ContentView
{

	public static readonly BindableProperty TextValueProperty = BindableProperty.Create(nameof(TextValue), typeof(string), typeof(TitleComponent), string.Empty);

	public static readonly BindableProperty IsLoadingProperty = BindableProperty.Create(nameof(IsLoading), typeof(bool), typeof(TitleComponent), default(bool));

	public string TextValue
	{
		get => (string)GetValue(TextValueProperty);
		set => SetValue(TextValueProperty, value);
	}

	public bool IsLoading
	{
		get => (bool)GetValue(IsLoadingProperty);
		set => SetValue(IsLoadingProperty, value);
	}

	public TitleComponent()
	{
		InitializeComponent();
	}
}