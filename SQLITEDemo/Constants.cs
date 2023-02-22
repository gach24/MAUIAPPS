using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLITEDemo
{
    public static class Constants
    {
        public const string DB_FILE_NAME = "SQLite.db3";
        public const SQLiteOpenFlags FLAGS =
            SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.Create | SQLiteOpenFlags.SharedCache;

        public static readonly string DB_PATH = Path.Combine(FileSystem.AppDataDirectory, DB_FILE_NAME);
    }
}
