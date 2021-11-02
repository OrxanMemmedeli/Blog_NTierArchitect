using System;
using System.Collections.Generic;
using System.Text;

namespace EntityLayer.Concrete
{
    public class BlogScore
    {
        public int ID { get; set; }
        public int BlogID { get; set; }
        public int Total { get; set; }
        public int ScoreCount { get; set; }
    }
}
