using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Orama.Pages;

public partial class Analyse : ContentPage
{
    public ObservableCollection<HotelRevenue> RevenueData { get; set; }
    public ObservableCollection<Brush> ColorBrushes { get; set; }

    public Analyse()
    {
        InitializeComponent();
      
        RevenueData = new ObservableCollection<HotelRevenue>
            {
                new HotelRevenue { Hotel = "Hilton", TotalGrossRev = 4200, MyGrossShare = 700, SharePercentage = "14.00" },
                new HotelRevenue { Hotel = "Marriott", TotalGrossRev = 2000, MyGrossShare = 450, SharePercentage = "12.50"},
                new HotelRevenue { Hotel = "Westin", TotalGrossRev = 2600, MyGrossShare = 550, SharePercentage = "16.00" },
                new HotelRevenue { Hotel = "Hyatt", TotalGrossRev = 3300, MyGrossShare = 650, SharePercentage = "13.33" }
            };
        ColorBrushes = new ObservableCollection<Brush>
            { 
               new SolidColorBrush(Colors.Green),
               new SolidColorBrush(Colors.Pink),
            };
        
        // Set binding context to this page
        BindingContext = this;
        
    }   
}

public class HotelRevenue
{
    public string Hotel { get; set; }
    public double TotalGrossRev { get; set; }
    public double MyGrossShare { get; set; }
    public string SharePercentage { get; set; }
}