using RondApp.Entities;
using RondApp.Models;
using RondApp.Utils;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static RondApp.Utils.Styles;

namespace RondApp.Managers
{
    public class CentersManager
    {
        SQLiteConnection dbConn;
        public CentersManager(SQLiteConnection dbConn)
        {
            this.dbConn = dbConn;
        }


        public List<CenterDetailed> All()
        {

            List<CenterDetailed> Centers = this.dbConn.Query<CenterDetailed>("Select c.*, t.Label as TypeName from TB_CENTERS c LEFT JOIN TB_TYPES t ON c.IDType = t.ID");


            List<OpeningHoursDetailed> AllOpeningsHours = GetAllOpeningsHours();

            //set color
            bool isOpen = false;
            foreach (CenterDetailed centerDetailed in Centers)
            {
                SetCenterColor(centerDetailed);

                isOpen = SetIsOpen(centerDetailed, AllOpeningsHours);
                //centerDetailed.OpenNow = isOpen ? "A" : "C";
                //centerDetailed.OpenColor = isOpen ? "Green" : "Red";
            }
            return Centers;
        }


        public List<CenterDetailed> GetByCoordinates(double Latitude, double Longitude)
        {

            List<CenterDetailed> Centers = this.dbConn.Query<CenterDetailed>("Select c.*, t.Label as TypeName from TB_CENTERS c LEFT JOIN TB_TYPES t ON c.IDType = t.ID where c.Latitude = ? and c.Longitude = ?", Latitude, Longitude);

            List<OpeningHoursDetailed> AllOpeningsHours = GetAllOpeningsHours();
            //set colors
            foreach (CenterDetailed centerDetailed in Centers)
            {
                SetCenterColor(centerDetailed);
                SetIsOpen(centerDetailed, AllOpeningsHours);
            }

            return Centers;
        }

        public CenterDetailed GetById(int CenterId)
        {
            CenterDetailed CenterDetail = this.dbConn.Query<CenterDetailed>("Select c.*, t.Label as TypeName from TB_CENTERS c LEFT JOIN TB_TYPES t ON c.IDType = t.ID where c.ID = ?", CenterId).First();
            //get center opening Hours
            List<OpeningHoursDetailed> CenterOpeningsHours = this.dbConn.Query<OpeningHoursDetailed>("Select oh.*, h.Label as HoursLabel from TB_OPENING_HOURS oh LEFT JOIN TB_HOURS h ON oh.IDHours = h.ID where oh.IDCenter = ?", CenterId);

            //set center color
            SetCenterColor(CenterDetail);
            //set Open Closed Flag
            SetIsOpen(CenterDetail, CenterOpeningsHours);

            return CenterDetail;

        }

        public List<OpeningHoursDetailed> GetCenterOpeningsHours(int centerId)
        {
            List<OpeningHoursDetailed> centerOpeningHours = this.dbConn.Query<OpeningHoursDetailed>("Select oh.*, h.Label as TypeName from TB_OPENING_HOURS oh LEFT JOIN TB_HOURS h ON oh.IDHours = h.ID where oh.IDCenter =?", centerId);
            return centerOpeningHours;
        }

        public List<CenterDetailed> GetByCriteria()
        {
            throw new NotImplementedException();
        }

        #region Private Methods

        private bool SetIsOpen(CenterDetailed Center, List<OpeningHoursDetailed> AllOpeningsHours)
        {
            try
            {
                List<OpeningHoursDetailed> CenterOpeningsHours = AllOpeningsHours.Where(op => op.IDCenter == Center.ID).ToList();

                //check if there is a center open in the current time
                List<OpeningHoursDetailed> CenterOpenedNow = GetTimeRangeCenter(CenterOpeningsHours);

                //check if the center opened in the current time, if any, is opened in the current day
                if (CenterOpenedNow.Count > 0)
                {
                    foreach (OpeningHoursDetailed ohd in CenterOpenedNow)
                    {
                        if (isOpeningDay(ohd))
                        {
                            Center.OpenNow = "A";
                            Center.OpenColor = "#339933";
                            return true;
                        }
                            
                    }
                }
                Center.OpenColor = "#cc0000";
                Center.OpenNow = "C";

                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
                     
        }


        private bool isOpeningDay(OpeningHoursDetailed openingHoursDetailed)
        {

            switch ((int)DateTime.Now.DayOfWeek)
            {
                case 0:
                    return openingHoursDetailed.Sunday;
                case 1:
                    return openingHoursDetailed.Monday;
                case 2:
                    return openingHoursDetailed.Tuesday;
                case 3:
                    return openingHoursDetailed.Wednesday;
                case 4:
                    return openingHoursDetailed.Thursday;
                case 5:
                    return openingHoursDetailed.Friday;
                case 6:
                    return openingHoursDetailed.Saturday;
                default:
                    return false;          
            }

        }

        private List<OpeningHoursDetailed> GetTimeRangeCenter(List<OpeningHoursDetailed> CenterOpeningsHours)
        {

            List<OpeningHoursDetailed> TimeRangeCenters = new List<OpeningHoursDetailed>();
            double now = double.Parse(DateTime.Now.ToString("HH.mm"));

            double startHour;
            double endHour;
            String[] hours;
            foreach (OpeningHoursDetailed ohd in CenterOpeningsHours)
            {
                if (ohd.HoursLabel.Contains("-"))
                {
                    hours = ohd.HoursLabel.Split('-');

                    startHour = double.Parse(hours[0]);
                    endHour = double.Parse(hours[1]);
                }
                else
                {
                    startHour = double.Parse(ohd.HoursLabel);
                    endHour = startHour;
                }

                if (now >= startHour && now <= endHour)
                    TimeRangeCenters.Add(ohd);
                   
            }
            return TimeRangeCenters;
        }


        private void SetCenterColor(CenterDetailed Center)
        {
            CenterColor color = Styles.CentersColors.GetColor(Center.IDType);
            Center.Color = color.Color;
            Center.ColorDark = color.ColorDark;

        }

        private List<OpeningHoursDetailed> GetAllOpeningsHours()
        {
            //get all openings hours
            List<OpeningHoursDetailed> AllOpeningsHours = this.dbConn.Query<OpeningHoursDetailed>("Select oh.*, h.Label as HoursLabel from TB_OPENING_HOURS oh LEFT JOIN TB_HOURS h ON oh.IDHours = h.ID");
            return AllOpeningsHours;

        }
        #endregion

    }
}
