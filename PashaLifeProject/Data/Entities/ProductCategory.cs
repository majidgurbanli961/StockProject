using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PashaLifeProject.Data.Entities
{
    
    public class ProductCategory
    {
        [Column("CategoryID")]
        [Key]
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public List<Product> Products { get; set; }

    }
}
