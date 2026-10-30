using Day_3_Pham_Van_Huy.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Day_3_Pham_Van_Huy.Controllers
{
    public class CategoryController : Controller
    {
        // GET: CategoryController
        public ActionResult Index()
        {
            return View(SeedData.categories);
        }

        // GET: CategoryController/Details/5
        public ActionResult Details(int id)
        {
            //lay ra category co id truyen vao tu SeedData
            var category = SeedData.categories.FirstOrDefault(c => c.Id == id);
            //neu category==null thi tra ve trang loi
            if (category == null)
            {
                return NotFound();
            }
            //neu category khac null thi tra ve view va truyen category vao view
            return View(category);
        }

        // GET: CategoryController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategoryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([FromForm] Models.Category category)
        {
            if (ModelState.IsValid)
            {
                if (category.Id == 0)
                {
                    category.Id = SeedData.categories.Any() ? SeedData.categories.Max(c => c.Id) + 1 : 1;
                }
                // them category vao danh sach SeedData.categories
                SeedData.categories.Add(category);
                return RedirectToAction(nameof(Index));
            }
            
            return View(category);
        }

        // GET: CategoryController/Edit/5
        public ActionResult Edit([FromRoute] int id)
        {
            var category = SeedData.categories.FirstOrDefault(c => c.Id == id);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        // POST: CategoryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([FromForm] Models.Category category)
        {
            var existingCategory = SeedData.categories.FirstOrDefault(c => c.Id == category.Id);
            if (existingCategory == null)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                existingCategory.Name = category.Name;
                existingCategory.Description = category.Description;
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }

        // GET: CategoryController/Delete/5
        public ActionResult Delete(int id)
        {
            var category = SeedData.categories.FirstOrDefault(c => c.Id == id);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        // POST: CategoryController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed([FromRoute] int id)
        {
            var existingCategory = SeedData.categories.FirstOrDefault(c => c.Id == id);
            if (existingCategory == null)
            {
                return NotFound();
            }
            SeedData.categories.Remove(existingCategory);
            return RedirectToAction(nameof(Index));
        }
    }
}
