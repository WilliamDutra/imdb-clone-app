namespace IMDB.Mobile.Components.Entries;

public partial class SearchEntryComponent : ContentView
{
	public static readonly BindableProperty TextValueProperty 
		= BindableProperty.Create("TextValue", typeof(string), typeof(SearchEntryComponent), string.Empty, BindingMode.TwoWay);

	public static readonly BindableProperty PlaceHolderProperty
		= BindableProperty.Create("PlaceHolder", typeof(string), typeof(SearchEntryComponent), "Placeholder...");


	public string TextValue
	{
		get => (string)GetValue(TextValueProperty);
		set => SetValue(TextValueProperty, value);
	}

	public string PlaceHolder
	{
		get => (string)GetValue(PlaceHolderProperty);
		set => SetValue(PlaceHolderProperty, value);
	}

	public SearchEntryComponent()
	{
		InitializeComponent();
	}
}