using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Management.BusinessLogic;
using Management.Models;
using Management.Models.ViewModels.VM;
using Management.Models.ViewModels.Mappings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Principal;
using System.Security.Claims;

namespace Management.MVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserActions _userActions;
        private readonly IStoreActions _storeActions;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly ILogger<AccountController> _logger;

        public AccountController(IUserActions userActions,IStoreActions storeActions, SignInManager<AppUser> signInManager, ILogger<AccountController> logger)
        {
            _userActions = userActions;
            _storeActions = storeActions;
            _signInManager = signInManager;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpGet]
        // [Route("Acount/Profile/{Id:string}")]
        public async Task<IActionResult> Profile()
        {
            //get the id of the user and pass it as a parameter
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var result = await _storeActions.GetAllStoresBelongingToAUser(userId);
            var stores = StoreMappings.GetStoresForAUser(result);
            return View(stores);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginVM userLogin, string returnUrl = "")
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var user = await _userActions.LoginUser(userLogin.Email, userLogin.Password);
                    await _signInManager.SignInAsync(user, userLogin.RememberMe);
                    if (!string.IsNullOrWhiteSpace(returnUrl) && Url.IsLocalUrl(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }
                    return RedirectToAction("Index", "Home");
                }

                return View();
            }
            catch (AccessViolationException acex)
            {
                _logger.LogWarning(acex.Message);
                ModelState.AddModelError(string.Empty, acex.Message);
                return View();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message + ex.StackTrace);
                return View();
            }
        }
        
        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> SignUp(RegistrationVM userReg)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var user = await _userActions.RegisterUser(userReg.FirstName, userReg.LastName,
                        userReg.Email, userReg.Password, userReg.UserName);

                    ViewBag.User = $"{user.UserName} was created successfully. Login to access account details.";
                }
                return View();
            }
            catch (TimeoutException)
            {
                ViewData["Error"] = $"User was not created successfully";
                return View();

            }
            catch (Exception)
            {
                ViewData["Error"] = $"User was not created successfully";
                return View();
            }
        }
    }
}