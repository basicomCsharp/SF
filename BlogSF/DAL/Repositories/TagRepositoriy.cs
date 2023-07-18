namespace BlogSF.DAL.Repositories
{
    public class TagRepositoriy
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
        /// Добавление читателя
        /// </summary>
        /// <param name="user">читатель</param>
        public bool Create(User user)
        {
            using (var db = new AppContext())
            {
                var AddUser = db.Users.Add(user);
                db.SaveChanges();
                return true;
            }
        }
        /// <summary>
        /// Получение пользователя
        /// </summary>
        /// <param name="id"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        public bool Read(int id, out User user)
        {
            using (var db = new AppContext())
            {
                user = db.Users.Where(u => u.Id == id).FirstOrDefault();
                return user != null;
            }
        }
        /// <summary>
        /// Изменение имени читателя по id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool Update(int id, User user)
        {
            using (var db = new AppContext())
            {
                var _user = db.Users.Where(user => user.Id == id).FirstOrDefault();
                _user = user;
                db.SaveChanges();
                return true;
            }
        }

        /// <summary>
        /// Удаление читатателя
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Delete(User id)
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
