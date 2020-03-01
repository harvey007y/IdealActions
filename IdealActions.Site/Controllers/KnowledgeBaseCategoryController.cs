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
    public class KnowledgeBaseCategoryController : Controller
    {
        private Context db = new Context("ClubSiteDB");

        //
        // GET: /KnowledgeBaseCategory/

        public ActionResult Index()
        {
            return View(db.KnowledgeBaseCategory.ToList().Where(x => x.UserName == User.Identity.Name.ToString()));
        }

        //
        // GET: /KnowledgeBaseCategory/Details/5

        public ActionResult Details(int id = 0)
        {
            KnowledgeBaseCategory knowledgebasecategory = db.KnowledgeBaseCategory.Find(id);
            if (knowledgebasecategory == null)
            {
                return HttpNotFound();
            }
            return View(knowledgebasecategory);
        }

        //
        // GET: /KnowledgeBaseCategory/Create

        public ActionResult Create()
        {
            KnowledgeBaseCategory knowledgebasecategory = new KnowledgeBaseCategory() { UserName = User.Identity.Name };
            return View(knowledgebasecategory);
        }

        //
        // POST: /KnowledgeBaseCategory/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(KnowledgeBaseCategory knowledgebasecategory)
        {
            if (ModelState.IsValid)
            {
                db.KnowledgeBaseCategory.Add(knowledgebasecategory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(knowledgebasecategory);
        }

        //
        // GET: /KnowledgeBaseCategory/Edit/5

        public ActionResult Edit(int id = 0)
        {
            KnowledgeBaseCategory knowledgebasecategory = db.KnowledgeBaseCategory.Find(id);
            if (knowledgebasecategory == null)
            {
                return HttpNotFound();
            }
            return View(knowledgebasecategory);
        }

        //
        // POST: /KnowledgeBaseCategory/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(KnowledgeBaseCategory knowledgebasecategory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(knowledgebasecategory).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(knowledgebasecategory);
        }

        //
        // GET: /KnowledgeBaseCategory/Delete/5

        public ActionResult Delete(int id = 0)
        {
            KnowledgeBaseCategory knowledgebasecategory = db.KnowledgeBaseCategory.Find(id);
            if (knowledgebasecategory == null)
            {
                return HttpNotFound();
            }
            return View(knowledgebasecategory);
        }

        //
        // POST: /KnowledgeBaseCategory/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            KnowledgeBaseCategory knowledgebasecategory = db.KnowledgeBaseCategory.Find(id);
            db.KnowledgeBaseCategory.Remove(knowledgebasecategory);
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