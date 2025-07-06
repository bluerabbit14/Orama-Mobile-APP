using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orama.Models.ViewModels
{
    public partial class flyoutContentViewModel: ObservableObject
    {
        [ObservableProperty]
        private flyoutContent? _flyoutContent;

        [ObservableProperty]
        private ObservableCollection<flyoutContent> _flyoutContents = new ObservableCollection<flyoutContent>
        {
            
        };
    }
}
