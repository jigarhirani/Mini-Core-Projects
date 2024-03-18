using Microsoft.AspNetCore.Mvc;

namespace MiniCoreProjects.Controllers
{
    public class SearchController : Controller
    {
        private readonly List<string> items = new List<string>
        {
            "Apple", "Banana", "Orange", "Mango", "Grapes"
        };

        [HttpPost]
        public IActionResult Search(string query)
        {
            if (!string.IsNullOrEmpty(query))
            {
                var results = items.Where(item => item.ToLower().Contains(query.ToLower())).ToList();
                return Json(results);
            }

            return Json(new List<string>());
        }
    }
}
