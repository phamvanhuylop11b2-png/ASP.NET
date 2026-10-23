using Microsoft.AspNetCore.Mvc;

namespace Day2_PhamVanHuy.Controllers
{
    public class HelloController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        // =========================================================================
        // YÊU CẦU 2: CONVENTIONAL ROUTING & ATTRIBUTED ROUTING CÙNG VÀO TRANG WELCOME
        // =========================================================================

        // 1. CONVENTIONAL ROUTING (Định tuyến theo quy ước mặc định qua Program.cs):
        // URL: /Hello/Welcome?name=PhamVanHuy&ID=10
        public IActionResult Welcome(string name = "PhamVanHuy", int ID = 10)
        {
            ViewBag.Message = name;
            ViewData["id"] = ID;
            return View();
        }

        // 2. ATTRIBUTED ROUTING (Định tuyến bằng thuộc tính [Route] đặt trực tiếp):
        // URL: /chao-mung/PhamVanHuy/10
        // Gọi chung giao diện Welcome để hiển thị 10 dòng PhamVanHuy như ảnh 1!
        [Route("chao-mung/{name}/{ID:int}")]
        public IActionResult WelcomeAttr(string name, int ID)
        {
            ViewBag.Message = name;
            ViewData["id"] = ID;
            return View("Welcome");
        }
    }
}
