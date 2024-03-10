using Microsoft.AspNetCore.Mvc;
using Lazada.Entity;

namespace Lazada.Controllers
{
    public class AccountController : Controller
    {
        private readonly LazadaDbContext _context;
        public AccountController(LazadaDbContext context)
        {
            this._context = context;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            var account = (from user in _context.Account
                           where user.UserName == email && user.Password == password
                           select new { 
                               user.UserName, 
                               user.Password 
                           }).FirstOrDefault();
            if (account != null)
            {
                return Redirect(Url.Action("Index", "Home"));
            }
            return View();
            
        }
    }
}
