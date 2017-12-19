using System.Collections.Generic;
using System.Linq;

namespace RondApp.Utils
{
    public class Styles
    {
        public class CenterColor
        {
            public int ID { get; set; }
            public string Color { get; set; }
            public string ColorDark { get; set; }
        }

        public static class CentersColors
        {
            private static List<CenterColor> centersColorsList;

            static CentersColors()
            {
                centersColorsList = new List<CenterColor>();

                //init colors
                //centro aiuto
                centersColorsList.Add(new CenterColor { ID = 0, Color= "#9C27B0", ColorDark= "#7B1FA2" });
                //Centro Ascolto
                centersColorsList.Add(new CenterColor { ID = 1, Color = "#00BCD4", ColorDark = "#0097A7" });   
                //centro Diurno
                centersColorsList.Add(new CenterColor { ID = 2, Color = "#F44336", ColorDark = "#D32F2F" });
                //deposito bagagli
                centersColorsList.Add(new CenterColor { ID = 3, Color = "#3F51B5", ColorDark = "#303F9F" });
                //Mensa
                centersColorsList.Add(new CenterColor { ID = 4, Color = "#4CAF50", ColorDark = "#388E3C" });
                //Guardaroba
                centersColorsList.Add(new CenterColor { ID = 5, Color = "#FF9800", ColorDark = "#F57C00" });
                //Servizio Sanitario
                centersColorsList.Add(new CenterColor { ID = 6, Color = "#E91E63", ColorDark = "#C2185B" });
                //servizi di igiene personale
                centersColorsList.Add(new CenterColor { ID = 7, Color = "#795548", ColorDark = "#5D4037" });
                //Servizi legali
                centersColorsList.Add(new CenterColor { ID = 8, Color = "#607D8B", ColorDark = "#455A64" });
                //Servizi sociali comune di Milano
                centersColorsList.Add(new CenterColor { ID = 9, Color = "#CDDC39", ColorDark = "#AFB42B" });
            }

            public static CenterColor GetColor(int centerId)
            {
                return centersColorsList.Single(c => c.ID == centerId);
            }
        }
    }
}
