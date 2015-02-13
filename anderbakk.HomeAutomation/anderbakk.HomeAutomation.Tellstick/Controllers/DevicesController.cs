using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Results;
using TelldusCoreWrapper;
using TelldusCoreWrapper.Entities;
using TelldusCoreWrapper.Service;

namespace anderbakk.HomeAutomation.Tellstick.Controllers
{
    public class DevicesController : ApiController
    {
        private TelldusCoreService _telldusCoreService;

        public DevicesController()
        {
            _telldusCoreService = new TelldusCoreService(new TelldusCoreLibraryWrapper());
        }

        [Route("Devices")]
        public IEnumerable<ReceiverDevice> GetAll()
        {
            return _telldusCoreService.GetDevices();
        }

        [Route("Devices/{deviceId}")]
        public IHttpActionResult Get(int deviceId)
        {
            
                _telldusCoreService.TurnOn(deviceId);
            return Ok();
        }

        [Route("Sensor")]
        public IEnumerable<Sensor> GetAllSensors()
        {
            return _telldusCoreService.GetSensors();
        }

    }
}
