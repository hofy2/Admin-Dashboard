using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using template.bl.Interface;
using template.bl.models;
using template.bl.reposatry;
using template.dal.database;
using template.dal.entity;

namespace template.Controllers
{
    public class DepartmentController1 : Controller
    {

        #region prop
        // tightly coupled
        //private readonly departmentrep departmentt;

        //losely coupled
        private readonly Idepartmentrep departmentt ;
        private readonly IMapper mapper;
        #endregion

        #region constractor
        public DepartmentController1(Idepartmentrep departmentt , IMapper mapper)
        {
          this.departmentt = departmentt;
            this.mapper = mapper;
        }

        #endregion


        #region actions

        [HttpGet]
        public IActionResult Index( string dname="")
        {

            #region test

            //ViewData["x"] = "hi im view data";
            //ViewBag.x = "hi to viewbag";
            //TempData["x"] = "hi temp";
            //return RedirectToAction("test", "DepartmentController1");

            //string[] names = { "ahmed", "ali", "hanan" };

            //ViewBag.names = names;
            //employe emp1 = new employe() { id = 5, name = "ahmed", salary = 5000 };
            //employe emp2 = new employe() { id = 6, name = "mona", salary = 2000 };
            //employe emp3 = new employe() { id = 7, name = "nada", salary = 3000 };
            //List<employe> empli = new List<employe>();

            //empli.Add(emp1);
            //empli.Add(emp2);
            //empli.Add(emp3);

            //ViewBag.data = empli;
            #endregion
            if( dname== ""|| dname== null)
            {
                var data = mapper.Map<IEnumerable<departmentvm>>(departmentt.get());
                return View(data);
            }
            else
            {
                var data = mapper.Map<IEnumerable<departmentvm>>(departmentt.searchbyname(dname));
                return View(data);
            }
       
        }


        public IActionResult create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult create(departmentvm model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var data = mapper.Map<department>(model);
                    departmentt.creat(data);
                    return RedirectToAction("Index");

                }
                return View();

            }
            catch (Exception ex)
            {
                return View();
            }
        }

        public IActionResult edit(int id)
        {
            var model = departmentt.getbyid(id);
            var data = mapper.Map<departmentvm>(model);
            return View(data);
        }

        [HttpPost]
        public IActionResult edit(departmentvm model)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    var obj = mapper.Map<department>(model);

                    departmentt.update(obj);
                    return RedirectToAction("Index");
                }
                return View();

            }
            catch (Exception ex)
            {
                return View();
            }
        }


        public IActionResult delete(int id)
        {
            var model = departmentt.getbyid(id);
            var data = mapper.Map<departmentvm>(model);
            return View(data);
        }

        [HttpPost]
        [ActionName("delete")]
        public IActionResult confirmdelete(int id)
        {
            try
            {

                var model = departmentt.getbyid(id);

                departmentt.delete(model);
                return RedirectToAction("Index");



            }
            catch (Exception ex)
            {
                return View();
            }
        }

        public IActionResult details(int id)
        {
            var model = departmentt.getbyid(id);
            var data = mapper.Map<departmentvm>(model);
            return View(data);
        }
        public IActionResult test()
        {
            return View();
        }

        #endregion
    }
}
