using Day_3_Pham_Van_Huy;
using Day_3_Pham_Van_Huy.Models;

namespace Day_3_Pham_Van_Huy.Data
{
    public class SeedData
    {
        public static List<Category> categories = new List<Category>
        {
            new Category() { Id = 1, Name = "Điện thoại thông minh", Price = 15000000, CategoryName = "Điện thoại", Description = "Các dòng smartphone iPhone, Samsung, Xiaomi" },
            new Category() { Id = 2, Name = "Laptop văn phòng", Price = 18000000, CategoryName = "Laptop", Description = "Laptop mỏng nhẹ, pin trâu phục vụ học tập và làm việc" },
            new Category() { Id = 3, Name = "Laptop Gaming", Price = 26000000, CategoryName = "Laptop", Description = "Laptop cấu hình cao, card đồ họa rời chuyên chơi game" },
            new Category() { Id = 4, Name = "Máy tính bảng (Tablet)", Price = 12000000, CategoryName = "Máy tính bảng", Description = "iPad, Galaxy Tab màn hình lớn tiện giải trí" },
            new Category() { Id = 5, Name = "Đồng hồ thông minh", Price = 6500000, CategoryName = "Đồng hồ", Description = "Smartwatch đo nhịp tim, bước chân và thông báo" },
            new Category() { Id = 6, Name = "Tai nghe không dây", Price = 3500000, CategoryName = "Âm thanh", Description = "Tai nghe Bluetooth chống ồn chủ động cao cấp" },
            new Category() { Id = 7, Name = "Bàn phím cơ", Price = 1800000, CategoryName = "Phụ kiện", Description = "Bàn phím cơ switch gõ êm, đèn LED RGB" },
            new Category() { Id = 8, Name = "Chuột Gaming", Price = 1200000, CategoryName = "Phụ kiện", Description = "Chuột máy tính DPI cao, độ trễ cực thấp" },
            new Category() { Id = 9, Name = "Màn hình máy tính", Price = 7500000, CategoryName = "Màn hình", Description = "Màn hình 2K, 4K tấm nền IPS tần số quét cao" },
        };
    }
}
