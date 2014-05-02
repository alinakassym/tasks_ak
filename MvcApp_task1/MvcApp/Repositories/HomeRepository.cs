using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Web;

namespace MvcApp.Repositories
{
    public class HomeRepository : IHomeRepository
    {
        private usersDBEntities _context;

        public HomeRepository(usersDBEntities userContext)
        {
            this._context = userContext;
        }

        public List<usertbl> GetUsers()
        {
            return _context.User.ToList();
        }

        public usertbl GetUserByID(int iduser)
        {
            return _context.User.Find(iduser);
        }

        public void InsertUser(usertbl user)
        {
            _context.User.Add(user);
        }

        public void DeleteUser(int iduser)
        {
            usertbl user = _context.User.Find(iduser);
            _context.User.Remove(user);
        }

        public void UpdateUser(usertbl user)
        {
            _context.Entry(user).State = EntityState.Modified;
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}