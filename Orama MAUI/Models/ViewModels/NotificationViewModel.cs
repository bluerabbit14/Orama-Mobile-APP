using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orama.Models.ViewModels
{
    public partial class NotificationViewModel: ObservableObject
    {
        public NotificationViewModel()
        {
            
        }

        [ObservableProperty]
        private ObservableCollection<NotificationModel> _notificationlist = new ObservableCollection<NotificationModel>
        {
            new NotificationModel{
                Id=1,
                profilePic="profile.png",
                senderName="Asif Abbas",
                description="sample text for sample notification",
                type="Important",
                createdAt=DateTime.UtcNow,
                IsRead=false
            },
            new NotificationModel{
                Id=2,
                profilePic="profile.png",
                senderName="Asif Abbas",
                description="sample text for sample notification",
                type="Important",
                createdAt=DateTime.UtcNow,
                IsRead=false
            },
            new NotificationModel{
                Id=3,
                profilePic="profile.png",
                senderName="Asif Abbas",
                description="sample text for sample notification",
                type="Services",
                createdAt=DateTime.UtcNow,
                IsRead=false
            },
            new NotificationModel{
                Id=4,
                profilePic="profile.png",
                senderName="Asif Abbas",
                description="sample text for sample notification",
                type="Services",
                createdAt=DateTime.UtcNow,
                IsRead=false
            },
        };
    }
}
