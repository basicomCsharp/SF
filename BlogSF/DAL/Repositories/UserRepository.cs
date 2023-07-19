using BlogSF.DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSF
{
    public class UserRepository : IBaseRepositories<User>
    {
        private readonly AppContext db;
        public UserRepository(AppContext contex)
        {
            this.db = contex;
        }
        public void Create(User value)
        {
            db.Users.Add(value);
        }

        public void Delete(int id)
        {
            User _user = db.Users.Find(id);
            if (_user != null) 
                db.Users.Remove(_user);
        }

        public User Get(int id)
        {
            return db.Users.Find(id);
        }

        public IEnumerable<User> GetAll()
        {
            return db.Users;
        }

        public void Update(User value)
        {
            db.Entry(value).State = EntityState.Modified;            
        }
    }
}
