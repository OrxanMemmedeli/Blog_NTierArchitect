using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EntityLayer.Concrete
{
    public class Message
    {
        [Key]
        public int ID { get; set; }
        public int? SenderID { get; set; }
        public int? ReceiverID { get; set; }
        public string Subject { get; set; }
        public string Details { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool Status { get; set; } = true;

        public AppUser SenderUser { get; set; }
        public AppUser ReceiverUser { get; set; }
    }
}
