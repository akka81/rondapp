using RondApp.Entities;
using RondApp.Utils;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using static RondApp.Utils.Styles;

namespace RondApp.Managers
{
    public class CentersManager
    {
        private class CenterSearch
        {
            public CenterSearch(bool andConcatenation = true, string tableAlias = "")
            {
                this.Operator = andConcatenation ? " and " : " or ";
                this.TableAlias = tableAlias + ".";
            }

            private string Operator { get; set; }

            private string TableAlias { get; set; }

            private string origin;

            public string Origin
            {
                get
                {
                    return string.IsNullOrEmpty(origin) ? "" : $"({this.TableAlias}Origin = '{origin}' or Origin = 'E')";
                }
                set
                {
                    origin = value;
                }
            }

            private string gender;

            public string Gender
            {
                get
                {
                    return string.IsNullOrEmpty(gender) ? "" : $"({this.TableAlias}Gender = '{gender}' or Gender = 'E')";
                }
                set
                {
                    gender = value;
                }
            }

            private string minAge;
            public string MinAge
            {
                get
                {
                    return string.IsNullOrEmpty(minAge) ? "" : $"{this.TableAlias}MinAge <= {minAge}";
                }
                set
                {
                    minAge = value;
                }

            }

            private string maxAge;
            public string MaxAge
            {
                get
                {
                    return string.IsNullOrEmpty(maxAge) ? "" : $"{this.TableAlias}MaxAge >= {maxAge}";
                }
                set
                {
                    maxAge = value;
                }
            }

            private string hygiene;
            public string Hygiene
            {
                get
                {
                    return string.IsNullOrEmpty(hygiene) ? "" : $"{this.TableAlias}Hygiene = '{hygiene}'";
                }
                set
                {
                    hygiene = value;
                }

            }

            private string health;
            public string Health
            {
                get
                {
                    return string.IsNullOrEmpty(health) ? "" : $"{this.TableAlias}Health = '{health}'";
                }
                set
                {
                    health = value;
                }
            }

            public string GetWhereCondition()
            {
                List<string> whereTokens = new List<string>();
                if (!string.IsNullOrWhiteSpace(Origin))
                {
                    whereTokens.Add(Origin);
                }
                if (!string.IsNullOrWhiteSpace(Gender))
                {
                    whereTokens.Add(Gender);
                }
                if (!string.IsNullOrWhiteSpace(MaxAge))
                {
                    whereTokens.Add(MaxAge);
                }
                if (!string.IsNullOrWhiteSpace(MinAge))
                {
                    whereTokens.Add(MinAge);
                }
                if (!string.IsNullOrWhiteSpace(Hygiene))
                {
                    whereTokens.Add(Hygiene);
                }
                if (!string.IsNullOrWhiteSpace(Health))
                {
                    whereTokens.Add(Health);
                }

                return (whereTokens.Count > 0) ? $" where {string.Join(this.Operator, whereTokens)}" : string.Empty;
            }

        }

        readonly SQLiteConnection dbConn;
        public CentersManager(SQLiteConnection dbConn)
        {
            this.dbConn = dbConn;
        }


        public List<CenterDetailed> All()
        {
            List<CenterDetailed> Centers = this.dbConn.Query<CenterDetailed>("Select c.*, t.Label as TypeName from TB_CENTERS c LEFT JOIN TB_TYPES t ON c.IDType = t.ID");
            List<OpeningHoursDetailed> AllOpeningsHours = GetAllOpeningsHours();

            //set color
            foreach (CenterDetailed centerDetailed in Centers)
            {
                SetCenterColor(centerDetailed);
                SetIsOpen(centerDetailed, AllOpeningsHours);
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
            List<OpeningHoursDetailed> centerOpeningHours = this.dbConn.Query<OpeningHoursDetailed>("Select oh.*, h.Label as HoursLabel from TB_OPENING_HOURS oh LEFT JOIN TB_HOURS h ON oh.IDHours = h.ID where oh.IDCenter =?", centerId);
            return centerOpeningHours;
        }

        public List<CenterDetailed> GetByCriteria(string Origin, string Gender,string Age, string Hygiene, string Health)
        {
            CenterSearch centerSearch = new CenterSearch(true, "c");

            centerSearch.Gender = Gender;
            centerSearch.Origin = Origin;
            centerSearch.MaxAge = Age;
            centerSearch.MinAge = Age;
            centerSearch.Hygiene = Hygiene;
            centerSearch.Health = Health;

            List<CenterDetailed> Centers = this.dbConn.Query<CenterDetailed>($"Select c.*, t.Label as TypeName from TB_CENTERS c LEFT JOIN TB_TYPES t ON c.IDType = t.ID{centerSearch.GetWhereCondition()}");
            List<OpeningHoursDetailed> AllOpeningsHours = GetAllOpeningsHours();

            //set color
            foreach (CenterDetailed centerDetailed in Centers)
            {
                SetCenterColor(centerDetailed);
                SetIsOpen(centerDetailed, AllOpeningsHours);
            }

            return Centers;
        }

        #region Private Methods
        private Boolean SetIsOpen(CenterDetailed Center, List<OpeningHoursDetailed> AllOpeningsHours)
        {
            List<OpeningHoursDetailed> CenterOpeningsHours = AllOpeningsHours.Where(op => op.IDCenter == Center.ID).ToList();

            //check if there is a center open in the current time
            List<OpeningHoursDetailed> CenterOpenedNow = GetTimeRangeCenter(CenterOpeningsHours);

            //check if the center opened in the current time, if any, is opened in the current day
            if (CenterOpenedNow.Count > 0)
            {
                foreach (OpeningHoursDetailed ohd in CenterOpenedNow)
                {
                    if (IsOpeningDay(ohd))
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

        private bool IsOpeningDay(OpeningHoursDetailed openingHoursDetailed)
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
