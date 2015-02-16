using System;

namespace anderbakk.HomeAutomation.Tellstick.Models
{
    public class ReceiverStateRequestModel
    {
        public string Method { get; set; }

        public bool MethodIsEnum()
        {
            TelldusCoreWrapper.Entities.Method method;
            return (Enum.TryParse(Method, true, out method));
        }

        public TelldusCoreWrapper.Entities.Method GetMethod()
        {
            return (TelldusCoreWrapper.Entities.Method) Enum.Parse(typeof (TelldusCoreWrapper.Entities.Method), Method);
        }
    }
}