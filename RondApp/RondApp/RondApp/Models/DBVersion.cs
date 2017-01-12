using SQLite;

namespace RondApp.Models
{
    [Table("TB_DBVERSION")]
    public class DBVersion
    {
        [PrimaryKey]
        public int ID { get; set; }
    }
}
