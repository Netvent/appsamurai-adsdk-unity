using System;

namespace AppSamuraiAds.Api
{
    public class AdFailedToLoadEventArgs : EventArgs
    {
        public String Message { get; set; }
    }
}
