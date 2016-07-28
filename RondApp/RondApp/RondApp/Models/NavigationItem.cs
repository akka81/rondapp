using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace RondApp.Models
{
    public class NavigationItem
    {
        public string Title { get; set; }
        public string IconRes { get; set; }
        public Type ItemType { get; set; }
    }
}
