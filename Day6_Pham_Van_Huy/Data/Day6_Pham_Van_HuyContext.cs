using Microsoft.EntityFrameworkCore;
using Day6_Pham_Van_Huy.Models;

public class Day6_Pham_Van_HuyContext(DbContextOptions<Day6_Pham_Van_HuyContext> options) : DbContext(options)
{
    public DbSet<Product> Product { get; set; } = default!;
    public DbSet<Genre> Genre { get; set; } = default!;
    public DbSet<Movie> Movie { get; set; } = default!;
}
