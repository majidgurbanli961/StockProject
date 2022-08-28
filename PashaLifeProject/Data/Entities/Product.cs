using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace PashaLifeProject.Data.Entities
{
    public class Product
    {
        [Column("ProductID")]
        [Key]
        public int ProductId { get; set; }
        [NotNull]
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public DateTime Created { get; set; }
        [NotNull]
        public string State { get; set; }
        public bool IsDeleted { get; set; }
        [Column("ProductCategoryID")]
        public int ProductCategoryId { get; set; }
        public ProductCategory ProductCategory { get; set; }

    }
}
