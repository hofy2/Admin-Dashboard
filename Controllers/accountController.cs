using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace template.Controllers
{
    public class accountController : Controller
    {



        #region registration 
        [HttpGet]
        public IActionResult registration()
        {
            return View();
        }


        #endregion

        #region login 
        [HttpGet]
        public IActionResult login()
        {
            return View();
        }


        #endregion


        #region logout 

        #endregion


        #region forget bassword 

        [HttpGet]
        public IActionResult forgetpassword()
        {
            return View();
        }


        [HttpGet]
        public IActionResult confirmforgetpassword()
        {
            return View();
        }

        #endregion


        #region reset bassword 

        #endregion


    }
}
