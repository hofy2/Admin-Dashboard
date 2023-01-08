using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using template.bl.models;
using System.Net;
using System.Net.Mail; 
namespace template.Controllers
{
    public class mailController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult sendmail( mailvm mail)
        {

            using ( var smtp = new SmtpClient("smtp.gmail.com",587 ))
            {
                smtp.EnableSsl = true;
                smtp.Credentials = new NetworkCredential("elgendya160@gmail.com", "@@@AAA_321");
                smtp.Send("elgendya160@gmail.com", "mk7636302@gmail.com", mail.title, mail.message);
            }
            return RedirectToAction("Index");
        }

    }
}
