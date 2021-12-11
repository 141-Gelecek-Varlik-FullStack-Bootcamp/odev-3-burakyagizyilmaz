using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odev3_Data.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        public decimal? Stock { get; set; }

        public decimal? Price { get; set; }

        public DateTime CreatedOn { get; set; }

        [Required]
        public int CreatedUserId { get; set; }

        [ForeignKey("CreatedUserId")]
        public User CreatedBy { get; set; }

        public DateTime LastModifiedOn { get; set; }

        public int? LastModifiedId { get; set; }

        [ForeignKey("LastModifiedId")]
        public User LastModifiedBy { get; set; }

    }
}
