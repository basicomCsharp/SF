using Microsoft.EntityFrameworkCore;

namespace BlogSF.DAL.Repositories
{
    public class TagRepositoriy : IBaseRepositories<Tag>
    {        
        private readonly AppContext db;
        public TagRepositoriy(AppContext contex)
        {
            this.db = contex;
        }
        public void Create(Tag value)
        {
            db.Tags.Add(value);
        }

        public void Delete(int id)
        {
            Tag _tag = db.Tags.Find(id);
            if (_tag != null)
                db.Tags.Remove(_tag);
        }

        public Tag Get(int id)
        {
            return db.Tags.Find(id);
        }

        public IEnumerable<Tag> GetAll()
        {
            return db.Tags;
        }

        public void Update(Tag value)
        {
            db.Entry(value).State = EntityState.Modified;
        }
    }
}
