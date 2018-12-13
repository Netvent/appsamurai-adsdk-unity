using System;
using System.Collections.Generic;

namespace AppSamuraiAds.Api
{
    public class AdRequest
    {
        private AdRequest(Builder builder)
        {
            this.TestDevices = new List<string>(builder.TestDevices);
        }

        public List<string> TestDevices { get; private set; }

        public class Builder
        {
            public Builder()
            {
                this.TestDevices = new List<string>();
            }

            internal List<string> TestDevices { get; private set; }

            public Builder AddTestDevice(string deviceId)
            {
                this.TestDevices.Add(deviceId);
                return this;
            }

            public AdRequest Build()
            {
                return new AdRequest(this);
            }
        }
    }
}
