using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Day6_Pham_Van_Huy.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Tiêu đề phim không được để trống")]
        [StringLength(150)]
        [Display(Name = "Title")]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "Ngày phát hành không được để trống")]
        [DataType(DataType.Date)]
        [Display(Name = "Date")]
        public DateTime ReleaseDate { get; set; }

        [Required(ErrorMessage = "Thời lượng phim không được để trống")]
        [Display(Name = "Duration")]
        public int Duration { get; set; }

        // Khóa ngoại GenreId (N - 1)
        [Required(ErrorMessage = "Vui lòng chọn thể loại")]
        [Display(Name = "Genre")]
        public int GenreId { get; set; }

        [ForeignKey("GenreId")]
        public Genre? Genre { get; set; }
    }
}

