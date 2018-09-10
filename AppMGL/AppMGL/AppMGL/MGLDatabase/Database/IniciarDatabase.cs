using SQLite.Net;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppMGL.MGLDatabase.Database
{
    public class IniciarDatabase
    {
        public IniciarDatabase()
        {
            SQLiteConnection sqlConnection = Xamarin.Forms.DependencyService.Get<IDatabase>().DbConnection();

            //sqlConnection.CreateTable<Cliente>();

        }
    }
}