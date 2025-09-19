using System.Windows.Input;

namespace IMDB.Mobile.Components.Cards;

public partial class CardWithActionComponent : ContentView
{
    public static readonly BindableProperty ImageSourceProperty = BindableProperty.Create("ImageSource", typeof(ImageSource), typeof(CardWithActionComponent), default(ImageSource));

    public static readonly BindableProperty DeleteCommandProperty = BindableProperty.Create("DeleteCommand", typeof(ICommand), typeof(CardWithActionComponent), default(ICommand));

    public static readonly BindableProperty IdProperty = BindableProperty.Create("Id", typeof(int), typeof(CardWithActionComponent), default(int));

    public static readonly BindableProperty TitleProperty = BindableProperty.Create("Title", typeof(string), typeof(CardWithActionComponent), string.Empty);

    public ImageSource ImageSource
    {
        get => (ImageSource)GetValue(ImageSourceProperty);
        set => SetValue(ImageSourceProperty, value);
    }

    public ICommand DeleteCommand
    {
        get => (ICommand)GetValue(DeleteCommandProperty);
        set => SetValue(DeleteCommandProperty, value);
    }

    public int Id
    {
        get => (int)GetValue(IdProperty);
        set => SetValue(IdProperty, value);
    }

    public string Title
    {
        get => (string)GetValue(TitleProperty);
        set => SetValue(TitleProperty, value);
    }

    public CardWithActionComponent()
    {
        InitializeComponent();
    }
}