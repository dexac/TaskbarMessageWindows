using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using SystemTrayMessage.Models;
using SystemTrayMessage.PopupMessage;
using SystemTrayMessage.ViewModels;

namespace SystemTrayMessage
{
    /// <summary>
    /// Interaction logic for Message.xaml
    /// </summary>
    public partial class Message : Window
    {
        MessageViewModels getProper = new MessageViewModels();
        SenderModel senderModel = new SenderModel();
        public Message()
        {
            InitializeComponent();
            this.DataContext = getProper;

            SendMessage("John Doe", "Lorem ipsum dolor sit amet, consectetur adipiscing elit..");
        }

        private void SendMessage(string _sender, string _message)
        {
            senderModel.name = _sender;
            senderModel.message = _message;

            getProper.SenderName = senderModel.name;
            getProper.MessageSender = senderModel.message;

            getDate();
        }

        private void getDate()
        {
            DateTime b = DateTime.Now;
            getProper.MessageDate = b.ToString("MM/dd/yyyy hh:mm tt");
        }

        private void btnSend(object sender, RoutedEventArgs e)
        {
            SystemMsg balloon = new SystemMsg();
            MessageBar.ShowCustomBalloon(balloon, PopupAnimation.Scroll, 2000);
            getDate();
        }
    }
}
