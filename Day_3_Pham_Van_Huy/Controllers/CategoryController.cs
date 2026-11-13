using Day_3_Pham_Van_Huy.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Day_3_Pham_Van_Huy.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ILogger<CategoryController> _logger;
        public CategoryController(ILogger<CategoryController> logger)
        {
            _logger = logger;
        }

        // =========================================================================
        // GET: /Category (TÌM KIẾM, SẮP XẾP, PHÂN TRANG)
        // =========================================================================
        public ActionResult Index(string? searchString, string? sortOrder, int pageNumber = 1, int page = 0, int pageSize = 4)
        {
            // Hỗ trợ cả 2 tên tham số pageNumber và page
            if (page > 0 && pageNumber == 1)
            {
                pageNumber = page;
            }

            var query = SeedData.categories.AsEnumerable();

            // 1. TÌM KIẾM (SEARCH) theo Tên hoặc Danh mục
            if (!string.IsNullOrEmpty(searchString))
            {
                query = query.Where(c =>
                    (c.Name != null && c.Name.Contains(searchString, StringComparison.OrdinalIgnoreCase)) ||
                    (c.CategoryName != null && c.CategoryName.Contains(searchString, StringComparison.OrdinalIgnoreCase)) ||
                    (c.Description != null && c.Description.Contains(searchString, StringComparison.OrdinalIgnoreCase))
                );
            }
            ViewBag.SearchString = searchString ?? "";

            // 2. SẮP XẾP (SORTING)
            ViewBag.IdSortParm = string.IsNullOrEmpty(sortOrder) ? "id_desc" : "";
            ViewBag.NameSortParm = sortOrder == "name_asc" ? "name_desc" : "name_asc";
            ViewBag.PriceSortParm = sortOrder == "price_asc" ? "price_desc" : "price_asc";
            ViewBag.CategorySortParm = sortOrder == "cat_asc" ? "cat_desc" : "cat_asc";
            ViewBag.CurrentSort = sortOrder ?? "";

            query = sortOrder switch
            {
                "id_desc" => query.OrderByDescending(c => c.Id),
                "name_asc" => query.OrderBy(c => c.Name),
                "name_desc" => query.OrderByDescending(c => c.Name),
                "price_asc" => query.OrderBy(c => c.Price),
                "price_desc" => query.OrderByDescending(c => c.Price),
                "cat_asc" => query.OrderBy(c => c.CategoryName ?? ""),
                "cat_desc" => query.OrderByDescending(c => c.CategoryName ?? ""),
                _ => query.OrderBy(c => c.Id)
            };

            var list = query.ToList();

            // 3. PHÂN TRANG (PAGINATION)
            int totalItems = list.Count;
            int totalPages = (int)Math.Ceiling((double)totalItems / pageSize);
            totalPages = Math.Max(1, totalPages);
            pageNumber = Math.Max(1, Math.Min(pageNumber, totalPages));

            var pagedCategories = list
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            ViewBag.PageNumber = pageNumber;
            ViewBag.TotalPages = totalPages;
            ViewBag.TotalItems = totalItems;
            ViewBag.HasPreviousPage = pageNumber > 1;
            ViewBag.HasNextPage = pageNumber < totalPages;

            return View(pagedCategories);
        }

        // GET: CategoryController/Details/5
        public ActionResult Details(int id)
        {
            var category = SeedData.categories.FirstOrDefault(c => c.Id == id);
            if (category == null)
            {
                return NotFound();
            }
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
        public ActionResult Create(Models.Category collection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (collection.Id == 0)
                    {
                        collection.Id = SeedData.categories.Any() ? SeedData.categories.Max(c => c.Id) + 1 : 1;
                    }
                    SeedData.categories.Add(collection);
                    return RedirectToAction(nameof(Index));
                }
                return View(collection);
            }
            catch
            {
                return View(collection);
            }
        }

        // ==========================================
        // HÀM SỬA (EDIT)
        // ==========================================

        // GET: CategoryController/Edit/5
        public ActionResult Edit(int id)
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
        public ActionResult Edit(int id, [FromForm] Models.Category category)
        {
            var targetId = category.Id != 0 ? category.Id : id;
            var existingCategory = SeedData.categories.FirstOrDefault(c => c.Id == targetId);
            if (existingCategory == null)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                existingCategory.Name = category.Name;
                existingCategory.Price = category.Price;
                existingCategory.CategoryName = category.CategoryName;
                existingCategory.Description = category.Description;
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }

        // ==========================================
        // HÀM XÓA (DELETE)
        // ==========================================

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
        public ActionResult DeleteConfirmed(int id)
        {
            var existingCategory = SeedData.categories.FirstOrDefault(c => c.Id == id);
            if (existingCategory != null)
            {
                SeedData.categories.Remove(existingCategory);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
