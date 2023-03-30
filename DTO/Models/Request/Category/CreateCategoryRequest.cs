using System;
using System.ComponentModel.DataAnnotations;

namespace DTO.Models.Request.Category
{
    public class CreateCategoryRequest
    {
        [Required]
        [MaxLength(255)]
        public string Name { get; set; } = null!;
    }

}