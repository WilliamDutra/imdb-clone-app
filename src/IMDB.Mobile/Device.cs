using System;

namespace IMDB.Mobile
{
    public class Device : IDeviceDisplay
    {
        public double GetDensity()
        {
            return DeviceDisplay.Current.MainDisplayInfo.Density;
        }

        public DisplayOrientation GetOrientation()
        {
            return DeviceDisplay.Current.MainDisplayInfo.Orientation;
        }

        
    }
}
