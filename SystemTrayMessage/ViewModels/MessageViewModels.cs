using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemTrayMessage.ViewModels
{
    public class MessageViewModels : ViewBase
    {
        /// <summary>
        /// Name property
        /// </summary>
        private String senderName;
        public String SenderName
        {
            get { return senderName; }

            set
            {
                senderName = value;
                OnPropertyChanged("SenderName");
            }
        }

        /// <summary>
        /// Sender property
        /// </summary>
        private String messageSender;
        public String MessageSender
        {
            get { return messageSender; }

            set
            {
                messageSender = value;
                OnPropertyChanged("MessageSender");
            }
        }

        /// <summary>
        /// Message date
        /// </summary>
        private String messageDate;
        public String MessageDate
        {
            get { return messageDate; }

            set
            {
                messageDate = value;
                OnPropertyChanged("MessageDate");
            }
        }
    }
}
