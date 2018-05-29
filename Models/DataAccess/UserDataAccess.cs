using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Models.EntityFrameWork;
using PagedList;
using Common;


namespace Models.DataAccess
{
    public class UserDataAccess
    {
        ShopHoaDbContext db = null;

        public UserDataAccess()
        {
            db = new ShopHoaDbContext();
        }
        //them moi nguoi dung(admin)
        public long Insert(User entity)
        {
            db.Users.Add(entity);
            db.SaveChanges();
            return entity.UserID;
        }
        //sua thong tin nguoi dung (admin)
        public bool Update(User entity)
        {
            try
            {
                var user = db.Users.Find(entity.UserID);
                user.Name = entity.Name;
                if (!string.IsNullOrEmpty(entity.Password))
                {
                    user.Password = entity.Password;
                }
                user.Address = entity.Address;
                user.Email = entity.Email;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        //chuc nang dang nhap cua nguoi dung
        public int Login(string userName, string passWord)
        {
            var result = db.Users.SingleOrDefault(x => x.UserName == userName);
            if (result == null)
            {
                return 0;
            }
            else
            {
                if (result.Status == false)
                {
                    return -1;
                }
                else
                {
                    if (result.Password == passWord)
                        return 1;
                    else
                        return -2;
                }
            }
        }
        //chuc nang dang nhap cua admin
        public int LoginAdmin(string userName, string passWord)
        {
            var result = db.Users.SingleOrDefault(x => x.UserName == userName);
            if (result == null)
            {
                return 0;
            }
            else
            {
                if (result.UserTypeID == CommonConstants.ADMIN_TYPE || result.UserTypeID == CommonConstants.MOD_TYPE)
                {
                    if (result.Status == false)
                    {
                        return -1;
                    }
                    else
                    {
                        if (result.Password == passWord)
                            return 1;
                        else
                            return -2;
                    }
                }
                else
                {
                    return -3;
                }

            }
        }
        public User GetById(string userName)
        {
            return db.Users.SingleOrDefault(x => x.UserName == userName);
        }
        //xoa tai khoan (admin)
        public bool Delete(int id)
        {
            try
            {
                var user = db.Users.Find(id);
                db.Users.Remove(user);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
        //hien thi thong tin tk nguoi dung(admin)
        public User ViewDetail(int id)
        {
            return db.Users.Find(id);
        }
        public IEnumerable<User> ListAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<User> model = db.Users;

            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.UserName.Contains(searchString) || x.Name.Contains(searchString))
                    ;
            }
            return model.OrderByDescending(x => x.CreatedDate).ToPagedList(page, pageSize);

        }
        //kt username
        public bool CheckUserName(string userName)
        {
            return db.Users.Count(x => x.UserName == userName)>0;          
        }
        //kt email
        public bool CheckEmail(string email)
        {
            return db.Users.Count(x => x.Email == email) > 0;
        }
        //thay doi trang thai tai khoan
        public bool ChangeStatus(int id)
        {
            var user = db.Users.Find(id);
            user.Status = !user.Status;
            db.SaveChanges();
            return user.Status;
        }
    }
}