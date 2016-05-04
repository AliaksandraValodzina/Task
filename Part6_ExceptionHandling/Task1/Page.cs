using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;


namespace Task1
{
    public class Page
    {
        // Buttons on the page
        private List<Button> buttons = new List<Button>();

        public List<Button> Buttons
        {
            get { return buttons; }
            set { buttons = value; }
        }
    }
    }
