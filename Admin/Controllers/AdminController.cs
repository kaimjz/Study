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
            List<Sys_Role> roleList = RoleService.FindRoleList();
            ViewBag.SelectRoleList = new SelectList(roleList, "ID", "Name");
            return View();
        }
        [HttpPost]
        public string UserEdit(FormCollection form)
        {
            string loginname = form["loginName"] ?? "";
            string userName = form["userName"] ?? "";
            Guid roleID = new Guid(form["roleID"] ?? null);
            int status = int.Parse(form["status"] ?? "1");
            Sys_User model = new Sys_User()
            {
                ID = Guid.NewGuid(),
                LoginName = loginname,
                UserName = userName,
                RoleID = roleID,
                Status = status,
                CreateDate = DateTime.Now,
                LoginPwd = "111111"
            };
            return "1";
        }
    }
}