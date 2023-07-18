using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace BlogSF
{
    //Публикация имеет название, автора, дату публикации
    public class Book
    {
        [Key]
        public int Id { get; set; }//public Guid Id { get; set; } = Guid.NewGuid();
        [Required]
        public string Name { get; set; } = String.Empty;
        [Required]
        public string Author { get; set; } = String.Empty;
        public DateTime CreatedData { get; set; } = DateTime.Now;    
        public List<Comment> Comments { get; set; } = new List<Comment>();      
    }
}
