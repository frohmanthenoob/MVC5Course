using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVC5Course.Models;
using PagedList;
using System.Web.UI;

namespace MVC5Course.ActionFilter
{
    [Authorize]
    [OutputCache(Duration =60,Location = OutputCacheLocation.ServerAndClient)]
    
    public class ProductsController : BaseController
    {
        [紀錄Action執行時間]
        public ActionResult Index(string sort,string searchText, int pageNo = 1)
        {
            IQueryable<Product> all = NewMethod(sort, searchText);
            return View(all.ToPagedList(pageNo, 75));
        }
        [HttpPost]
        [紀錄Action執行時間]
        public ActionResult Index(Product[] data, string sort, string searchText, int pageNo = 1)
        {
            if (ModelState.IsValid)
            {
                foreach (var item in data)
                {
                    var prod = repo.Find(item.ProductId);
                    prod.ProductName = item.ProductName;
                    prod.Price = item.Price;
                    prod.Stock = item.Stock;
                    prod.Active = item.Active;
                    repo.UnitOfWork.Commit();
                }
                return RedirectToAction("Index");
            }
            IQueryable<Product> all = NewMethod(sort, searchText);
            return View(all.ToPagedList(pageNo, 75));
        }
        private IQueryable<Product> NewMethod(string sort, string searchText)
        {
            var all = repo.All().AsQueryable();
            if (!String.IsNullOrEmpty(searchText))
            {
                all = all.Where(x => x.ProductName.Contains(searchText));
            }
            all = sort == "+" ?
            all.OrderBy(x => x.Price) :
            all.OrderByDescending(x => x.Price);
            ViewBag.searchKey = searchText;

            ViewBag.sort = sort;
            return all;
        }

        // GET: Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = repo.Find(id.Value);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductId,ProductName,Price,Active,Stock")] Product product)
        {
            if (ModelState.IsValid)
            {
                repo.Add(product);
                repo.UnitOfWork.Commit();
                return RedirectToAction("Index");
            }

            return View(product);
        }

        // GET: Products/Edit/5
        [紀錄Action執行時間]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = repo.Find(id.Value);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id,FormCollection form)
        {
            var product = repo.Find(id);
            if (TryUpdateModel(product,includeProperties: new[] { "ProductName", "Price" }))
            {
                repo.UnitOfWork.Commit();
                return RedirectToAction("Index");
            }
            return View(product);
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = repo.Find(id.Value);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = repo.Find(id);
            repo.Delete(product);
            repo.UnitOfWork.Commit();
            return RedirectToAction("Index");
        }

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
