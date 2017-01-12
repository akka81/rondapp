using RondApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RondApp.Entities
{
    public class OpeningHoursDetailed : OpeningHours
    {
        public String HoursLabel { get; set; }

        public String DaysLabel { get
            {
                List<string> days = new List<string>();

                if (this.Monday)
                { 
                    days.Add("Lun");
                }
                if (this.Tuesday)
                { 
                    days.Add("Mar");
                }
                if (this.Wednesday)
                {
                    days.Add("Mer");
                }
                if (this.Thursday)
                {
                    days.Add("Gio");
                }
                if (this.Friday)
                {
                    days.Add("Ven");
                }
                if (this.Saturday)
                {
                    days.Add("Sab");
                }
                if (this.Sunday)
                {
                    days.Add("Dom");
                }

                return string.Join(", ", days);
            }
        }
    }
}
