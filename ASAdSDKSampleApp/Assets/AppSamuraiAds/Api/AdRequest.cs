using System;
using System.Collections.Generic;

namespace AppSamuraiAds.Api
{
    public class AdRequest
    {
        private AdRequest(Builder builder)
        {
            this.TestDevices = new List<string>(builder.TestDevices);
            this.AdFormats = new List<string>(builder.AdFormats);
        }

        public List<string> TestDevices { get; private set; }
        public List<string> AdFormats { get; private set; }

        public class Builder
        {
            public Builder()
            {
                this.TestDevices = new List<string>();
                this.AdFormats = new List<string>();
            }

            internal List<string> TestDevices { get; private set; }
            internal List<string> AdFormats { get; private set; }

            public Builder AddTestDevice(string deviceId)
            {
                this.TestDevices.Add(deviceId);
                return this;
            }

            public Builder AddAdFormat(string adFormats)
            {
                this.AdFormats.Add(adFormats);
                return this;
            }

            public AdRequest Build()
            {
                return new AdRequest(this);
            }
        }
    }
}
