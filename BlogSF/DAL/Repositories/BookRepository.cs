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
    public class BookRepository//<T>: IBaseRepositories<T>
    {
        #region
        ///// <summary>
        ///// Выбор всех книг
        ///// </summary>
        //public List<Book> SelectAllBooks()
        //{
        //    using (var db = new AppContext())
        //    {                
        //        return db.Books.ToList();
        //    }
        //}
        ///// <summary>
        ///// Выбор книги по id
        ///// </summary>
        ///// <param name="id"></param>
        //public Book SelectBookId(int id)
        //{
        //    using (var db = new AppContext())
        //    {
        //        return db.Books.Where(book => book.Id == id).FirstOrDefault();
        //    }
        //}
        ///// <summary>
        ///// Изменение года выпуска книги по id
        ///// </summary>
        ///// <param name="id"></param>
        ///// <param name="year"></param>
        ///// <returns></returns>
        //public bool UpdateYearBook(int id, int year)
        //{
        //    using (var db = new AppContext())
        //    {
        //        var _book = db.Books.Where(book => book.Id == id).FirstOrDefault();
        //        _book.Year = year;
        //        return true;
        //    }
        //}
        ///// <summary>
        ///// Добавление книги
        ///// </summary>
        ///// <param name="book">книга</param>
        ///// <returns></returns>
        //public bool AddBook(Book book)
        //{
        //    using (var db = new AppContext())
        //    {
        //        var AddBook = db.Books.Add(book);
        //        db.SaveChanges();
        //        return true;
        //    }
        //}
        ///// <summary>
        ///// Удаление книги
        ///// </summary>
        ///// <param name="id"></param>
        ///// <returns></returns>
        //public bool DeleteBook(Book id)
        //{
        //    using (var db = new AppContext())
        //    {
        //        var DelBok = db.Books.Remove(id);
        //        db.SaveChanges();
        //        return true;
        //    }
        //}
        ///// <summary>
        ///// Получать количество книг определенного автора в библиотеке.
        ///// </summary>
        ///// <param name="writer"></param>
        ///// <returns></returns>
        //public int SelectBookForWriter(string writer)
        //{
        //    using (var db = new AppContext())
        //    {
        //        return db.Books.Where(x => x.Writer.Name == writer).Count();
        //    }
        //}
        ///// <summary>
        ///// Количество книг определённого жанра
        ///// </summary>
        ///// <param name="genre"></param>
        ///// <returns></returns>
        ////public int SelectBookForGenre(string genre)
        ////{
        ////    using (var db = new AppContext())
        ////    {
        ////        return db.Books.Where(x => x.Genre.Name == genre).Count();
        ////    }
        ////}
        ///// <summary>
        /////Есть ли книга автора 
        ///// </summary>
        ///// <param name="writer"></param>
        ///// <param name="name"></param>
        ///// <returns></returns>
        //public bool IfBookWriter(string writer, string name)
        //{
        //    using (var db = new AppContext())
        //    {
        //        var count = db.Books.Where(x => x.Name == name).Where(x => x.Writer.Name == writer).Count();
        //        return (count > 0) ? true : false;
        //    }
        //}
        ///// <summary>
        /////Взял ли читатель книгу 
        ///// </summary>
        ///// <param name="writer"></param>
        ///// <param name="name"></param>
        ///// <returns></returns>
        //public bool IfBookOfUser(string user, string book)
        //{
        //    using (var db = new AppContext())
        //    {
        //        var count = db.Books.Where(x => x.Name == book).Where(x => x.User.Name == user).Count();
        //        return (count > 0) ? true : false;
        //    }
        //}
        ///// <summary>
        ///// Книга, которая вышла позже всех
        ///// </summary>
        ///// <returns></returns>
        //public  Book BookOfPast()
        //{
        //    using (var db = new AppContext())
        //    {
        //        var MaxYear = db.Books.OrderBy(x => x.Year).Max(x => x.Year);
        //        return db.Books.Where(u => u.Year == MaxYear).First();                   
        //    }
        //}
        ///// <summary>
        ///// Выбор списка книг одного жанра за период
        ///// </summary>
        ///// <param name="genre">жанр</param>
        ///// <param name="periodStart">год начала выборки включительно</param>
        ///// <param name="periodEnd">год окончания выборки включительно</param>
        ///// <returns></returns>
        ////public List<Book> SelectBookGenreInPeriod(string genre, int periodStart, int periodEnd)
        ////{
        ////    using (var db = new AppContext())
        ////    {
        ////        //return db.Books.Where(x => x.Genre.Name == genre).ToList();
        ////        var listBook = from Book in db.Books
        ////                       where Book.Genre.Name == genre
        ////                       && Book.Year > periodStart 
        ////                       && Book.Year < periodEnd
        ////                       select Book;
                
        ////        return listBook.ToList();
        ////    }            
        ////}
        ///// <summary>
        ///// Получение списка всех книг, отсортированного в порядке убывания года их выхода.
        ///// </summary>
        ///// <returns></returns>
        //public List<Book> SelectAllBooksSort()
        //{
        //    using (var db = new AppContext())
        //    {
        //        return db.Books.OrderBy(x => x.Year).Reverse().ToList();                
        //    }
        //}
        ///// <summary>
        ///// Выбор всех книг, отсортирован по алфавиту
        ///// </summary>
        ///// <returns></returns>
        //public List<Book> SelectAllBooksSortAlf()
        //{
        //    using (var db = new AppContext())
        //    {
        //        return db.Books.OrderBy(x => x.Year).ToList();
        //    }
        //}

        ///// <summary>
        ///// Количество книг у пользователя, взятых в библиотеке
        ///// </summary>
        ///// <param name="user"></param>
        ///// <returns></returns>
        //public int CountBookForUser(string user)
        //{
        //    using (var db = new AppContext())
        //    {                
        //        return db.Books.Where(u => u.Author == user).Count();
        //    }
        //}
        #endregion
        /// <summary>
        /// Создание статьи
        /// </summary>
        /// <param name="book"></param>
        /// <returns></returns>
        public bool Create(Book book)
        {
            using (var db = new AppContext())
            {                
                var AddBook = db.Books.Add(book);
                db.SaveChanges();
                return true;
            }
        }
        /// <summary>
        /// Получение статьи
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Read(int id, out Book book)
        {
            using (var db = new AppContext())
            {
                book = db.Books.Where(book => book.Id == id).FirstOrDefault();                
                return book !=null;
            }
        }
        /// <summary>
        /// Изменение статьи
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public bool Update(Book thebook)
        {
            using (var db = new AppContext())
            {
                var _book = db.Books.Where(book => book.Id == thebook.Id).FirstOrDefault();
                _book = thebook;
                db.SaveChanges();
                return _book != null;
            }
        }
        /// <summary>
        /// Удаление статьи
        /// </summary>
        /// <param name="book"></param>
        /// <returns></returns>
        public bool Delete(Book book)
        {
            using (var db = new AppContext())
            {
                var DelBok = db.Books.Remove(book);
                db.SaveChanges();
                return true;
            }
        }
    }
}
