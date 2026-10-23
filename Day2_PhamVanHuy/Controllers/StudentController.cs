using Microsoft.AspNetCore.Mvc;

namespace Day2_PhamVanHuy.Controllers
{
    public class StudentController : Controller
    {
        // ==============================================================
        // YÊU CẦU 2: CONVENTIONAL ROUTING & ATTRIBUTED ROUTING LÀM CHUNG
        // Cả 2 đều dùng chung 1 View duy nhất: Views/Student/Index.cshtml
        // ==============================================================

        // 1. Đến bằng Conventional Routing: /sinh-vien hoặc /Student/Index
        public IActionResult Index(int? id)
        {
            ViewBag.CurrentRoute = "Conventional Routing (Quy ước qua Program.cs)";
            ViewBag.ActiveUrl = "/sinh-vien";
            ViewBag.StudentId = id ?? 1;
            return View();
        }

        // 2. Đến bằng Attributed Routing: /sinh-vien-attr hoặc /sinh-vien-attr/101
        // Dùng chung View "Index", không tách View riêng
        [Route("sinh-vien-attr/{id:int?}")]
        public IActionResult Attr(int? id = 101)
        {
            ViewBag.CurrentRoute = "Attributed Routing (Thuộc tính [Route] trên Action)";
            ViewBag.ActiveUrl = $"/sinh-vien-attr/{id}";
            ViewBag.StudentId = id;
            return View("Index");
        }
    }
}
