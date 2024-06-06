using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCMultiUser.Controllers
{
    public class SelectAllUsersController : Controller
    {
        MVC_New_DBEntities dbobj = new MVC_New_DBEntities();
        // GET: SelectAllUsers
        public ActionResult DisplayAll_SP_Load()
        {
            var data = dbobj.sp_SelectAllUsers().ToList();
            ViewBag.userdetails = data;
            return View();
        }
    }
}