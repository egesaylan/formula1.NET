using Formula1.BusinessLayer;
using Formula1.BusinessLayer.Results;
using Formula1.Entities;
using Formula1.Entities.Messages;
using Formula1.Entities.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Formula1.Controlers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
           // if(TempData["mm"] != null)
           // {
           //     return View(TempData["mm"] as List<Note>);
           // }

            NoteManager nm = new NoteManager();

            return View(nm.GetAllNote().OrderByDescending(x=>x.ModifiedOn).ToList());
        }

        public ActionResult ByCategory(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            CategoryManager cm = new CategoryManager();
            Category cat = cm.GetCategoryById(id.Value);

            if (cat == null)
            {
                return HttpNotFound();

            }

            return View("Index", cat.Notes);
        }

        public ActionResult Schedule()
        {
            return View();
        }
        public ActionResult Standings()
        {
            return View();
        }

        public ActionResult ShowProfile()
        {
            Formula1User currentuser = Session["login"] as Formula1User;
            Formula1UserManager fum = new Formula1UserManager();
            BusinessLayerResult<Formula1User> res = fum.GetUserById(currentuser.Id);

            if(res.Errors.Count > 0)
            {

            }
            return View(res.Result);
        }

        public ActionResult EditProfile()
        {
            Formula1User currentuser = Session["login"] as Formula1User;
            Formula1UserManager fum = new Formula1UserManager();
            BusinessLayerResult<Formula1User> res = fum.GetUserById(currentuser.Id);

            if (res.Errors.Count > 0)
            {

            }
            return View(res.Result);
        }
        [HttpPost]
        public ActionResult EditProfile(Formula1User model, HttpPostedFileBase ProfileImage)
        {
            if (ProfileImage != null &&(ProfileImage.ContentType == "image/jpg" ||
             ProfileImage.ContentType == "image/jpeg" ||
             ProfileImage.ContentType == "image/png" ))
            {
                string filename = $"user_{model.Id}.{ProfileImage.ContentType.Split('/')[1]}";

                ProfileImage.SaveAs(Server.MapPath($"~/images/{filename}"));
                model.PP = filename;

            }
            Formula1UserManager fum = new Formula1UserManager();
            BusinessLayerResult<Formula1User> res = fum.UpdateProfile(model);

            Session["login"] = res.Result;
            return RedirectToAction("ShowProfile");
        }
        public ActionResult RemoveProfile()
        {
            Formula1User currentuser = Session["login"] as Formula1User;

            Formula1UserManager fum = new Formula1UserManager();
            BusinessLayerResult<Formula1User> res = fum.RemoveUserById(currentuser.Id);

            Session.Clear();
            return RedirectToAction("Index");
        }


        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginViewMdl model)
        {
            if (ModelState.IsValid)
            {
                Formula1UserManager fum = new Formula1UserManager();
                BusinessLayerResult<Formula1User> res = fum.LoginUser(model);

                if (res.Errors.Count > 0)
                {
                    if(res.Errors.Find(x=> x.Code == ErrorMessage.UserIsNotActive) != null)
                    {
                        ViewBag.SetLink = "http://HomeActivate/1234-456-12312";
                    }

                    res.Errors.ForEach(x => ModelState.AddModelError("", x.Message));
                    return View(model);
                }
                Session["login"] = res.Result;
                return RedirectToAction("Index");

            }
            return View();
        }

        public ActionResult Register()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Register(RegisterViewMDL model)
        {
            if (ModelState.IsValid)
            {
                Formula1UserManager fum = new Formula1UserManager();
                BusinessLayerResult<Formula1User> res = fum.RegisterUser(model);

                if(res.Errors.Count > 0)
                {
                    res.Errors.ForEach(x => ModelState.AddModelError("", x.Message));
                    return View(model);
                }

                
                /*Formula1User user = null;
                try
                {
                    fum.RegisterUser(model);
                }
                catch (Exception ex)
                {

                    ModelState.AddModelError("", ex.Message);
                }*/

                /*if(user == null)
                {
                    return View(model);
                }*/

                return RedirectToAction("RegisterOk");
            }
            return View(model);
        }
        public ActionResult RegisterOk()
        {
            return View();
        }

        public ActionResult ActivateUser(Guid activate_id)
        {
            return View();
        }
        public ActionResult LoginOut()
        {
            Session.Clear();
            return RedirectToAction("Index");
        }

        public ActionResult Drivers()
        {
            return View();
        }
        
    }
}