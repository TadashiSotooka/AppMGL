using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AppMGL.Droid;
using SQLite.Net;
using System.IO;
using SQLite.Net.Platform.XamarinAndroid;
using Android.App;
using AppMGL.MGLDatabase.Database;

[assembly: Xamarin.Forms.Dependency(typeof(ConexaoDB))]
namespace AppMGL.Droid
{
    public class ConexaoDB : IDatabase
    {
        public SQLiteConnection DbConnection()
        {
            var dbName = "MGLDB";
            string documentsFolder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData);
            string path = Path.Combine(documentsFolder, dbName);
            var platform = new SQLitePlatformAndroid();
            return new SQLiteConnection(platform, path, false);

        }
    }
}