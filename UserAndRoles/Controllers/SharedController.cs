using UserAndRoles.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UserAndRoles.Controllers
{
    public class SharedController : Controller
    {        
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetUsers()
        {
            using (ApplicationDbContext dc = new ApplicationDbContext())
            {
               // var employees = dc.Users.OrderBy(a => a.UserName).ToList();

                var users = from r in dc.Users.Where(a => a.UserName != "Admin")
                               select new { r.UserName, r.PhoneNumber,r.Email,r.Id };

                //return response.users.da.Data.Commissions.Where(c => c.customerEmail == customerEmail);
                return Json(new { data = users.ToList() }, JsonRequestBehavior.AllowGet);
            }
        }

        //[HttpGet]
        //public ActionResult Save(int id)
        //{
        //    //using (MyDatabaseEntities dc = new MyDatabaseEntities())
        //    using (ApplicationDbContext dc = new ApplicationDbContext())
        //    {
        //        var v = dc.Users.Where(a => a.UserName.ToString().Count() == id).FirstOrDefault();
        //        return View(v);
        //    }
        //}

      //  [HttpPost]
        //public ActionResult Save(User user)
        //{
        //    bool status = false;
        //    if (ModelState.IsValid)
        //    {
        //        using (ApplicationDbContext dc = new ApplicationDbContext())
        //        {
        //            if (user. > 0)
        //            {
        //                //Edit 
        //                var v = dc.Users.Where(a => a.UserId == user.UserId).FirstOrDefault();
        //                if (v != null)
        //                {
        //                    v.UserName = user.UserName;
        //                    v.PhoneNumber = user.PhoneNumber;
        //                    //v.EmailID = emp.EmailID;
        //                    //v.City = emp.City;
        //                    //v.Country = emp.Country;
        //                }
        //            }
        //            else
        //            {
        //                //Save
        //                dc.Employees.Add(emp);
        //            }
        //            dc.SaveChanges();
        //            status = true;
        //        }
        //    }
        //    return new JsonResult { Data = new { status = status } };
        //}


        [HttpGet]
        public ActionResult Delete(String UserName)
        {
            using (ApplicationDbContext dc = new ApplicationDbContext())
            {
                var v = dc.Users.Where(a => a.UserName == UserName).FirstOrDefault();
                if (v != null)
                {
                    return View(v);
                }
                else
                {
                    return HttpNotFound();
                }
            }
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteEmployee(String UserName)
        {
            bool status = false;
            using (ApplicationDbContext dc = new ApplicationDbContext())
            {
                var v = dc.Users.Where(a => a.UserName == UserName).FirstOrDefault();
                if (v != null)
                {
                    dc.Users.Remove(v);
                    dc.SaveChanges();
                    status = true;
                }
            }
            return new JsonResult { Data = new { status = status } };
        }
    }

}