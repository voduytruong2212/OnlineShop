using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.EntityFrameWork;

namespace Models.DataAccess
{
    public class ProductCategoryDataAccess
    {
         ShopHoaDbContext db = null;

        public ProductCategoryDataAccess()
        {
            db=new ShopHoaDbContext();
        }

        public List<ProductCategory> ListAll()
        {
            return db.ProductCategories.Where(x => x.Status == true&& x.ParentID==1).OrderBy(x => x.ProductCategoryName).ToList();
        }
        public List<ProductCategory> ListAll1()
        {
            return db.ProductCategories.Where(x => x.Status == true && x.ParentID==2).OrderBy(x => x.ProductCategoryID).ToList();
        }

        public ProductCategory ViewDetail(int id)
        {
            return db.ProductCategories.Find(id);
        }
        
    }
}
