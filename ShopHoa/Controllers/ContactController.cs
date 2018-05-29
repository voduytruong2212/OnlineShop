using Common;
using Models.DataAccess;
using Models.EntityFrameWork;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopHoa.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        public ActionResult Index()
        {
            var model = new ContactDataAccess().GetActiveContact();
            return View(model);
        }

        [HttpPost]
        public JsonResult Send(string name, string mobile, string email, string address, string message)
        {
            var feedback = new Feedback();
            feedback.Name = name;
            feedback.Phone = mobile;
            feedback.Email = email;
            feedback.Address = address;
            feedback.Message = message;
            feedback.CreatedDate = DateTime.Now;
            //goi ham InsertFeedback de them feedback vao csdl
            var id = new ContactDataAccess().InsertFeedback(feedback);
            if(id>0)
            {
                string content = System.IO.File.ReadAllText(Server.MapPath("~/assets/client/template/newfeedback.html"));

                content = content.Replace("{{CustomerName}}", name);
                content = content.Replace("{{Phone}}", mobile);
                content = content.Replace("{{Email}}", email);
                content = content.Replace("{{Address}}", address);
                content = content.Replace("{{Message}}", message);
                var toEmail = ConfigurationManager.AppSettings["ToEmailAddress"].ToString();

                new MailHelper().SendMail(email, "Phản hồi khách hàng từ ShopHoa", content);
                new MailHelper().SendMail(toEmail, "Phản hồi khách hàng từ ShopHoa", content);
                return Json(new
                {
                    status = true
                });
                //gui mail cho nguoi quan tri
                
            }
                
                else
                    return Json(new
                    {
                        status=false
                });    
        }
    }
}