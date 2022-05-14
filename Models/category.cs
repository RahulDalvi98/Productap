using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace productapp.Models
{
    [Table("category")]
    public class category
    {
        [Key]
        public int categoryID { get; set; }

        public String categoryName { get; set; }
    }
}