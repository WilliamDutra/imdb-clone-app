
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace IMDB.Mobile.Components;

public partial class RatingComponent : ContentView
{
	public static readonly BindableProperty RateValueProperty
		= BindableProperty.Create("RateValue", typeof(string), typeof(RatingComponent), string.Empty);

	public static readonly BindableProperty StarsRateValueProperty
		= BindableProperty.Create("StarsRateValue", typeof(int), typeof(RatingComponent), 0, propertyChanged: OnStarsValueChanged);

    private static void OnStarsValueChanged(BindableObject bindable, object oldValue, object newValue)
    {
		var control = (RatingComponent)bindable;
		control.UpdateStars();
    }

    private void UpdateStars()
    {
        StarsRating = new ObservableCollection<int>(Enumerable.Range(1, StarsRateValue));
        OnPropertyChanged(nameof(StarsRating));
    }



    public string RateValue
	{
		get => (string)GetValue(RateValueProperty); 
		set => SetValue(RateValueProperty, value);
	}

	public int StarsRateValue
	{
		get => (int) GetValue(StarsRateValueProperty);
		set => SetValue(StarsRateValueProperty, value);
	}

    public ObservableCollection<int> StarsRating { get; set; }


    public RatingComponent()
	{
		InitializeComponent();
		BindingContext = this;
	}


}