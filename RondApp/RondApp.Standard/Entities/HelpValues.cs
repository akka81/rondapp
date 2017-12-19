using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RondApp.Entities
{
    public class HelpValues
    {
        public const int MinAge = 0;
        public const int MaxAge = 100;

        //Origin, Gender, HealthProblems, Personalhygiene

        public static class Origin
        {
            static Dictionary<string, string> origins;
            static Origin()
            {
                origins = new Dictionary<string, string>();
                origins.Add("Italiano", "I");
                origins.Add("Straniero", "S");
                origins.Add("Entrambi", "E");
            }

            public static string GetValue(string Key)
            {
                return origins[Key];
            }

            public static List<string> All() { return origins.Keys.ToList(); }
        }

        public static class Gender
        {
            static Dictionary<string, string> genders;
            static Gender()
            {
                genders = new Dictionary<string, string>();
                genders.Add("Maschio", "M");
                genders.Add("Femmina", "F");
                genders.Add("Entrambi", "E");
            }

            public static string GetValue(string Key)
            {
                return genders[Key];
            }

            public static List<string> All()
            {
                return genders.Keys.ToList();
            }
        }

        public static class Hygiene
        {
            static Dictionary<string, string> hygiene;

            static Hygiene()
            {
                hygiene = new Dictionary<string, string>();
                hygiene.Add("Si", "S");
                hygiene.Add("No", "N");
            }

            public static string GetValue(string Key)
            {
                return hygiene[Key];
            }

            public static List<string> All() { return hygiene.Keys.ToList(); }
        }

        public static class Health
        {
            static Dictionary<string, string> health;
            static Health()
            {
                health = new Dictionary<string, string>();
                health.Add("Si", "S");
                health.Add("No", "N");
            }

            public static string GetValue(string Key)
            {
                return health[Key];
            }

            public static List<string> All()
            {
                return health.Keys.ToList();
            }
        }

    }
}
