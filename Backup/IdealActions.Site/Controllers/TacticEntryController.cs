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
    public class TacticEntryController : Controller
    {
         private Context db = new Context("ClubSiteDB");

        //
        // GET: /TacticEntry/

        public ActionResult Index()
        {
           ViewBag.CheckingBalance = db.GetTacticJournalTotal(User.Identity.Name.ToString());
           return View(db.TacticJournal.ToList().Where(x => x.UserName == User.Identity.Name.ToString()));
        }

        //
        // GET: /TacticEntry/Details/5

        public ActionResult Details(int id = 0)
        {
            TacticEntry tacticentry = db.TacticJournal.Find(id);
            if (tacticentry == null)
            {
                return HttpNotFound();
            }
            return View(tacticentry);
        }

        //
        // GET: /TacticEntry/Create

        public ActionResult Create()
        {
            TacticEntry tacticEntry = new TacticEntry() { TacticalDate = System.DateTime.Now, UserName = User.Identity.Name, Quantity = 1 };
            ViewBag.TacticList = db.GetTacticList(User.Identity.Name.ToString());
            return View(tacticEntry);
        }

        //
        // POST: /TacticEntry/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TacticEntry tacticentry)
        {
            if (ModelState.IsValid)
            {
                               
                db.TacticJournal.Add(tacticentry);
                if (tacticentry.tactic != null)
                {
                    Tactic myTactic = tacticentry.tactic;
                    db.Tactic.Attach(tacticentry.tactic);
                }
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tacticentry);
        }

        //
        // GET: /TacticEntry/Edit/5

        public ActionResult Edit(int id = 0)
        {
            TacticEntry tacticentry = db.TacticJournal.Find(id);
            ViewBag.TacticList = db.GetTacticList(User.Identity.Name.ToString());
            if (tacticentry == null)
            {
                return HttpNotFound();
            }
            return View(tacticentry);
        }

        //
        // POST: /TacticEntry/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TacticEntry tacticentry)
        {
            if (ModelState.IsValid)
            {
                

                db.Entry(tacticentry).State = EntityState.Modified;
                if (tacticentry.tactic != null)
                {
                    Tactic myTactic = tacticentry.tactic;
                    db.Tactic.Attach(tacticentry.tactic);
                }
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tacticentry);
        }

        //
        // GET: /TacticEntry/Delete/5

        public ActionResult Delete(int id = 0)
        {
            TacticEntry tacticentry = db.TacticJournal.Find(id);
            if (tacticentry == null)
            {
                return HttpNotFound();
            }
            return View(tacticentry);
        }

        //
        // POST: /TacticEntry/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TacticEntry tacticentry = db.TacticJournal.Find(id);
            
            db.TacticJournal.Remove(tacticentry);
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