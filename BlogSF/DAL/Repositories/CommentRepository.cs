namespace BlogSF.DAL.Repositories
{
    public class CommentRepository
    {
        /// <summary>
        /// создание комментария
        /// </summary>
        /// <param name="comment"></param>
        /// <returns></returns>
        public bool Create(Comment comment)
        {
            using (var db = new AppContext())
            {
                var addcomment = db.Comments.Add(comment);
                db.SaveChanges();
                return true;
            }
        }
        /// <summary>
        /// чтение комментария
        /// </summary>
        /// <param name="id"></param>
        /// <param name="comment"></param>
        /// <returns></returns>
        public bool Read(int id, out Comment comment)
        {
            using (var db = new AppContext())
            {
                comment = db.Comments.Where(u => u.Id == id).FirstOrDefault();
                return comment != null;
            }
        }
        public bool Update(int id, Comment comment)
        {
            using (var db = new AppContext())
            {
                var _comment = db.Comments.Where(u => u.Id == id).FirstOrDefault();
                _comment = comment;
                db.SaveChanges();
                return true;
            }
        }


        public bool Delete(Comment id)
        {
            using (var db = new AppContext())
            {
                var DelComment = db.Comments.Remove(id);
                db.SaveChanges();
                return true;
            }
        }

    }
}
