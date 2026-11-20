using Microsoft.EntityFrameworkCore;
using Day6_Pham_Van_Huy.Models;

namespace Day6_Pham_Van_Huy.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using var context = new Day6_Pham_Van_HuyContext(
                serviceProvider.GetRequiredService<DbContextOptions<Day6_Pham_Van_HuyContext>>());

            if (!context.Genre.Any())
            {
                var hanhDong = new Genre { Name = "Hành động" };
                var hoatHinh = new Genre { Name = "Hoạt hình" };

                context.Genre.AddRange(hanhDong, hoatHinh);
                context.SaveChanges();

                if (!context.Movie.Any())
                {
                    context.Movie.AddRange(
                        new Movie
                        {
                            Title = "Tom and Jerry",
                            ReleaseDate = DateTime.Parse("2026-01-01"),
                            Duration = 120,
                            GenreId = hanhDong.Id
                        },
                        new Movie
                        {
                            Title = "Doremon",
                            ReleaseDate = DateTime.Parse("2000-01-01"),
                            Duration = 30,
                            GenreId = hoatHinh.Id
                        }
                    );
                    context.SaveChanges();
                }
            }
            else if (!context.Movie.Any())
            {
                var hanhDong = context.Genre.FirstOrDefault(g => g.Name == "Hành động") ?? context.Genre.First();
                var hoatHinh = context.Genre.FirstOrDefault(g => g.Name == "Hoạt hình") ?? context.Genre.First();

                context.Movie.AddRange(
                    new Movie
                    {
                        Title = "Tom and Jerry",
                        ReleaseDate = DateTime.Parse("2026-01-01"),
                        Duration = 120,
                        GenreId = hanhDong.Id
                    },
                    new Movie
                    {
                        Title = "Doremon",
                        ReleaseDate = DateTime.Parse("2000-01-01"),
                        Duration = 30,
                        GenreId = hoatHinh.Id
                    }
                );
                context.SaveChanges();
            }
        }
    }
}

