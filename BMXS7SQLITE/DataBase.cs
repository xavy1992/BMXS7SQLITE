using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace BMXS7SQLITE
{
    public interface DataBase
    {
        SQLiteAsyncConnection GetConnection();





    }
}
