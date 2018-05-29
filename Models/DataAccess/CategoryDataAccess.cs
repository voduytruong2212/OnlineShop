using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.EntityFrameWork;

namespace Models.DataAccess
{
     public class CategoryDataAccess
    {
        ShopHoaDbContext db = null;
        public CategoryDataAccess()
        {
            db = new ShopHoaDbContext();
        }
        public List<Category> ListAll()
        {
            return db.Categories.Where(x => x.Status == true).ToList();
        }
        public ProductCategory ViewDetail(long id)
        {
            return db.ProductCategories.Find(id);
        }
    }
}
