using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Management.BusinessLogic;
using Management.Models.ViewModels.Mappings;
using System.Threading.Tasks;

namespace Management.MVC.Controllers
{
    public class StoreController : Controller
    {
        private readonly IStoreActions _storeActions;
        private readonly ILogger<StoreController> _logger;

        public StoreController(IStoreActions storeActions, ILogger<StoreController> logger)
        {
            _storeActions = storeActions;
            _logger = logger;
        }
        
        public async Task<IActionResult> Store(string Id)
        {
            var result = await _storeActions.GetStore(Id);
            var store = StoreMappings.GetStore(result);
            return View(store);
        }
    }
}