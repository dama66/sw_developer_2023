using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swd.Messanger.Model
{
    internal class Message
    {
        public long Id { get; set; }
        public MessageType Type { get; set; }
        [Range(1,100)]
        public int Priority { get; set; }
        public DateTime Sent {  get; set; }
        public DateTime Delivered { get; set; }
        public DateTime Confirmed { get; set; }
        public DateTime Validity { get; set; }
        public string Sender { get; set; }
        public string Receiver { get; set; }
        public string SentMessage { get; set; }
        public MessageState State { get; set; }



    }
}
