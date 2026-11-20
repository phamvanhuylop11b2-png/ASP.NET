# Day 6 - ASP.NET Core MVC (Phạm Văn Huy)

Bài thực hành Buổi 6:
- Xây dựng quan hệ 1 - N giữa 2 bảng **Genre** (Thể loại) và **Movie** (Phim).
- Entity Framework Core Code-First với SQL Server LocalDB.
- Tạo Migration `AddGenreAndMovie` và nạp dữ liệu mẫu (Seed Data):
  - Thể loại: *Hành động*, *Hoạt hình*.
  - Phim:
    - `Tom and Jerry` (Năm: 2026, Thể loại: Hành động, Thời lượng: 120 phút)
    - `Doremon` (Năm: 2000, Thể loại: Hoạt hình, Thời lượng: 30 phút)
- Giao diện & Chức năng:
  - Danh sách phim hiển thị đúng các cột: `Id`, `Title`, `Date`, `Genre`, `Duration`.
  - Form Thêm mới / Sửa với Dropdown list chọn Thể loại (`GenreId`).
  - Quản lý danh mục Thể loại (`GenreController`).

## Ảnh minh chứng bài làm
Thư mục `anh_minh_chung/` chứa các hình ảnh chụp minh chứng mã nguồn và cấu hình:
1. `image.jpg`: ProductController & Solution Explorer
2. `image copy.png`: Model Product.cs với DataAnnotations
3. `image copy 2.png`: Day6_Pham_Van_Huy.csproj với EntityFrameworkCore packages
4. `image copy 3.png`: appsettings.json với Connection String LocalDB
5. `image copy 4.png`: Program.cs với DbContext và SeedData

