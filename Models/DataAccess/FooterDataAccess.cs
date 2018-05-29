using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.EntityFrameWork;

namespace Models.DataAccess
{
    public class FooterDataAccess
    {
        private ShopHoaDbContext db = null;

        public FooterDataAccess()
        {
            db=new ShopHoaDbContext();
        }

        public Footer GetFooter()
        {
            return db.Footers.SingleOrDefault(x => x.Status == true);
        }
    }
}
