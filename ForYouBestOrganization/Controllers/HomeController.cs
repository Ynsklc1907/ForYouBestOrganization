using DataAccessLayer;
using DataAccessLayer.Entities;
using DataAccessLayer.Repositories;
using ForYouBestOrganization.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ForYouBestOrganization.Controllers
{
    public class HomeController : Controller
    {
        foryoubestDb _db;
            
            UserRepository _userRep;
        OrganizationRepository _orgRep;
            OrganizationUserRepository _OrgUserRep;

        public HomeController()
        {
            _db = new foryoubestDb();
            _userRep = new UserRepository(_db);
            _orgRep = new OrganizationRepository(_db);
            _OrgUserRep = new OrganizationUserRepository(_db);
            


        }
        public ActionResult Index()
        {
            List<Organization> asd = new List<Organization>();
            asd = _orgRep.Listele().OrderBy(c=>c.OrgDate).Take(6).ToList();
            return View(asd);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult UserList()
        {
            return View(_userRep.Listele());
        }

        public ActionResult UserAdd()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UserAdd(User usr)
        {
            User model = new User();
            string str = JsonConvert.SerializeObject(usr);
            model = JsonConvert.DeserializeObject<User>(str);
            _userRep.Add(model);
            return RedirectToAction("UserList");
        }

        public ActionResult UserEdit(int id)
        {
            var kk = _userRep.Find(id);
            return View(kk);
        }
        [HttpPost]
        public ActionResult UserEdit(User us)
        {
            var yy = _userRep.Find(us.Id);
            
            yy.UserName = us.UserName;
            yy.Password = us.Password;
            yy.UserType = us.UserType;
            yy.whoDoOrganizations_ = us.whoDoOrganizations_;
            yy.Age = us.Age;
            _db.SaveChanges();

            return RedirectToAction("UserList");
            



        }

        public ActionResult UserDelete(int id)
        {
            _userRep.Delete(id);
            return RedirectToAction("UserList");
        }

        public ActionResult OrganizationDelete(int id)
        {
            _orgRep.Delete(id);
            return RedirectToAction("OrganizationList");
        }

        public ActionResult OrganizationDetail(int id)
        {
            ViewData["Userlar"] = _userRep.Listele();
            return View(_orgRep.Find(id));

        }

        public ActionResult OrganizationList()
        {
            return View(_orgRep.Listele());
        }

        public ActionResult OrganizationAdd()
        {
            ViewData["Userlar"] = _userRep.Listele();




            return View();
        }
        [HttpPost]
        public ActionResult OrganizationAdd(OrganizationViewModel mod3l)
        {


            Organization oo = new Organization();

            oo.Name = mod3l.Name;
            oo.Description = mod3l.Description;
            oo.Place = mod3l.Place;
            oo.Organizer = _userRep.Find(mod3l.Organizer_Id);
            oo.OrgDate = mod3l.OrgDate;
            _orgRep.Add(oo);

            oo.ImageUrl = oo.Name + "_" + oo.Id + ".jpg";

            _orgRep.Update(oo);

            string imageway = ConfigurationManager.AppSettings["ImagePath"] + @"\" + oo.ImageUrl;

            Request.Files[0].SaveAs(imageway);



            return RedirectToAction("OrganizationList");
        }

        public ActionResult OrganizationEdit(int id)
        {
            ViewData["Userlar"] = _userRep.Listele();
            var cc = _orgRep.Find(id);
            return View(cc);
        }

        [HttpPost]
        public ActionResult OrganizationEdit(OrganizationViewModel ovm)
        {
            var nex = _orgRep.Find(ovm.Id);
            nex.Name = ovm.Name;
            nex.Description = ovm.Description;
            nex.OrgDate = ovm.OrgDate;
            nex.Place = ovm.Place;
            nex.Organizer = _userRep.Find(ovm.Organizer_Id);
            nex.ImageUrl = ovm.Name+"_"+ovm.Id+".jpg";

            _orgRep.Update(nex);

            string imageway = Server.MapPath("/Images/") + nex.ImageUrl;

            Request.Files[0].SaveAs(imageway);



            return RedirectToAction("OrganizationList");
        }

        public PartialViewResult OrgUserPartial(int id)
        {
            foryoubestDb db = new foryoubestDb();
            var list = (from f in db.OrganizationUsers.Include("Organizations").Include("Users")
                        where f.Organizations.Id == id
                        select f).ToList();
            
            ViewData["org_Id"] = id;
            ViewData["Userlar"]=_userRep.Listele();
                                   


           

            return PartialView(list);
        }

        public void UserOrg_userAdd(int org_Id,int user_Id)
        {
            OrganizationUser gg = new OrganizationUser();
            gg.Organizations = _orgRep.Find(org_Id);
            gg.Users = _userRep.Find(user_Id);
            _OrgUserRep.Add(gg);
        }
    

    }
}