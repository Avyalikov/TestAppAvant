using Microsoft.AspNetCore.Mvc;
using TestApp.Interfaces;
using TestApp.Models;

namespace TestApp.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class HomeController : Controller
    {
        public IContractorsService contractorsService;

        public HomeController(IContractorsService service)
        {
            contractorsService = service;
        }

        /// <summary>
        /// Homepage
        /// </summary>
        [HttpGet]
        public ActionResult Index()
        {
            var result = contractorsService.FindAll();
            return View(result);
        }

        /// <summary>
        /// View form for new contractor
        /// </summary>
        // GET: HomeController/AddContractor
        [HttpGet]
        public IActionResult AddContractor()
        {
            return View();
        }

        /// <summary>
        /// Post form with new contractor
        /// </summary>
        // Post: HomeController/AddContractor
        [HttpPost]
        public IActionResult AddContractor([FromForm] Contractor contractor)
        {
            //Contractor contractor = new Contractor() { Name = Name, INN = INN, KPP = KPP};
            if (contractor.Type == Contractor.ContractorType.Сompany && contractor.KPP is null)
            {
                ViewBag.Title = "КПП обязателен для юридических лиц";
                return View("Result");
            }

            ViewBag.Title = contractorsService.Insert(contractor);
            return View("Result");
        }
    }
}
