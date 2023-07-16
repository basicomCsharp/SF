using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace EFCore
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }               
        public int Year { get; set; }        
        public User User { get; set; }
        public Comment Writer { get; set; }        
    }
}
