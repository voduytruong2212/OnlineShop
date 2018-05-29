using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.EntityFrameWork;

namespace Models.DataAccess
{
    public class TransactionDataAccess
    {
        ShopHoaDbContext db = null;
        public TransactionDataAccess()
        {
            db = new ShopHoaDbContext();
        }
        //them moi giao dich vao db
        public int Insert(Transaction order)
        {
            db.Transactions.Add(order);
            db.SaveChanges();
            return order.TransactionID;

        }
    }
}
