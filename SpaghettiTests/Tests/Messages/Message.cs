using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.Messages
{
    public class Message
    {
        public string Recipient { get; private set; }

        public string Theme { get; private set; }

        public string TextForRecipient { get; private set; }

        [System.ComponentModel.DefaultValue("NoPath")]
        public string PathToAttachFile { get; private set; }

        public Message(string recipient, string theme, string textForRecipient)
        {
            this.Recipient = recipient;
            this.Theme = theme;
            this.TextForRecipient = textForRecipient;
        }

        public Message(string recipient, string theme, string textForRecipient, string pathToAttachFile)
        {
            this.Recipient = recipient;
            this.Theme = theme;
            this.TextForRecipient = textForRecipient;
            this.PathToAttachFile = pathToAttachFile;
        }
    }
}
