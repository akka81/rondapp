using SQLite;

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
