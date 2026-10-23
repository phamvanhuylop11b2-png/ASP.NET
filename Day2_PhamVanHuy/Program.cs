namespace Day2_PhamVanHuy
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            // ---------------------------------------------------------
            // (2) CONVENTIONAL ROUTING (Định tuyến theo quy ước):
            // Được cấu hình tập trung trong file Program.cs
            // ---------------------------------------------------------

            // Conventional Route tùy chỉnh (Ánh xạ /sinh-vien tới StudentController)
            app.MapControllerRoute(
                name: "student_custom",
                pattern: "sinh-vien/{action=Index}/{id?}",
                defaults: new { controller = "Student" });

            // Conventional Route mặc định ({controller}/{action}/{id?})
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
