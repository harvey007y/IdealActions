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
    public class TacticController : Controller
    {
         private Context db = new Context("ClubSiteDB");

        //
        // GET: /Tactic/

        public ActionResult Index()
        {
            return View(db.Tactic.ToList().Where(x => x.UserName == User.Identity.Name.ToString()));
        }

        //
        // GET: /Tactic/Details/5

        public ActionResult Details(int id = 0)
        {
            Tactic tactic = db.Tactic.Find(id);
            if (tactic == null)
            {
                return HttpNotFound();
            }
            return View(tactic);
        }

        //
        // GET: /Tactic/Create

        public ActionResult Create()
        {
            Tactic tactic = new Tactic() { UserName = User.Identity.Name };
            ViewBag.StrategyList = db.GetStrategyList(User.Identity.Name.ToString());
            ViewBag.TacticAbstractionLevelList = db.TacticAbstractionLevel.ToList<TacticAbstractionLevel>();
            ViewBag.TacticAccountActionTypeList = db.TacticAccountActionType.ToList<TacticAccountActionType>();
            return View(tactic);
        }

        //
        // POST: /Tactic/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Tactic tactic)
        {

            
            if (ModelState.IsValid)
            {
                db.Tactic.Add(tactic);
                if (tactic.strategy != null)
                {
                db.Strategy.Attach(tactic.strategy);
                }
                if (tactic.tacticAbstractionLevel != null)
                {
                    db.TacticAbstractionLevel.Attach(tactic.tacticAbstractionLevel);
                }
                if (tactic.tacticAccountActionType != null)
                {
                    db.TacticAccountActionType.Attach(tactic.tacticAccountActionType);
                }
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tactic);
        }

        //
        // GET: /Tactic/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Tactic tactic = db.Tactic.Find(id);
            ViewBag.StrategyList = db.GetStrategyList(User.Identity.Name.ToString());
            ViewBag.TacticAbstractionLevelList = db.TacticAbstractionLevel.ToList<TacticAbstractionLevel>();
            ViewBag.TacticAccountActionTypeList = db.TacticAccountActionType.ToList<TacticAccountActionType>();
            if (tactic == null)
            {
                return HttpNotFound();
            }
            return View(tactic);
        }

        //
        // POST: /Tactic/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Tactic tactic)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tactic).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tactic);
        }

        //
        // GET: /Tactic/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Tactic tactic = db.Tactic.Find(id);
            if (tactic == null)
            {
                return HttpNotFound();
            }
            return View(tactic);
        }

        //
        // POST: /Tactic/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tactic tactic = db.Tactic.Find(id);
            db.Tactic.Remove(tactic);
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