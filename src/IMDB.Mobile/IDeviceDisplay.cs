using System;

namespace IMDB.Mobile
{
    public interface IDeviceDisplay
    {
        DisplayOrientation GetOrientation();

        double GetDensity();
    }
}
