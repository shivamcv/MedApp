using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MedApp.Data;
using System.Data.Entity;
using MedApp.Model;

namespace MedApp
{
    public class DataLayer : DbContext
    {
        ShifaDB db = new ShifaDB();

        public bool IsAuthenticated(string username, string password)
        {
            try
            {
                return db.Users.Where(i => i.UserName == username && i.Password == password).Count() > 0 ? true : false; 
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
