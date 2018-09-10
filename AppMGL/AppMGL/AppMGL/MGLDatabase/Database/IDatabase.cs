using SQLite.Net;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppMGL.MGLDatabase.Database
{
    public interface IDatabase
    {
        SQLiteConnection DbConnection();
    }
}
