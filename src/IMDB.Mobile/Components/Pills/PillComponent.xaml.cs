namespace IMDB.Mobile.Components.Pills;

public partial class PillComponent : ContentView
{
	public static readonly BindableProperty LabelProperty = BindableProperty.Create(nameof(Label), typeof(string), typeof(PillComponent), string.Empty);

	public string Label
	{
		get => (string)GetValue(LabelProperty);
		set => SetValue(LabelProperty, value);
	}

	public PillComponent()
	{
		InitializeComponent();
	}
}