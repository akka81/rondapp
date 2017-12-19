using SQLite;

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
