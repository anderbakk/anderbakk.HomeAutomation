using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using TelldusCoreWrapper.Entities;

namespace anderbakk.HomeAutomation.WebApi.Controllers
{
    public class DevicesController : ApiController
    {
        private readonly Tellstick.Tellstick _tellstick;

        public DevicesController()
        {
            _tellstick = new Tellstick.Tellstick();
        }

        [Route("Devices")]
        public IEnumerable<ReceiverDevice> GetAll()
        {
            return _tellstick.ListDevices();
        }

        [Route("Devices/{deviceId}")]
        public ReceiverDevice Get(int deviceId)
        {
            var devices = _tellstick.ListDevices();
            return devices.SingleOrDefault(device => device.Id == deviceId);
        }
    }
}
