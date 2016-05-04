using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    [Serializable]
    public class EnabledStatusException : Exception
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
