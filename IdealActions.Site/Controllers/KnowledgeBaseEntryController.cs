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
    public class KnowledgeBaseEntryController : Controller
    {
        private Context db = new Context("ClubSiteDB");

        //
        // GET: /KnowledgeBaseEntry/

        public ActionResult Index()
        {
            return View(db.KnowledgeBaseEntry.ToList().Where(x => x.UserName == User.Identity.Name.ToString()));
        }

        //
        // GET: /KnowledgeBaseEntry/Details/5

        public ActionResult Details(int id = 0)
        {
            KnowledgeBaseEntry knowledgebaseentry = db.KnowledgeBaseEntry.Find(id);
            if (knowledgebaseentry == null)
            {
                return HttpNotFound();
            }
            return View(knowledgebaseentry);
        }

        //
        // GET: /KnowledgeBaseEntry/Create

        public ActionResult Create()
        {
            KnowledgeBaseEntry knowledgeBaseEntry = new KnowledgeBaseEntry() { UserName = User.Identity.Name };

            ViewBag.KnowledgeBaseCategoryList = db.GetKnowledgeBaseCategoryList(User.Identity.Name.ToString());
            return View(knowledgeBaseEntry);
        }

        //
        // POST: /KnowledgeBaseEntry/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(KnowledgeBaseEntry knowledgebaseentry)
        {
            if (ModelState.IsValid)
            {
                db.KnowledgeBaseEntry.Add(knowledgebaseentry);
                if (knowledgebaseentry.knowledgeBaseCategory != null)
                {
                    db.KnowledgeBaseCategory.Attach(knowledgebaseentry.knowledgeBaseCategory);
                }
                db.SaveChanges();
                return RedirectToAction("Index");
            }

           
            return View(knowledgebaseentry);
        }

        //
        // GET: /KnowledgeBaseEntry/Edit/5

        public ActionResult Edit(int id = 0)
        {
            KnowledgeBaseEntry knowledgebaseentry = db.KnowledgeBaseEntry.Find(id);
            ViewBag.KnowledgeBaseCategoryList = db.GetKnowledgeBaseCategoryList(User.Identity.Name.ToString());
            if (knowledgebaseentry == null)
            {
                return HttpNotFound();
            }
            return View(knowledgebaseentry);
        }

        //
        // POST: /KnowledgeBaseEntry/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(KnowledgeBaseEntry knowledgebaseentry)
        {
            if (ModelState.IsValid)
            {
                db.Entry(knowledgebaseentry).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.KnowledgeBaseCategoryId = new SelectList(db.KnowledgeBaseCategory, "KnowledgeBaseCategoryId", "UserName", knowledgebaseentry.KnowledgeBaseCategoryId);
            return View(knowledgebaseentry);
        }

        //
        // GET: /KnowledgeBaseEntry/Delete/5

        public ActionResult Delete(int id = 0)
        {
            KnowledgeBaseEntry knowledgebaseentry = db.KnowledgeBaseEntry.Find(id);
            if (knowledgebaseentry == null)
            {
                return HttpNotFound();
            }
            return View(knowledgebaseentry);
        }

        //
        // POST: /KnowledgeBaseEntry/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            KnowledgeBaseEntry knowledgebaseentry = db.KnowledgeBaseEntry.Find(id);
            db.KnowledgeBaseEntry.Remove(knowledgebaseentry);
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