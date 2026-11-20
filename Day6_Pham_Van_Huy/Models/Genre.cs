using System.ComponentModel.DataAnnotations;

namespace Day6_Pham_Van_Huy.Models
{
    public class Genre
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Tên thể loại không được để trống")]
        [StringLength(100)]
        [Display(Name = "Thể loại")]
        public string Name { get; set; } = string.Empty;

        // Navigation property (1 Thể loại có nhiều Phim)
        public ICollection<Movie>? Movies { get; set; }
    }
}

