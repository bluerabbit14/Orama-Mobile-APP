using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orama.Utility
{
    class AppStatus
    {
        public bool IsLoggedIn { get; set; }
        public bool IsFirstRun { get; set; }
        public bool IsOnboardingComplete { get; set; }
        public bool IsNotificationsEnabled { get; set; }
        public bool IsLocationEnabled { get; set; }
        public bool IsNetworkAvailable { get; set; }
        public Theme Theme { get; set; }
    }
    enum Theme
    {
        Light,
        Dark,
        SystemDefault
    }
}
