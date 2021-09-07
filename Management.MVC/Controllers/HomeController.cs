using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Management.BusinessLogic;
using Management.Models.ViewModels.Mappings;
using Management.MVC.Models;

namespace StoreManagement.MVCWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IStoreActions _storeActions;
        private readonly ILogger<HomeController> _logger;


        public HomeController(IStoreActions storeActions, ILogger<HomeController> logger)
        {
            _storeActions = storeActions;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _storeActions.GetAllStores();
            var stores = StoreMappings.GetAllStoresForDisplay(result);
            return View(stores);
        }

        [Authorize]
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}