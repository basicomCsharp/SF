using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSF
{
    //комментарий имеет заголовок, содержание
    public class Comment
    {
        [Key]
        public int Id { get; set; }//public Guid Id { get; set; } = Guid.NewGuid();
        [Required]
        public string Name { get; set; } = string.Empty;
        public string Text { get; set; } = string.Empty;
    }
}
