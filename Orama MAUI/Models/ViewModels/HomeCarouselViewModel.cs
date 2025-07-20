using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Orama.Models;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orama.Models.ViewModels
{
    partial class HomeCarouselViewModel : ObservableObject
    {
        [ObservableProperty]
        private ObservableCollection<CarouselModel> _carouselItems = new ObservableCollection<CarouselModel>
        {
            new CarouselModel{Title="",Description="",ImageUrl="https://i.postimg.cc/k6mwwqLt/YourName.jpg",LinkUrl=""},
            new CarouselModel{Title="",Description="",ImageUrl="https://i.postimg.cc/BPZp9NSS/weathering-With-You.jpg",LinkUrl=""},
            new CarouselModel{Title="",Description="",ImageUrl="https://i.postimg.cc/hJxp9fZB/OnePiece.jpg",LinkUrl=""},
            new CarouselModel{Title="",Description="",ImageUrl="https://i.postimg.cc/Q9JmyvrY/Demon-Slayer.jpg",LinkUrl=""},
            new CarouselModel{Title="",Description="",ImageUrl="https://i.postimg.cc/dLHHvMZz/Chainsaw-Man.jpg",LinkUrl=""},
        };
    }
}
