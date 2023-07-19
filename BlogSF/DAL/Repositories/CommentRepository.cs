using Microsoft.EntityFrameworkCore;

namespace BlogSF.DAL.Repositories
{
    public class CommentRepository : IBaseRepositories<Comment>
    {
        private readonly AppContext db;
        public CommentRepository(AppContext contex)
        {
            this.db = contex;
        }

        public IEnumerable<Comment> GetAll()
        {
            return db.Comments;
        }

        public Comment Get(int id)
        {
            return db.Comments.Find(id);
        }


        public void Create(Comment comment)
        {
            db.Comments.Add(comment);
            db.SaveChanges();
        }
        public void Update(Comment value)
        {
            db.Entry(value).State = EntityState.Modified;
        }
        public void Delete(int id)
        {
            Comment _comment = db.Comments.Find(id);
            if (_comment != null)
                db.Comments.Remove(_comment);
                db.SaveChanges();
        }

    }
}
