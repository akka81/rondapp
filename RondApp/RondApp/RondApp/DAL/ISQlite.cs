using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RondApp.DAL
{
    public interface ISQlite
    {
        SQLite.SQLiteConnection GetConnection();
    }
}
