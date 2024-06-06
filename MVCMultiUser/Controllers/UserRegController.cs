using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCMultiUser.Models;

namespace MVCMultiUser.Controllers
{
    public class UserRegController : Controller
    {
        MVC_New_DBEntities dbobj = new MVC_New_DBEntities();
        // GET: UserReg
        public ActionResult Insert_Pageload()
        {
            return View();
        }
        public ActionResult Insert_click(UserInsert clsobj, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                if (file.ContentLength > 0)
                {
                    //folder save
                    string fname = Path.GetFileName(file.FileName);
                    var s = Server.MapPath("~/PHS");
                    string pa = Path.Combine(s, fname);
                    file.SaveAs(pa);
                    //for table save
                    var fullpath = Path.Combine("~\\PHS", fname);
                    clsobj.photo = fullpath;//set
                }
                var getmaxid = dbobj.sp_MaxIdLogin().FirstOrDefault();
                int mid = Convert.ToInt32(getmaxid);
                int regid = 0;
                if (mid == 0)
                {
                    regid = 1;
                }
                else
                {
                    regid = mid + 1;
                }
                //get
                dbobj.sp_userReg(regid, clsobj.name, clsobj.age, clsobj.address, clsobj.email, clsobj.photo);
                dbobj.sp_loginsert(regid, clsobj.username, clsobj.pass, "user");
                clsobj.usermsg = "successfully inserted";
                return View("Insert_Pageload", clsobj);
            }
            return View("Insert_Pageload", clsobj);
        }
    }
}