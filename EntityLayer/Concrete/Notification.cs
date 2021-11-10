using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EntityLayer.Concrete
{
    public class Notification
    {
        [Key]
        public int ID { get; set; }
        public string Type { get; set; }
        public string Symbol { get; set; }
        public string Details { get; set; }
        public string Color { get; set; }
        public bool Status { get; set; } = true;
        public DateTime NotificationDate { get; set; }

    }
}
