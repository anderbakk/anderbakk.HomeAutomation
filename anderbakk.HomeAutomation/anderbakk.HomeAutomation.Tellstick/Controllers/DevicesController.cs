using System.Linq;
using System.Web.Http;
using TelldusCoreWrapper;
using TelldusCoreWrapper.Service;

namespace anderbakk.HomeAutomation.Tellstick.Controllers
{
    public class DevicesController : ApiController
    {
        private readonly TelldusCoreService _telldusCoreService;

        public DevicesController()
        {
            _telldusCoreService = new TelldusCoreService(new TelldusCoreLibraryWrapper());
        }

        [Route("Receivers")]
        public IHttpActionResult GetAllReceivers()
        {
            return Ok(_telldusCoreService.GetDevices());
        }

        [Route("Receivers/{id}")]
        public IHttpActionResult Get(int id)
        {
            var allDevices = _telldusCoreService.GetDevices();

            var requestDevice = allDevices.SingleOrDefault(device => device.Id == id);

            if (requestDevice != null)
                return Ok(requestDevice);
            return NotFound();
        }

        [Route("Receivers/{id}/turn/on")]
        public IHttpActionResult GetTurnedOn(int id)
        {
            _telldusCoreService.TurnOn(id);
            return Ok();
        }

        [Route("Receivers/{id}/turn/off")]
        public IHttpActionResult GetTurnedOff(int id)
        {
            _telldusCoreService.TurnOff(id);
            return Ok();
        }

        [Route("Receivers/{id}/dim/{level}")]
        public IHttpActionResult GetDimmed(int id, int level)
        {
            _telldusCoreService.Dim(id, level);
            return Ok();
        }

        [Route("Sensors")]
        public IHttpActionResult GetAllSensors()
        {
            return Ok(_telldusCoreService.GetSensors());
        }

        [Route("Sensors/{id}")]
        public IHttpActionResult GetSensor(int id)
        {
            var allSensors = _telldusCoreService.GetSensors();
            var requestedSensor = allSensors.SingleOrDefault(sensor => sensor.Id == id);

            if (requestedSensor != null)
                return Ok(requestedSensor);
            return NotFound();
        }

        [Route("Sensors/{id}/values")]
        public IHttpActionResult GetSensorValue(int id)
        {
            var allSensors = _telldusCoreService.GetSensors();
            var requestedSensor = allSensors.SingleOrDefault(sensor => sensor.Id == id);

            var result = _telldusCoreService.GetValuesFromSensor(requestedSensor);
            return Ok(result);
        }

    }
}
