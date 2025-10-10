using System.ComponentModel;
using System.Windows.Input;

namespace IMDB.Mobile.Components.Pills;

public partial class PillToggleComponent : ContentView
{

    public static readonly BindableProperty LabelProperty = BindableProperty.Create("Label", typeof(string), typeof(PillToggleComponent), string.Empty);

    public static readonly BindableProperty IdProperty = BindableProperty.Create("Id", typeof(int), typeof(PillToggleComponent), default(int));

    public static readonly BindableProperty IsPressedCommandProperty = BindableProperty.Create("IsPressedCommand", typeof(ICommand), typeof(PillToggleComponent), default(ICommand));

    public static readonly BindableProperty IsPressedCommandParameterProperty = BindableProperty.Create("IsPressedCommandParameter", typeof(ICommand), typeof(PillToggleComponent), default(ICommand));

    public static readonly BindableProperty IsPressedProperty = BindableProperty.Create("IsPressed", typeof(bool), typeof(PillToggleComponent), default(bool));

    public string Label 
	{ 
		get => (string)GetValue(LabelProperty); 
		set => SetValue(LabelProperty, value);
	}

    public int Id
    {
        get => (int)GetValue(IdProperty);
        set => SetValue(IdProperty, value);
    }

    public bool IsPressed
    {
        get => (bool)GetValue(IsPressedProperty);
        set => SetValue(IsPressedProperty, value);
    }

    public ICommand IsPressedCommand
    {
        get => (ICommand)GetValue(IsPressedCommandProperty);
        set => SetValue(IsPressedCommandProperty, value);
    }

    public ICommand IsPressedCommandParameter
    {
        get => (ICommand)GetValue(IsPressedCommandParameterProperty);
        set => SetValue(IsPressedCommandParameterProperty, value);
    }

    public PillToggleComponent()
	{
		InitializeComponent();
	}

    private void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
        IsPressed = !IsPressed;
    }

}