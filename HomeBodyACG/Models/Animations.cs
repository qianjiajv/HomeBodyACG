using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HomeBodyACG.Models
{
    public class Animations
    {
        public int ID { get; set; }
        public String Title { get; set; }

        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
        public String Genre { get; set; }
        public String Magnet { get; set; }
    }
}
