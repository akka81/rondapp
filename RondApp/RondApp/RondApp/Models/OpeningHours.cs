using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RondApp.Models
{
    [Table("TB_OPENING_HOURS")]
    public class OpeningHours
    {
        [PrimaryKey,AutoIncrement]
        public int ID { get; set; }

     
        public int IDCenter { get; set; }
          
          
       
        public int IDHours { get; set; }

     
        public bool Monday { get; set; }
        public bool Tuesday { get; set; }
        public bool Wednesday { get; set; }
        public bool Thursday { get; set; }
        public bool Friday { get; set; }
        public bool Saturday { get; set; }
        public bool Sunday { get; set; }

        public string Notes { get; set; }
    }
}
