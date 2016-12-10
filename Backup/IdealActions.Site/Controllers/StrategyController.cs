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
    public class StrategyController : Controller
    {
        private Context db = new Context("ClubSiteDB");

        //
        // GET: /Strategy/

        public ActionResult Index()
        {
            return View(db.Strategy.ToList().Where(x=>x.UserName == User.Identity.Name.ToString()));
        }

        //
        // GET: /Strategy/Details/5

        public ActionResult Details(int id = 0)
        {
            Strategy strategy = db.Strategy.Find(id);
            if (strategy == null)
            {
                return HttpNotFound();
            }
            return View(strategy);
        }

        //
        // GET: /Strategy/Create

        public ActionResult Create()
        {
            Strategy strategy = new Strategy() { UserName = User.Identity.Name };
            return View(strategy);
        }

        //
        // POST: /Strategy/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Strategy strategy)
        {
            if (ModelState.IsValid)
            {
                db.Strategy.Add(strategy);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(strategy);
        }

        //
        // GET: /Strategy/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Strategy strategy = db.Strategy.Find(id);
            if (strategy == null)
            {
                return HttpNotFound();
            }
            return View(strategy);
        }

        //
        // POST: /Strategy/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Strategy strategy)
        {
            if (ModelState.IsValid)
            {
                db.Entry(strategy).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(strategy);
        }

        //
        // GET: /Strategy/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Strategy strategy = db.Strategy.Find(id);
            if (strategy == null)
            {
                return HttpNotFound();
            }
            return View(strategy);
        }

        //
        // POST: /Strategy/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Strategy strategy = db.Strategy.Find(id);
            db.Strategy.Remove(strategy);
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