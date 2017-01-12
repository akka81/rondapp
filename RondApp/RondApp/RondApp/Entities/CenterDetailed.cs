using RondApp.Models;

namespace RondApp.Entities
{
    public class CenterDetailed : Center
    {
        public string TypeName { get; set; }

        public string Color { get; set; }

        public string ColorDark { get; set; }

        public string OpenNow { get; set; }

        public string OpenColor { get; set; }
    }
}
