using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore
{
    public class UserRepository
    {
        /// <summary>
        /// Выбор всех читателей
        /// </summary>
        public List<User> SelectAllUsers()
        {
            using (var db = new AppContext())
            {                
                return db.Users.ToList();
            }
        }
        /// <summary>
        /// Выбор читателя по id
        /// </summary>
        /// <param name="id"></param>
        public User SelectUserId(int id)
        {
            using (var db = new AppContext())
            {               
               return db.Users.Where(user => user.Id == id).FirstOrDefault();
            }
        }
        /// <summary>
        /// Изменение имени читателя по id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool UpdateNameUser(int id, string name)
        {
            using (var db = new AppContext())
            {
                var _user = db.Users.Where(user => user.Id == id).FirstOrDefault();
                _user.Name = name;
                return true;
            }
        }
        /// <summary>
        /// Добавление читателя
        /// </summary>
        /// <param name="user">читатель</param>
        public bool AddUser(User user)
        {
            using (var db = new AppContext())
            {                
                var AddUser = db.Users.Add(user);
                db.SaveChanges();
                return true;
            }
        }
        /// <summary>
        /// Удаление читатателя
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DeleteUser(User id)
        {
            using (var db = new AppContext())
            {
                var DelUser = db.Users.Remove(id);
                db.SaveChanges();
                return true;
            }            
        }
    }
}
