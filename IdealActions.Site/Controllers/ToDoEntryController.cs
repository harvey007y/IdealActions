using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IdealActions.Domain;
using IdealActions.Infrastructure;

namespace IdealActions.Site.Controllers
{
     [Authorize()]
    public class ToDoEntryController : Controller
    {
         private Context db = new Context("ClubSiteDB");

        //
        // GET: /ToDoEntry/

        public ActionResult Index()
        {
            ViewBag.CheckingBalance = db.GetToDoListTotal(User.Identity.Name.ToString());
            return View(db.ToDoList.ToList().Where(x => x.UserName == User.Identity.Name.ToString()));
        }

        //
        // GET: /ToDoEntry/Details/5

        public ActionResult Details(int id = 0)
        {
            ToDoEntry todoentry = db.ToDoList.Find(id);
            if (todoentry == null)
            {
                return HttpNotFound();
            }
            return View(todoentry);
        }

        //
        // GET: /ToDoEntry/Create

        public ActionResult Create()
        {
            ToDoEntry toDoEntry = new ToDoEntry() { ToDoDate = System.DateTime.Now, UserName = User.Identity.Name, Quantity = 1 };
            ViewBag.TacticList = db.GetTacticList(User.Identity.Name.ToString());
            ViewBag.ToDoStatusList = db.ToDoStatus.ToList<ToDoStatus>();
            return View(toDoEntry);
        }

        //
        // POST: /ToDoEntry/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ToDoEntry todoentry)
        {
            if (ModelState.IsValid)
            {

                db.ToDoList.Add(todoentry);
                if (todoentry.tactic != null)
                {
                    db.Tactic.Attach(todoentry.tactic);
                }
                if (todoentry.toDoStatus != null)
                {
                    db.ToDoStatus.Attach(todoentry.toDoStatus);
                }
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(todoentry);
        }

        //
        // GET: /ToDoEntry/Edit/5

        public ActionResult Edit(int id = 0)
        {
            ToDoEntry todoentry = db.ToDoList.Find(id);
            ViewBag.TacticList = db.GetTacticList(User.Identity.Name.ToString());
            ViewBag.ToDoStatusList = db.ToDoStatus.ToList<ToDoStatus>();
            if (todoentry == null)
            {
                return HttpNotFound();
            }
            
            return View(todoentry);
        }

        //
        // POST: /ToDoEntry/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ToDoEntry todoentry)
        {
            if (ModelState.IsValid)
            {
                db.Entry(todoentry).State = System.Data.Entity.EntityState.Modified;
                //if (todoentry.tactic != null)
                //{
                //    db.Tactic.Attach(todoentry.tactic);
                //}
                db.SaveChanges();
                return RedirectToAction("Index");
                
            }
            return View(todoentry);
        }
        //
        // GET: /ToDoEntry/Delete/5

        public ActionResult Delete(int id = 0)
        {
            ToDoEntry todoentry = db.ToDoList.Find(id);
            if (todoentry == null)
            {
                return HttpNotFound();
            }
            return View(todoentry);
        }

        //
        // POST: /ToDoEntry/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ToDoEntry todoentry = db.ToDoList.Find(id);
            db.ToDoList.Remove(todoentry);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}