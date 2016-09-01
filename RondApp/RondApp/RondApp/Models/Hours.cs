using SQLite;
using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RondApp.Models
{
    [Table("TB_HOURS")]
    public class Hours
    {
        [PrimaryKey]
        public int ID { get; set; }
        public string Label { get; set; }
    }
}
