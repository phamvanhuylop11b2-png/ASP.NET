using Microsoft.AspNetCore.Mvc;

namespace Day2_PhamVanHuy.Components
{
    public class StudentStatsViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(string title = "Thống kê học tập")
        {
            // Logic C# độc lập trong ViewComponent
            var stats = new
            {
                Title = title,
                TotalCredits = 45,
                Gpa = 3.85,
                Status = "Đang học"
            };

            return View(stats);
        }
    }
}
