using SakkeFutbol.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace SakkeFutbol.Data
{
    public class UserDataBaseController
    {
        static object locker = new object();

        SQLiteConnection database;

        public UserDataBaseController()
        {
            database = DependencyService.Get<ISQLite>().GetConnection();
            database.CreateTable<User>();
        }

        public User GetUser()
        {
            lock (locker)
            {
                if (database.Table<User>().Count() == 0)
                {
                    return null;
                }
                else
                {
                    return database.Table<User>().First();
                }
            }

        }
        public int SaverUser(User user)
        {
            lock (locker)
            {
                if (user.Id != 0)
                {
                    database.Update(user);
                    return user.Id;
                }
                else
                {
                    user.Id = 1;
                    return database.Insert(user);
                }
            }
        }
        public int DeleteUser(int id)
        {
            lock (locker)
            {
                return database.Delete<User>(id);
            }
        }
    }
}
