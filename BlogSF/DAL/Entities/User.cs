using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSF
{
    //пользователь имеет имя, почту
    public class User
    {
        [Key]
        public int Id { get; set; }//public Guid Id { get; set; } = Guid.NewGuid();
        [Required]
        public string FirstName { get; set; } = String.Empty;
        [Required]
        public string LastName { get; set; } = String.Empty;
        [Required]
        public string Email { get; set; } = String.Empty;
        
    }
}
