
using SQLite;
using SQLite.Net.Attributes;
using SQLiteNetExtensions.Attributes;
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

        [ForeignKey(typeof(CenterType))]
        public int IDType { get; set; }

    
        [ManyToOne]
        public CenterType CenterType { get; set; }

        [OneToMany]
        public List<OpeningHours> Openings { get; set; }

        public double Longitude { get; set; }

        public double Latitude { get; set; }

        public string Name { get; set; }
        public string Address { get; set; }
        public string Notes { get; set; }
        public string Reference { get; set; }

        public string Services { get; set; }

        public string PhoneNumber { get; set; }

    }
}
