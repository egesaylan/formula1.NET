using Formula1.BusinessLayer;
using Formula1.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Formula1.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        /*public ActionResult Select(int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            CategoryManager cm = new CategoryManager();
            Category cat = cm.GetCategoryById(id.Value);

            if(cat == null)
            {
                return HttpNotFound();
                
            }

            TempData["mm"] = cat.Notes;
            return RedirectToAction("Index", "Home");
        }*/
    }
}