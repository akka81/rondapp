using RondApp.Entities;
using RondApp.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace RondApp.Managers
{
    public class CentersManager
    {
        SQLiteConnection dbConn;
        public CentersManager(SQLiteConnection dbConn)
        {
            this.dbConn = dbConn;
        }


        public List<Center> All()
        {
            return this.dbConn.Table<Center>().ToList();
        }


        public List<Center> GetByCoordinates(double Latitude, double Longitude)
        {

            List<CenterDetailed> crts = this.dbConn.Query<CenterDetailed>("Select c.*, t.Label as TypeName from TB_CENTERS c LEFT JOIN TB_TYPES t ON c.IDType = t.ID where c.Latitude = ? and c.Longitude = ?", Latitude, Longitude);

            List<Center> Centers = this.dbConn.Table<Center>().Where(c => c.Latitude == Latitude && c.Longitude == Longitude).ToList();

            int id = Centers[0].ID;
            int idType = Centers[0].IDType;

            CenterType CType = this.dbConn.Table<CenterType>().FirstOrDefault(ct => ct.ID == idType);

            List<OpeningHours> openings = this.dbConn.Table<OpeningHours>().Where(o => o.IDCenter== id).ToList();

            return Centers;
        }

    }
}
