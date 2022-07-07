using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCity.Controllers
{
    public class UsersController : Controller
    {
        private readonly DataBaseContext db;
        public UsersController(DataBaseContext context)
        {
            db = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(db.Users);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            return View(await db.Users.FindAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> DeletePost(int id)
        {
            db.Users.Remove(db.Users.Find(id));
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreatePost(string Email, string Password)
        {
            await db.Users.AddAsync(new() { Login = Email, Password = Password });
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id) 
        {
            return View(await db.Users.FindAsync(id));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id) 
        {
            return View(await db.Users.FindAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> EditPost(int id, string Email, string Password) 
        {
            Models.User user = await db.Users.FindAsync(id);
            user.Login = Email;
            user.Password = Password;
            db.Users.Update(user);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
