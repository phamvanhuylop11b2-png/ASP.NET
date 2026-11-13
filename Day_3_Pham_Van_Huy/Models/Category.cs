using System.ComponentModel.DataAnnotations;

namespace Day_3_Pham_Van_Huy.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Name must be between 3 and 100 characters.")]
        [Display(Name = "Name")]
        public string? Name { get; set; }

        [Display(Name = "Price")]
        public decimal Price { get; set; }

        [Display(Name = "Category")]
        public string? CategoryName { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; } = string.Empty;

        // Navigation property & hỗ trợ tương thích
        public int CategoryId { get => Id; set => Id = value; }
        public ICollection<Product>? Products { get; set; }
    }
}
