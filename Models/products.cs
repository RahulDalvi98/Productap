using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace productapp.Models
{
    [Table("products")]
    public class products
    {
        [Key]
        public int productID { get; set; }

        [Required(ErrorMessage = "Required")]
        [Display(Name = "Product Name")]
        public string productName { get; set; }

        public int categoryID { get; set; }

        [Display(Name = "Category Name")]
        [NotMapped]
        public String Category { get; set; }
    }
}