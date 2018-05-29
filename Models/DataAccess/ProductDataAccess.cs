using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.EntityFrameWork;
using PagedList;

namespace Models.DataAccess
{
    public class ProductDataAccess
    {
         ShopHoaDbContext db = null;

        public ProductDataAccess()
        {
            db = new ShopHoaDbContext();
        }
       //Lay danh sach san pham moi dua vao ngay tao
        public List<Product> ListNewProduct(int top)
        {
            return db.Products.OrderByDescending(x => x.CreatedDate).Take(top).ToList();
        }
        //Ten cac sp duoc tim kiem trong thanh search
        public List<string> ListName(string keyword)
        {
            return db.Products.Where(x => x.Name.Contains(keyword)).Select(x => x.Name).ToList();
        }
        //Lay danh sach san pham dac trung dua vao Code trong db
        public List<Product> ListFeatureProduct(int top)
        {
            return db.Products.Where(x => x.Code== 1).OrderByDescending(x=>x.CreatedDate).Take(top).ToList();
        }
        //Lay danh sach san pham co gia khuyen mai
        public List<Product> ListPromotionProduct(int top)
        {
            return db.Products.Where(x=>x.PromotionPrice!= null).OrderByDescending(x => x.CreatedDate).Take(top).ToList();
        }
        //Chi tiet san pham
        public Product ViewDetail(int id)
        {
            return db.Products.Find(id);
        }
        //Lay danh sach san pham lien quan voi san pham dang xem dua vao category id
        public List<Product> ListRelatedProduct(int productId)
        {
            var product = db.Products.Find(productId);
            return db.Products.Where(x => x.ProductID != productId && x.CategoryID ==product.CategoryID).Take(3).ToList();
        }
        //Lay cac san pham co cung CategoryID
        public List<Product> ListByCategoryId(int categoryId)
        {
           
            return db.Products.Where(x=>x.CategoryID==categoryId).ToList();
        }
        public List<Product> Search(string keyword)
        {

            return db.Products.Where(x => x.Name.Contains(keyword)).ToList();
        }
        //them moi san pham vao db (admin)
        public int Insert(Product entity)
        {
            entity.CreatedDate = DateTime.Now;
            db.Products.Add(entity);
            db.SaveChanges();
            return entity.ProductID;
        }
        public IEnumerable<Product> ListAllPaging(string searchString,int page,int pageSize)
        {
            IQueryable<Product> model = db.Products;
            if(!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.Name.Contains(searchString));
            }
            return model.OrderByDescending(x => x.CreatedDate).ToPagedList(page, pageSize);
        }
        //cap nhat san pham (admin)
        public bool Update(Product entity)
        {
            try
            {
                var product = db.Products.Find(entity.ProductID);
                product.Code = entity.Code;
                product.Description = entity.Description;
                product.Detail = entity.Detail;
                product.Price = entity.Price;
                product.PromotionPrice = entity.PromotionPrice;
                product.Quantity = entity.Quantity;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public Product GetById(string Name)
        {
            return db.Products.SingleOrDefault(x => x.Name == Name);
        }
        //xoa sp(admin)
        public bool Delete(int id)
        {
            try
            {
                var product = db.Products.Find(id);
                db.Products.Remove(product);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
    }

}
