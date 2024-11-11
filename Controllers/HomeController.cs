using _23DH113573_MyStore.Models;
using _23DH113573_MyStore.Models.ViewModel;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace _23DH113573_MyStore.Controllers
{
    public class HomeController : Controller
    {
        private MyStoreEntities db = new MyStoreEntities();
        // GET: Admin/Home
        public ActionResult Index(string searchTerm, int? page)
        {
            var model = new HomeProductVM();
            var product = db.Products.AsQueryable();
            if (!string.IsNullOrEmpty(searchTerm))
            {
                model.SearchTerm = searchTerm;
                product = product.Where(p => p.ProductName.Contains(searchTerm));
                int pageNumber = page ?? 1;
                int pageSize = 5;
                model.FeaturedProducts = product.OrderByDescending(p => p.OrderDetails.Count()).Take(10).ToList();
                model.NewProducts = product.OrderBy(p => p.OrderDetails).Take(20).ToPagedList(pageNumber, pageSize);


            }
            return View(model);
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
        public ActionResult Mystorehome(string searchTerm, int? page)
        {
            var model = new HomeProductVM();
            var product = db.Products.AsQueryable();
            if (!string.IsNullOrEmpty(searchTerm))
            {
                model.SearchTerm = searchTerm;
                product = product.Where(p => p.ProductName.Contains(searchTerm) ||
                p.ProductDescription.Contains(searchTerm) ||
                p.Category.CategoryName.Contains(searchTerm));

            }
            int pageNumber = page ?? 1;
            int pageSize = 4;
            model.FeaturedProducts = product.OrderByDescending(p => p.OrderDetails.Count()).Take(10).ToList();
            model.NewProducts = product.OrderBy(p => p.OrderDetails.Count()).Take(20).ToPagedList(pageNumber, pageSize);
            return View(model);
        }
        public ActionResult ProductDetail(int? id, int? quantity, int? page)
        {
            var model = new ProductDetailsVM();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            }
            Product pro = db.Products.Find(id);
            if (pro == null)
            {
                return HttpNotFound();
            }
            var products = db.Products.Where(p => p.CategoryID == pro.CategoryID && p.ProductID != pro.ProductID).AsQueryable();
            int pageNumber = page ?? 1;
            int pageSize = model.PageSize;
            model.product = pro;
            model.RelatedProducts = products.OrderBy(p => p.ProductID).Take(4).ToPagedList(pageNumber, pageSize);
            model.TopProducts = products.OrderByDescending(p => p.OrderDetails.Count()).Take(4).ToPagedList(pageNumber, pageSize);

            if (quantity.HasValue)
            {
                model.quantity = quantity.Value;
            }
            model.estimatedValue = model.product.ProductPrice * model.quantity;
            return View(model);


        }

    }
}