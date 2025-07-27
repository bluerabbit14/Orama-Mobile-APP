using System.Collections.ObjectModel;
using System.Windows.Input;
using Microsoft.Maui.Graphics;

namespace Orama.Pages;

public partial class Analyse : ContentPage
{
    public ObservableCollection<HotelRevenue> RevenueData { get; set; }
    public ObservableCollection<PopulationData> CircularData { get; set; }
    public ObservableCollection<object> ChartTypes { get; set; }
    public ObservableCollection<object> Currencies{ get; set; }
    public ObservableCollection<Brush> ColorBrushes { get; set; }

    public bool IsColumnChartSelected { get; set; }
    public bool IsLineChartSelected { get; set; }
    public bool IsPieChartSelected { get; set; }
    public bool IsAreaSelected { get; set; }
    public bool IsDiscChartSelected { get; set; }

    public Analyse()
    {
        InitializeComponent();
        
        RevenueData = new ObservableCollection<HotelRevenue>
            {
                new HotelRevenue { Hotel = "Hilton", TotalGrossRev = 4200, MyGrossShare = 700, SharePercentage = "14.00" },
                new HotelRevenue { Hotel = "Marriott", TotalGrossRev = 2000, MyGrossShare = 450, SharePercentage = "12.50"},
                new HotelRevenue { Hotel = "Westin", TotalGrossRev = 2600, MyGrossShare = 550, SharePercentage = "16.00" },
                new HotelRevenue { Hotel = "Hyatt", TotalGrossRev = 3300, MyGrossShare = 650, SharePercentage = "13.33" },
                new HotelRevenue { Hotel = "Amar Vilas", TotalGrossRev = 5600, MyGrossShare = 850, SharePercentage = "18.00" },
                new HotelRevenue { Hotel = "Hilton", TotalGrossRev = 3800, MyGrossShare = 950, SharePercentage = "30.33" }
            };
        CircularData = new ObservableCollection<PopulationData>
            {
                new PopulationData { Country = "India",Totalpopulation= 10.00 }, 
                new PopulationData { Country = "America",Totalpopulation=10.00 },
                new PopulationData { Country = "Russia", Totalpopulation=6.00},
                new PopulationData { Country = "Britain",Totalpopulation=4.00},
                new PopulationData { Country = "Other",Totalpopulation=70.00},
            };
        ChartTypes = new ObservableCollection<object>
            {
                new { Name = "Column"},
                new { Name = "DoughNut"},
                new { Name = "Pie"},
                new { Name = "Area"},
                new { Name = "Line"},
            };
        Currencies= new ObservableCollection<object>
            {
                new { Currency="$"},
                new { Currency = "?"},
                new { Currency = "€"},
                new { Currency = "¥"},
                new { Currency = "£"}
            };
        ColorBrushes = new ObservableCollection<Brush>
            {
               new SolidColorBrush(Color.FromArgb("#314A6E")),
               new SolidColorBrush(Color.FromArgb("#48988B")),
               new SolidColorBrush(Color.FromArgb("#5E498C")),
               new SolidColorBrush(Color.FromArgb("#74BD6F")),
               new SolidColorBrush(Color.FromArgb("#597FCA")),
               new SolidColorBrush(Color.FromArgb("#B13BFF")),
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

public class PopulationData
{
    public string Country { get; set; }
    public double Totalpopulation { get; set; }
}