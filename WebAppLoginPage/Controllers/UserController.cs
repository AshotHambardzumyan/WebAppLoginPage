using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using WebAppLoginPage.Models.Data;
using WebAppLoginPage.Models.Models;
using WebAppLoginPage.Services.Interface;

namespace WebAppLoginPage.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        // GET: UserController
        public ActionResult Index()
        {
            return View(_userService.GetAll());
        }

        public ActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SignIn(User user)
        {
            List<User> users = _userService.GetAll();
            string pass = user.Password.GetHashCode().ToString();

            for (int i = 0; i < users.Count; i++)
            {
                if ((user.Username == users[i].Username) && (pass == users[i].Password))
                {
                    return RedirectToAction(nameof(Index));
                }
            }

            return View();
        }

        // GET: UserController/Details/5
        public ActionResult Details(Guid id)
        {
            return View(_userService.Get(id));
        }

        // GET: UserController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(User user)
        {
            try
            {
                user.Id = Guid.NewGuid();
                string hashPassword = user.Password.GetHashCode().ToString();
                user.Password = hashPassword;
                _userService.Add(user);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UserController/Edit/5
        public ActionResult Edit(Guid id)
        {
            return View(_userService.Get(id));
        }

        // POST: UserController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Guid id, User user)
        {
            try
            {
                if (id != user.Id)
                {
                    return NotFound();
                }

                _userService.Update(user);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UserController/Delete/5
        public ActionResult Delete(Guid id)
        {
            return View(_userService.Get(id));
        }

        // POST: UserController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Guid id, User user)
        {
            try
            {
                if (id != user.Id)
                {
                    return NotFound();
                }

                _userService.Delete(id);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
