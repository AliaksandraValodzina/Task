using System;
using System.Runtime.Serialization;

namespace Task1
{
    interface IClickable
    {
        string Click();
    }

    public abstract class BaseElement
    {

    }

    public class Button : BaseElement, IClickable
    {
        public string Name { get; set; }

        public bool Enabled { get; set; }

        public string Click()
        {
            if (Enabled == false)
            {
                throw new EnabledStatusException("Button is disabled.");
            }

            return Name;
        }
    }

    [Serializable]
    internal class EnabledStatusException : Exception
    {
        public EnabledStatusException()
        {
        }

        public EnabledStatusException(string message) : base(message)
        {
        }

        public EnabledStatusException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected EnabledStatusException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
