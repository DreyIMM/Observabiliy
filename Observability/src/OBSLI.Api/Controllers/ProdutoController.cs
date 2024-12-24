using Microsoft.AspNetCore.Mvc;

namespace OBSLI.Api.Controllers
{
    public class ProdutoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
