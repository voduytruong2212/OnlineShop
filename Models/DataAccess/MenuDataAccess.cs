using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.EntityFrameWork;

namespace Models.DataAccess
{
    public class MenuDataAccess
    {
        ShopHoaDbContext db = null;

        public MenuDataAccess()
        {
            db = new ShopHoaDbContext();
        }

        public List<Menu> ListByGroupId(int groupId)
        {
            return db.Menus.Where(x => x.MenuTypeID == groupId && x.Status==true).OrderBy(x=>x.DisplayOrder).ToList();
        }
    }
}
