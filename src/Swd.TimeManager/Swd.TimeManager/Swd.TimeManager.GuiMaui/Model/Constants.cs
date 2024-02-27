using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swd.TimeManager.GuiMaui.Model
{
    public class Constants
    {
        public const string DATABASEFILENAME = "TimeManagerSQLite.db3";

        public static string DATABASEPATH => Path.Combine(FileSystem.AppDataDirectory, DATABASEFILENAME);

        public const SQLite.SQLiteOpenFlags FLAGS = 
            SQLite.SQLiteOpenFlags.ReadWrite |
            SQLite.SQLiteOpenFlags.Create |
            SQLite.SQLiteOpenFlags.SharedCache;

    }
}
