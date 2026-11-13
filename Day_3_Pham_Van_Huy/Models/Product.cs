using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Day_3_Pham_Van_Huy.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Phải nhập tên sản phẩm")]
        [StringLength(100)]
        public string? Name { get; set; }

        public string? Description { get; set; }

        // Các thuộc tính giữ lại từ video bài học trước (nếu bạn vẫn dùng)
        public decimal ProductPrice { get; set; }

        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public Category? Category { get; set; }

        // Hỗ trợ cả 2 cách gọi thuộc tính (ProductId / ProductName)
        public int ProductId { get => Id; set => Id = value; }
        public string? ProductName { get => Name; set => Name = value; }
    }
}
