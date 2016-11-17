
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RondApp.Models
{
    [Table("TB_CENTERS")]
    public class Center
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

     
        public int IDType { get; set; }

     
        //public CenterType CenterType { get; set; }

     
    //    public List<OpeningHours> Openings { get; set; }

        public double Longitude { get; set; }

        public double Latitude { get; set; }

        public string Name { get; set; }
        public string Address { get; set; }
        public string Notes { get; set; }
        public string Reference { get; set; }

        public string Services { get; set; }

        public string PhoneNumber { get; set; }


        public string Origin { get; set; }
        public string Gender { get; set; }
        public int MinAge { get; set; }
        public int MaxAge { get; set; }
        public string Hygiene { get; set; }
        public string Health { get; set; }
    }
}
