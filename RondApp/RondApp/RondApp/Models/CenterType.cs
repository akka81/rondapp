using SQLite;

namespace RondApp.Models
{
    [Table("TB_TYPES")]
    public class CenterType
    {
        [PrimaryKey]
        public int ID { get; set; }

        public string Label { get; set; }
    }
}
