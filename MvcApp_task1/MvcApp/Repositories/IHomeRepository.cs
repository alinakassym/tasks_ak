using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcApp.Repositories
{
    public interface IHomeRepository : IDisposable
    {
        List<usertbl> GetUsers();
        usertbl GetUserByID(int iduser);
        void InsertUser(usertbl User);
        void DeleteUser(int iduser);
        void UpdateUser(usertbl User);
        void Save();
    }
}