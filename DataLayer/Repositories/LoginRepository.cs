using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repositories
{
    public class LoginRepository : ILoginRepository
    {
        ImagesProcessing_DBEntities db;

        public LoginRepository(ImagesProcessing_DBEntities _db)
        {
            db = _db;
        }

        public bool AddNewPerson(Login_DT person)
        {
            try
            {
                db.Login_DT.Add(person);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool tryToLogin(string userName, string password)
        {
            if (db.Login_DT.Any(p => p.UserName == userName && p.Password == password))
                return true;
            return false;
        }

    }
}
