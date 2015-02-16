using System.Linq;
using System.Web.Http;
using anderbakk.HomeAutomation.Tellstick.Models;
using TelldusCoreWrapper;
using TelldusCoreWrapper.Entities;
using TelldusCoreWrapper.Service;

namespace anderbakk.HomeAutomation.Tellstick.Controllers
{
    [RoutePrefix("api")]
    public class DevicesController : ApiController
    {
        private readonly TelldusCoreService _telldusCoreService;

        public DevicesController()
        {
            _telldusCoreService = new TelldusCoreService(new TelldusCoreLibraryWrapper());
        }

        [Route("receivers")]
        public IHttpActionResult GetAllReceivers()
        {
            return Ok(_telldusCoreService.GetDevices());
        }

        [Route("receivers/{id}")]
        public IHttpActionResult Get(int id)
        {
            var requestDevice = GetReceiverDevice(id);

            if (requestDevice != null)
                return Ok(requestDevice);
            return NotFound();
        }

        private ReceiverDevice GetReceiverDevice(int id)
        {
            var allDevices = _telldusCoreService.GetDevices();
            return allDevices.SingleOrDefault(device => device.Id == id);
        }

        [Route("receivers/{id}")]
        public IHttpActionResult PutDeviceInState(int id, ReceiverStateRequestModel state)
        {
            var device = GetReceiverDevice(id);

            if (device == null)
                return NotFound();

            if (state == null || !state.MethodIsEnum())
            {
                return BadRequest("Method is not defined or valid");
            }

            var method = state.GetMethod();
            if (!device.IsMethodSupported(method))
            {
                return BadRequest("Method is not supported by device");
            }

            //Extend _tellduscoreservice to support method directly?

            return Ok();
        }

        [Route("sensors")]
        public IHttpActionResult GetAllSensors()
        {
            return Ok(_telldusCoreService.GetSensors());
        }

        [Route("sensors/{id}")]
        public IHttpActionResult GetSensor(int id)
        {
            var allSensors = _telldusCoreService.GetSensors();
            var requestedSensor = allSensors.SingleOrDefault(sensor => sensor.Id == id);

            if (requestedSensor != null)
                return Ok(requestedSensor);
            return NotFound();
        }

        [Route("sensors/{id}/values")]
        public IHttpActionResult GetSensorValue(int id)
        {
            var allSensors = _telldusCoreService.GetSensors();
            var requestedSensor = allSensors.SingleOrDefault(sensor => sensor.Id == id);

            var result = _telldusCoreService.GetValuesFromSensor(requestedSensor);
            return Ok(result);
        }

    }
}
