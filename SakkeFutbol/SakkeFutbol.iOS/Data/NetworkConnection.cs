using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CoreFoundation;
using Foundation;
using SakkeFutbol.Data;
using SakkeFutbol.iOS.Data;
using SystemConfiguration;
using UIKit;
using Xamarin.Forms;

[assembly: Dependency(typeof(NetworkConnection))]

namespace SakkeFutbol.iOS.Data
{
    class NetworkConnection : INetworkConnection
    {
        public bool IsConnected { get; set; }
        public void CheckNetworkConnection()
        {
            InternetStatus();
        }

        private bool InternetStatus()
        {
            NetworkReachabilityFlags flags;
            bool defaultNetworkAvailable = IsNetworkAvailable(out flags);
            if (defaultNetworkAvailable && ((flags & NetworkReachabilityFlags.IsDirect) != 0))
            {
                return false;
            }
            else if ((flags & NetworkReachabilityFlags.IsWWAN) != 0)
            {
                return true;
            }
            else if(flags == 0)
            {
                return false;
            }
            return true;
        }

        private event EventHandler ReachabilityChanged;
        private void OnChange(NetworkReachabilityFlags flags)
        {
            var h = ReachabilityChanged;
            if (h != null)
            {
                h(null, EventArgs.Empty);
            }
        }
        private NetworkReachability defaultReachability;
        private bool IsNetworkAvailable(out NetworkReachabilityFlags flags)
        {
            if (defaultReachability == null)
            {
                var ipAddress = new System.Net.IPAddress(0);
                defaultReachability = new NetworkReachability(ipAddress);
                defaultReachability.SetNotification(OnChange);
                defaultReachability.Schedule(CFRunLoop.Current, CFRunLoop.ModeDefault);
                
            }
            if(!defaultReachability.TryGetFlags(out flags))
            {
                return false;
            }
            return IsReachableWithOutRequiringConnection(flags);
        }

        private bool IsReachableWithOutRequiringConnection(NetworkReachabilityFlags flags)
        {
            bool IsReachable = (flags & NetworkReachabilityFlags.Reachable) != 0;
            bool noConnectionRequired = (flags & NetworkReachabilityFlags.ConnectionRequired) == 0;

            if((flags & NetworkReachabilityFlags.IsWWAN) != 0)
            {
                noConnectionRequired = true;
            }
            return IsReachable && noConnectionRequired;
        }
    }
}