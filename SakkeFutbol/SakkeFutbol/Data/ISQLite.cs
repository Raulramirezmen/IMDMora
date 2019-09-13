using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace SakkeFutbol.Data
{
    public interface ISQLite
    {
        SQLiteConnection GetConnection();
    }
}
