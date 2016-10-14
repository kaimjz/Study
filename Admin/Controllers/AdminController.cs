using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models;
using Services;

namespace Admin.Controllers
{
    public class AdminController : Controller
    {
        //
        // GET: /Admin/
        public ActionResult UserIndex()
        {
            List<Sys_User> userList = null;
            if (Request.HttpMethod.Equals("Post", StringComparison.CurrentCultureIgnoreCase))
            {
                string name = Request["username"] ?? "";
                userList = UserService.FindUserList(p => p.UserName.Contains(name));
            }
            else
            {
                userList = UserService.FindUserList();
            }
            ViewBag.Count = userList.Count();
            return View(userList);
        }

        public ActionResult UserEdit()
        {
            return View();
        }
        [HttpPost]
        public ActionResult UserEdit(FormCollection collection)
        {
            //Sys_User user = collection as Sys_User;
            return View("UserIndex");
        }
    }
}