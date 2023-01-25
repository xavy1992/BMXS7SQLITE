﻿using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SQLite;
using System.IO;
using BMXS7SQLITE.Droid;

[assembly: Xamarin.Forms.Dependency(typeof(SqlCliente))]

namespace BMXS7SQLITE.Droid
{
    public class SqlCliente : DataBase
    {
        public SQLiteAsyncConnection GetConnection()
        {
            var ruta = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
            var path = Path.Combine(ruta, "uisrael.db3");
            return new SQLiteAsyncConnection(path);
        }
    }
}