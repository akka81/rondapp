using RondApp.Models;
using SQLite;
using SQLite.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace RondApp.DAL
{
    public class DbCenters
    {
        SQLiteConnection Database;
        object locker = new object();
        public DbCenters()
        {
            Database = DependencyService.Get<ISQlite>().GetConnection();

            Database.Execute("DROP TABLE IF EXISTS TB_OPENING_HOURS");        
            Database.CreateTable<Hours>();
            Database.CreateTable<CenterType>();
            Database.CreateTable<OpeningHours>();
            Database.CreateTable<Center>();          
        }

        public void LoadDbData()
        {
            #region CenterType
            if (Database.Table<CenterType>().Count() == 0)
            {
                Database.Insert(new CenterType {
                    ID = 0,
                    Label = "Centro Aiuto"
                });
                Database.Insert(new CenterType
                {
                    ID = 1,
                    Label = "Centro Ascolto"
                });
                Database.Insert(new CenterType
                {
                    ID = 2,
                    Label = "Centro Diurno"
                });
                Database.Insert(new CenterType
                {
                    ID = 3,
                    Label = "Deposito Bagagli"
                });
                Database.Insert(new CenterType
                {
                    ID = 4,
                    Label = "Mesa"
                });
                Database.Insert(new CenterType
                {
                    ID = 5,
                    Label = "Guardaroba"
                });
                Database.Insert(new CenterType
                {
                    ID = 6,
                    Label = "Servizio Sanitario"
                });
              

            }
            #endregion
            List<CenterType> types  = Database.Table<CenterType>().ToList();

            #region hours
            if (Database.Table<Hours>().Count() == 0)
            {
                Database.Insert(new Hours
                {                   
                    ID = 0,
                    Label="8.30-19.30"
                });
                Database.Insert(new Hours
                {
                    ID = 1,
                    Label = "9.00-11.30"
                });
                Database.Insert(new Hours
                {
                    ID = 2,
                    Label = "9.00-12.00"
                });
                Database.Insert(new Hours
                {
                    ID = 3,
                    Label = "9.00-17.00"
                });
                Database.Insert(new Hours
                {
                    ID = 4,
                    Label = "9.00-13.00"
                });
                Database.Insert(new Hours
                {
                    ID = 5,
                    Label = "9.00-14.00"
                });
                Database.Insert(new Hours
                {
                    ID = 6,
                    Label = "8.30-11.00"
                });
                Database.Insert(new Hours
                {
                    ID = 7,
                    Label = "17.00-18.30"
                });
                Database.Insert(new Hours
                {
                    ID = 8,
                    Label = "11.30-13.00"
                });
                Database.Insert(new Hours
                {
                    ID = 9,
                    Label = "11.30"
                });
                Database.Insert(new Hours
                {
                    ID = 10,
                    Label = "11.30-14.30"
                });
                Database.Insert(new Hours
                {
                    ID = 11,
                    Label = "17.30-19.30"
                });
                Database.Insert(new Hours
                {
                    ID = 12,
                    Label = "18.30-20.30"
                });
                Database.Insert(new Hours
                {
                    ID = 13,
                    Label = "10.30-11.30"
                });
                Database.Insert(new Hours
                {
                    ID = 14,
                    Label = "9.00-11.00"
                });
                Database.Insert(new Hours
                {
                    ID = 15,
                    Label = "17.30-19.00"
                });
                Database.Insert(new Hours
                {
                    ID = 16,
                    Label = "8.00"
                });
                Database.Insert(new Hours
                {
                    ID = 17,
                    Label = "14.30-16.30"
                });
                Database.Insert(new Hours
                {
                    ID = 18,
                    Label = "11.00-14.00"
                });
                Database.Insert(new Hours
                {
                    ID = 19,
                    Label = "17.30-20.00"
                });
                Database.Insert(new Hours
                {
                    ID = 20,
                    Label = "15.00-16.00"
                });
                Database.Insert(new Hours
                {
                    ID = 21,
                    Label = "15.30"
                });
                Database.Insert(new Hours
                {
                    ID = 22,
                    Label = "8.00-12.00"
                });
                Database.Insert(new Hours
                {
                    ID = 23,
                    Label = "13.45-16.00"
                });
                Database.Insert(new Hours
                {
                    ID = 24,
                    Label = "15.00-18.30"
                });
                Database.Insert(new Hours
                {
                    ID = 25,
                    Label = "9.30-12.00"
                });
                Database.Insert(new Hours
                {
                    ID = 26,
                    Label = "14.30-18.30"
                });
                Database.Insert(new Hours
                {
                    ID = 27,
                    Label = "8.30-12.30"
                });
                Database.Insert(new Hours
                {
                    ID = 28,
                    Label = "9.00-12.30"
                });
                Database.Insert(new Hours
                {
                    ID = 29,
                    Label = "14.00-17.00"
                });
                Database.Insert(new Hours
                {
                    ID = 30,
                    Label = "9.15-12.00"
                });
                Database.Insert(new Hours
                {
                    ID = 31,
                    Label = "11.00-13.00"
                });
                Database.Insert(new Hours
                {
                    ID = 32,
                    Label = "14.00-19.00"
                });
                Database.Insert(new Hours
                {
                    ID = 33,
                    Label = "9.00-15.30"
                });
                Database.Insert(new Hours
                {
                    ID = 34,
                    Label = "8.00-11.00"
                });
                Database.Insert(new Hours
                {
                    ID = 35,
                    Label = "7.30"
                });
                Database.Insert(new Hours
                {
                    ID = 36,
                    Label = "10.00-19.00"
                });
                Database.Insert(new Hours
                {
                    ID = 37,
                    Label = "14.00-16.00"
                });
                Database.Insert(new Hours
                {
                    ID = 38,
                    Label = "8.30-11.30"
                });
            }
            #endregion

            #region centers and openings
            //int ID = AddCenter(new Center { IDType = , Address = "", Latitude = , Longitude = , Name = "", Notes="",PhoneNumber="", Reference=""  });
            //AddHours(new OpeningHours { IDCenter=ID, IDHours=, Monday=, Tuesday=, Wednesday, Thursday, Friday, Saturday, Sunday});
            //AddHours(new OpeningHours { IDCenter=ID, IDHours=, Monday=, Tuesday=, Wednesday, Thursday, Friday, Saturday, Sunday});
            //ID = AddCenter(new Center { IDType = , Address = "", Latitude = , Longitude = , Name = "", Notes = "", PhoneNumber = "", Reference = "" });
            //ID = AddCenter(new Center { IDType = , Address = "", Latitude = , Longitude = , Name = "", Notes = "", PhoneNumber = "", Reference = "" });
            //ID = AddCenter(new Center { IDType = , Address = "", Latitude = , Longitude = , Name = "", Notes = "", PhoneNumber = "", Reference = "" });
            //ID = AddCenter(new Center { IDType = , Address = "", Latitude = , Longitude = , Name = "", Notes = "", PhoneNumber = "", Reference = "" });
            //ID = AddCenter(new Center { IDType = , Address = "", Latitude = , Longitude = , Name = "", Notes = "", PhoneNumber = "", Reference = "" });
            //ID = AddCenter(new Center { IDType = , Address = "", Latitude = , Longitude = , Name = "", Notes = "", PhoneNumber = "", Reference = "" });
            //ID = AddCenter(new Center { IDType = , Address = "", Latitude = , Longitude = , Name = "", Notes = "", PhoneNumber = "", Reference = "" });
            //ID = AddCenter(new Center { IDType = , Address = "", Latitude = , Longitude = , Name = "", Notes = "", PhoneNumber = "", Reference = "" });
            //ID = AddCenter(new Center { IDType = , Address = "", Latitude = , Longitude = , Name = "", Notes = "", PhoneNumber = "", Reference = "" });
            //ID = AddCenter(new Center { IDType = , Address = "", Latitude = , Longitude = , Name = "", Notes = "", PhoneNumber = "", Reference = "" });
            //ID = AddCenter(new Center { IDType = , Address = "", Latitude = , Longitude = , Name = "", Notes = "", PhoneNumber = "", Reference = "" });
            //ID = AddCenter(new Center { IDType = , Address = "", Latitude = , Longitude = , Name = "", Notes = "", PhoneNumber = "", Reference = "" });
            //ID = AddCenter(new Center { IDType = , Address = "", Latitude = , Longitude = , Name = "", Notes = "", PhoneNumber = "", Reference = "" });
            //ID = AddCenter(new Center { IDType = , Address = "", Latitude = , Longitude = , Name = "", Notes = "", PhoneNumber = "", Reference = "" });
            //ID = AddCenter(new Center { IDType = , Address = "", Latitude = , Longitude = , Name = "", Notes = "", PhoneNumber = "", Reference = "" });
            //ID = AddCenter(new Center { IDType = , Address = "", Latitude = , Longitude = , Name = "", Notes = "", PhoneNumber = "", Reference = "" });
            //ID = AddCenter(new Center { IDType = , Address = "", Latitude = , Longitude = , Name = "", Notes = "", PhoneNumber = "", Reference = "" });
            //ID = AddCenter(new Center { IDType = , Address = "", Latitude = , Longitude = , Name = "", Notes = "", PhoneNumber = "", Reference = "" });
            //ID = AddCenter(new Center { IDType = , Address = "", Latitude = , Longitude = , Name = "", Notes = "", PhoneNumber = "", Reference = "" });
            //ID = AddCenter(new Center { IDType = , Address = "", Latitude = , Longitude = , Name = "", Notes = "", PhoneNumber = "", Reference = "" });
            //ID = AddCenter(new Center { IDType = , Address = "", Latitude = , Longitude = , Name = "", Notes = "", PhoneNumber = "", Reference = "" });
            //ID = AddCenter(new Center { IDType = , Address = "", Latitude = , Longitude = , Name = "", Notes = "", PhoneNumber = "", Reference = "" });
            //ID = AddCenter(new Center { IDType = , Address = "", Latitude = , Longitude = , Name = "", Notes = "", PhoneNumber = "", Reference = "" });
            //ID = AddCenter(new Center { IDType = , Address = "", Latitude = , Longitude = , Name = "", Notes = "", PhoneNumber = "", Reference = "" });
            //ID = AddCenter(new Center { IDType = , Address = "", Latitude = , Longitude = , Name = "", Notes = "", PhoneNumber = "", Reference = "" });
            //ID = AddCenter(new Center { IDType = , Address = "", Latitude = , Longitude = , Name = "", Notes = "", PhoneNumber = "", Reference = "" });
            //ID = AddCenter(new Center { IDType = , Address = "", Latitude = , Longitude = , Name = "", Notes = "", PhoneNumber = "", Reference = "" });
            //ID = AddCenter(new Center { IDType = , Address = "", Latitude = , Longitude = , Name = "", Notes = "", PhoneNumber = "", Reference = "" });
            //ID = AddCenter(new Center { IDType = , Address = "", Latitude = , Longitude = , Name = "", Notes = "", PhoneNumber = "", Reference = "" });
            //ID = AddCenter(new Center { IDType = , Address = "", Latitude = , Longitude = , Name = "", Notes = "", PhoneNumber = "", Reference = "" });
            //ID = AddCenter(new Center { IDType = , Address = "", Latitude = , Longitude = , Name = "", Notes = "", PhoneNumber = "", Reference = "" });
            //ID = AddCenter(new Center { IDType = , Address = "", Latitude = , Longitude = , Name = "", Notes = "", PhoneNumber = "", Reference = "" });
            //ID = AddCenter(new Center { IDType = , Address = "", Latitude = , Longitude = , Name = "", Notes = "", PhoneNumber = "", Reference = "" });
            //ID = AddCenter(new Center { IDType = , Address = "", Latitude = , Longitude = , Name = "", Notes = "", PhoneNumber = "", Reference = "" });
            //ID = AddCenter(new Center { IDType = , Address = "", Latitude = , Longitude = , Name = "", Notes = "", PhoneNumber = "", Reference = "" });
            //ID = AddCenter(new Center { IDType = , Address = "", Latitude = , Longitude = , Name = "", Notes = "", PhoneNumber = "", Reference = "" });
            //ID = AddCenter(new Center { IDType = , Address = "", Latitude = , Longitude = , Name = "", Notes = "", PhoneNumber = "", Reference = "" });
            //ID = AddCenter(new Center { IDType = , Address = "", Latitude = , Longitude = , Name = "", Notes = "", PhoneNumber = "", Reference = "" });
            //ID = AddCenter(new Center { IDType = , Address = "", Latitude = , Longitude = , Name = "", Notes = "", PhoneNumber = "", Reference = "" });
            //ID = AddCenter(new Center { IDType = , Address = "", Latitude = , Longitude = , Name = "", Notes = "", PhoneNumber = "", Reference = "" });
            //ID = AddCenter(new Center { IDType = , Address = "", Latitude = , Longitude = , Name = "", Notes = "", PhoneNumber = "", Reference = "" });
            //ID = AddCenter(new Center { IDType = , Address = "", Latitude = , Longitude = , Name = "", Notes = "", PhoneNumber = "", Reference = "" });
            //ID = AddCenter(new Center { IDType = , Address = "", Latitude = , Longitude = , Name = "", Notes = "", PhoneNumber = "", Reference = "" });
            //ID = AddCenter(new Center { IDType = , Address = "", Latitude = , Longitude = , Name = "", Notes = "", PhoneNumber = "", Reference = "" });
            //ID = AddCenter(new Center { IDType = , Address = "", Latitude = , Longitude = , Name = "", Notes = "", PhoneNumber = "", Reference = "" });
            //ID = AddCenter(new Center { IDType = , Address = "", Latitude = , Longitude = , Name = "", Notes = "", PhoneNumber = "", Reference = "" });
            //ID = AddCenter(new Center { IDType = , Address = "", Latitude = , Longitude = , Name = "", Notes = "", PhoneNumber = "", Reference = "" });
            //ID = AddCenter(new Center { IDType = , Address = "", Latitude = , Longitude = , Name = "", Notes = "", PhoneNumber = "", Reference = "" });
            //ID = AddCenter(new Center { IDType = , Address = "", Latitude = , Longitude = , Name = "", Notes = "", PhoneNumber = "", Reference = "" });
            //ID = AddCenter(new Center { IDType = , Address = "", Latitude = , Longitude = , Name = "", Notes = "", PhoneNumber = "", Reference = "" });
            //ID = AddCenter(new Center { IDType = , Address = "", Latitude = , Longitude = , Name = "", Notes = "", PhoneNumber = "", Reference = "" });
            //ID = AddCenter(new Center { IDType = , Address = "", Latitude = , Longitude = , Name = "", Notes = "", PhoneNumber = "", Reference = "" });
            //ID = AddCenter(new Center { IDType = , Address = "", Latitude = , Longitude = , Name = "", Notes = "", PhoneNumber = "", Reference = "" });
            //ID = AddCenter(new Center { IDType = , Address = "", Latitude = , Longitude = , Name = "", Notes = "", PhoneNumber = "", Reference = "" });
            //ID = AddCenter(new Center { IDType = , Address = "", Latitude = , Longitude = , Name = "", Notes = "", PhoneNumber = "", Reference = "" });
            //ID = AddCenter(new Center { IDType = , Address = "", Latitude = , Longitude = , Name = "", Notes = "", PhoneNumber = "", Reference = "" });
            //ID = AddCenter(new Center { IDType = , Address = "", Latitude = , Longitude = , Name = "", Notes = "", PhoneNumber = "", Reference = "" });
            //ID = AddCenter(new Center { IDType = , Address = "", Latitude = , Longitude = , Name = "", Notes = "", PhoneNumber = "", Reference = "" });
            //ID = AddCenter(new Center { IDType = , Address = "", Latitude = , Longitude = , Name = "", Notes = "", PhoneNumber = "", Reference = "" });
            //ID = AddCenter(new Center { IDType = , Address = "", Latitude = , Longitude = , Name = "", Notes = "", PhoneNumber = "", Reference = "" });
            //ID = AddCenter(new Center { IDType = , Address = "", Latitude = , Longitude = , Name = "", Notes = "", PhoneNumber = "", Reference = "" });
            //ID = AddCenter(new Center { IDType = , Address = "", Latitude = , Longitude = , Name = "", Notes = "", PhoneNumber = "", Reference = "" });
            //ID = AddCenter(new Center { IDType = , Address = "", Latitude = , Longitude = , Name = "", Notes = "", PhoneNumber = "", Reference = "" });
            //ID = AddCenter(new Center { IDType = , Address = "", Latitude = , Longitude = , Name = "", Notes = "", PhoneNumber = "", Reference = "" });
            //ID = AddCenter(new Center { IDType = , Address = "", Latitude = , Longitude = , Name = "", Notes = "", PhoneNumber = "", Reference = "" });
            //ID = AddCenter(new Center { IDType = , Address = "", Latitude = , Longitude = , Name = "", Notes = "", PhoneNumber = "", Reference = "" });


            #endregion

        }

        private int AddCenter(Center newCenter)
        {
           return Database.Insert(newCenter);
        }

        private void AddHours(OpeningHours newOpening)
        {
            Database.Insert(newOpening);
        }

    }
}
