using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orama.Models.ViewModels
{
    public partial class FlyoutContentViewModel: ObservableObject
    {
        public FlyoutContentViewModel()
        {
            
        }
        

        [ObservableProperty]
        private ObservableCollection<FlyoutModel> _flyoutContents = new ObservableCollection<FlyoutModel>
        {
            new FlyoutModel{ 
                Icon="home.png", 
                Icon_dark="home_light.png",
                Title="Home", 
                FontSize=20,
                ImageSize=22,
                Separator=false
            },
            new FlyoutModel{
                Icon="orama.png",
                Icon_dark="orama_dark.png",
                Title="Premium",
                FontSize=20,
                ImageSize=22,
                Separator=false
            },
             new FlyoutModel{
                Icon="search.png",
                Icon_dark="search_dark.png",
                Title="Search",
                FontSize=20,
                ImageSize=24,
                Separator=false
            },
            new FlyoutModel{
                Icon="notification.png",
                Icon_dark="notification_light.png",
                Title="Notification",
                FontSize=16,
                ImageSize=20,
                Separator=true
            },
            new FlyoutModel{
                Icon="support.png",
                Icon_dark="support_light.png",
                Title="Support",
                FontSize=16,
                ImageSize=20,
                Separator=false
            },
            new FlyoutModel{
                Icon="policy.png",
                Icon_dark="policy_light.png",
                Title="Policy",
                FontSize=16,
                ImageSize=21,
                Separator=false
            },
            new FlyoutModel{
                Icon="about.png",
                Icon_dark="about_light.png",
                Title="About Us",
                FontSize=16,
                ImageSize=19,
                Separator=false
            },
            new FlyoutModel{
                Icon="setting.png",
                Icon_dark="setting_light.png",
                Title="Setting",
                FontSize=16,
                ImageSize=20,
                Separator=false
            }
            
        };

    }
}
