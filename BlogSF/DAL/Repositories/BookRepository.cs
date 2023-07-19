using BlogSF.DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BlogSF
{
    public class BookRepository : IBaseRepositories<Book>
    {
        private readonly AppContext db;
        public BookRepository(AppContext contex)
        {
            this.db = contex;
        }

        public IEnumerable<Book> GetAll()
        {
            return db.Books;
        }

        public Book Get(int id)
        {
            return db.Books.Find(id);
        }

        public void Create(Book book)
        {            
            db.Books.Add(book);            
        }
 
        public void Update(Book value)
        {
            db.Entry(value).State = EntityState.Modified;
        }
        public void Delete(int id)
        {
            Book book = db.Books.Find(id);
            if (book != null)
                db.Books.Remove(book);            
        }
    }
}
