using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSF
{
    public class UserRepository
    {
        public bool Create(Tag tag)
        {
            using (var db = new AppContext())
            {                
                var addtag = db.Tags.Add(tag);
                db.SaveChanges();
                return true;
            }
        }
        
        public bool Read(int id, out Tag tag)
        {
            using (var db = new AppContext())
            {
                tag = db.Tags.Where(u => u.Id == id).FirstOrDefault();
                db.SaveChanges();
                return tag != null;
            }
        }
        
        public bool Update(int id, Tag tag)
        {
            using (var db = new AppContext())
            {
                var _tag = db.Tags.Where(u => u.Id == id).FirstOrDefault();
                _tag = tag;
                db.SaveChanges();
                return true;
            }
        }
        
        public bool Delete(Tag id)
        {
            using (var db = new AppContext())
            {
                var deltag = db.Tags.Remove(id);
                db.SaveChanges();
                return true;
            }            
        }
    }
}
