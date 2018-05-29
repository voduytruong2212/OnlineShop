using Models.EntityFrameWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DataAccess
{
    public class ContactDataAccess
    {
        ShopHoaDbContext db = null;
        public ContactDataAccess()
        {
            db = new ShopHoaDbContext();
        }
        public Contact GetActiveContact()
        {
            return db.Contacts.Single(x => x.Status == true);
        }
        
        public int InsertFeedback(Feedback fb)
        {
            db.Feedbacks.Add(fb);
            db.SaveChanges();
            return fb.FeedbackID;
        }
    }
}
