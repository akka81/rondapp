using RondApp.Models;
using SQLite.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLiteNetExtensions.Extensions;

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
           
            List<Center> Centers = this.dbConn.GetAllWithChildren<Center>(c => c.Latitude == Latitude && c.Longitude == Longitude).ToList();

            List<OpeningHours> openings =  this.dbConn.Table<OpeningHours>().ToList();
            List<Hours> hours = this.dbConn.Table<Hours>().ToList();

            openings = this.dbConn.GetAllWithChildren<OpeningHours>(o => o.IDCenter>0);

            return Centers;
        }

    }
}
