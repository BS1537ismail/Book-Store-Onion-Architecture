using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using OA.Data;
using OA.Repo;
using OA.Service;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace OA.Web.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService<User> context;

        public UserController(IUserService<User> contxt)
        {
            this.context = contxt;
        }
        public async Task<IActionResult> Index()
        {
            var data = await context.GetAll();
            
            return View(data);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(User user)
        {
            if(ModelState.IsValid)
            {
                await context.AddUser(user);
            }
            else return View(user);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var data = await context.EditUser(id);
            return View(data);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(User user)
        {
            if (ModelState.IsValid)
            {
                  context.UpdateUser(user);   
            }
            else return View(user);

            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Details(int id)
        {
            var data = await context.Details(id);
            return View(data);
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var data = await context.DeleteUser(id);
            return View(data);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(User user)
        {
            if(!ModelState.IsValid)
            {
                context.RemoveUser(user);

                return RedirectToAction("Index");
            }

              return View(user); 
          
        }
    }
}
