using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    interface IClickable
    {
        string Click(EventArgs eventArgs);
    }

    public abstract class BaseElement
    {

    }

    public class Button : BaseElement, IClickable
    {
        public string Name { get; set; }

        public bool Enabled { get; set; }

        public string Click(EventArgs eventArgs)
        {
            if (Enabled == false)
            {
                throw new EnabledStatusException("Button is disabled.");
            }

            return Name;
        }
    }

    public class Page : Button
    {

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
