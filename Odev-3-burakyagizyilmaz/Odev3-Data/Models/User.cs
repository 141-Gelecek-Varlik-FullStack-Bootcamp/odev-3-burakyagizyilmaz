using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odev3_Data.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage ="Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [StringLength(maximumLength:16, ErrorMessage = "Must between 6 and 16 character ", MinimumLength =6)]
        public string Password { get; set; }

        [Required]
        public int UserGroupId { get; set; }

        [ForeignKey("UserGroupId")]
        public UserGroup UserGroup { get; set; }
    }
}
