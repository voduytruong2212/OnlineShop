using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models.DataAccess;
using ShopHoa.Models;
using ShopHoa.Common;

namespace ShopHoa.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            var product = new ProductDataAccess();
            ViewBag.NewProducts = product.ListNewProduct(6);//san pham moi (co the thay doi so sp muon hien thi)
            ViewBag.ListFeatureProducts = product.ListFeatureProduct(2);//san pham dac trung
            return View();
        }
        [ChildActionOnly]
        [OutputCache(Duration =3600*24)]
        //Goi ham ListByGroupId de lay du lieu trong bang menu tu MenuDataAccess (menutpyeID =1)
        public ActionResult _MainMenu()
        {
            var model = new MenuDataAccess().ListByGroupId(1);
            return PartialView(model);
        }
        [ChildActionOnly]
        //Goi ham ListByGroupId de lay du lieu trong bang menu tu MenuDataAccess (menutpyeID =2)
        public ActionResult _TopMenu()
        {
            var model = new MenuDataAccess().ListByGroupId(2);
            return PartialView(model);
        }
        [ChildActionOnly]
        //gio hang o trang chu
        public PartialViewResult _HeaderCart()
        {
            var cart = Session[CommonConstant.CartSession];
            var list = new List<CartItem>();
            if (cart != null)
            {
                list = (List<CartItem>)cart;
            }
           
            return PartialView(list);
        }
        [ChildActionOnly]
        [OutputCache(Duration = 3600 * 24)]
        //hien footer ra ngoai view
        public ActionResult _Footer()
        {
            var model = new FooterDataAccess().GetFooter();
            return PartialView(model);
        }

    }
}