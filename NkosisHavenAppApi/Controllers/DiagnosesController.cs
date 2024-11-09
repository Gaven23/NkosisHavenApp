using Microsoft.AspNetCore.Mvc;

namespace NkosisHavenAppApi.Controllers
{
    public class DiagnosesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
