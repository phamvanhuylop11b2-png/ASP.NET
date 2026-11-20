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
