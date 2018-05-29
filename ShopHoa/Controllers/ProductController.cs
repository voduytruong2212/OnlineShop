using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models.DataAccess;

namespace ShopHoa.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            
            return View();
        }
        [ChildActionOnly]
        //paritialView hien thi danh muc cac san pham 
        public PartialViewResult _ProductCategory()
        {
            var model = new ProductCategoryDataAccess().ListAll();
            return PartialView(model);
        }
        [ChildActionOnly]
        public PartialViewResult _ProductCategory1()
        {
            var model = new ProductCategoryDataAccess().ListAll1();
            return PartialView(model);
        }
        [ChildActionOnly]
        public PartialViewResult _PromotionProduct()
        {
            var product = new ProductDataAccess();
            ViewBag.ListPromotionProducts = product.ListPromotionProduct(4);
            var model = new ProductDataAccess().ListPromotionProduct(4);
            return PartialView(model);
        }

        public ActionResult Category(int cateId)
        {
            var productcategory = new CategoryDataAccess().ViewDetail(cateId);
            ViewBag.Category = productcategory;
            var model = new ProductDataAccess().ListByCategoryId(cateId);
            return View(model);
        }
        //hien thi cac san pham duoc search
        public JsonResult ListName(string q)
        {
            var data = new ProductDataAccess().ListName(q);
            return Json(new
            {
                data = data,
                status = true

            },JsonRequestBehavior.AllowGet);
        }
        //tim kiem san pham
        public ActionResult Search(string keyword)
        {
            var model = new ProductDataAccess().Search(keyword);
            ViewBag.Keyword = keyword;
            return View(model);
        }
        //Ham hien thi chi tiet sp va sp lien quan
        [OutputCache(Duration = int.MaxValue,VaryByParam = "productid")]
        public ActionResult Detail(int productid)
        {
            var product= new  ProductDataAccess().ViewDetail(productid);
            ViewBag.Category = new ProductCategoryDataAccess().ViewDetail(product.CategoryID.Value);
            ViewBag.RelatedProducts = new ProductDataAccess().ListRelatedProduct(productid);
            return View(product);
        }
        
    }
}