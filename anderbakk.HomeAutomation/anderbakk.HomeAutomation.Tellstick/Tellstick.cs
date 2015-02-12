using System.Collections.Generic;
using TelldusCoreWrapper;
using TelldusCoreWrapper.Entities;
using TelldusCoreWrapper.Service;

namespace anderbakk.HomeAutomation.Tellstick
{
    public class Tellstick
    {
        public IEnumerable<ReceiverDevice> ListDevices()
        {
            var tellstickService = new TelldusCoreService(new TelldusCoreLibraryWrapper());
            return tellstickService.GetDevices();
        }
    }
}
