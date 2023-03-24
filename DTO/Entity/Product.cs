using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DTO.Entity
{
    [Table("Product")]
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string? Name { get; set; }

        public string? Description { get; set; }

        public double? Price { get; set; }

        public string? Brand { get; set; }

        public int Stock { get; set; }

        public string? Image { get; set; }

        public double Rating { get; set; }

        public virtual ICollection<Category>? Categories { get; set; }

        public virtual ICollection<OrderDetail>? OrderDetails { get; set; }

        public virtual ICollection<Review>? Reviews { get; set; }

        public virtual ICollection<Cart>? Carts { get; set; }



    }

}


