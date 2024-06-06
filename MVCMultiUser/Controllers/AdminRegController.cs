using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCMultiUser.Models;

namespace MVCMultiUser.Controllers
{
    public class AdminRegController : Controller
    {
        MVC_New_DBEntities dbobj = new MVC_New_DBEntities();
        // GET: AdminReg
        public ActionResult Insertadmin_Pageload()
        {
            return View();
        }
        public ActionResult Insertadmin_click(AdminInsert clsobj)
        { 
            if (ModelState.IsValid)
            {
                var getmaxid = dbobj.sp_MaxIdLogin().FirstOrDefault();
                int mid = Convert.ToInt32(getmaxid);
                int regid = 0;
                if(mid == 0)
                {
                    regid = 1;

                }
                else
                {
                    regid = mid + 1;
                }
                //get
                dbobj.sp_adminReg(regid, clsobj.name, clsobj.address, clsobj.phone, clsobj.email);
                dbobj.sp_loginsert(regid, clsobj.username, clsobj.pass, "admin");
                clsobj.adminmsg = "successfully inserted";
                return View("Insertadmin_Pageload", clsobj);
            }
            return View("Insertadmin_Pageload", clsobj);
        }
    }
}