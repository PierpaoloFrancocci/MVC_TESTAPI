using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using System.ComponentModel.DataAnnotations;

namespace BusinessLayer
{
    public class CalledAPI
    {
        public int ID { get; set; }
        [ScaffoldColumn(false)]
        public DateTime dtAgg { get; set; }
        public string StringIn { get; set; }
        public string StringCode { get; set; }
        public string KeyCode { get; set; }
    }
}
