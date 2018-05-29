using Models.EntityFrameWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DataAccess
{
    public class OrderDataAccess
    {
        ShopHoaDbContext db = null;
        public OrderDataAccess()
        {
            db = new ShopHoaDbContext();
        }
        public bool Insert(Order detail)
        {
            try
            {
                db.Orders.Add(detail);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
            

        }
    }
}
