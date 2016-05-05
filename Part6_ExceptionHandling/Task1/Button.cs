using System;
using System.Collections.Generic;
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
                throw new EnabledStatusException($@"You can't click on the button {Name}. Button is disabled.");
            }

            return Name;
        }

    }
}
