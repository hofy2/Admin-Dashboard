using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using template.bl.Interface;
using template.bl.models;
using template.dal.entity;

namespace template.Controllers
{
    public class employeeController : Controller
    {
        #region prop
        // tightly coupled
        //private readonly departmentrep departmentt;

        //losely coupled
        private readonly Idepartmentrep departmentt;
        private readonly Iemployeerep employeee;
        private readonly IMapper mapper;
        #endregion

        #region constractor
        public employeeController(Iemployeerep employeee, Idepartmentrep departmentt, IMapper mapper)
        {
            this.departmentt = departmentt;
            this.employeee = employeee;
            this.mapper = mapper;
        }

        #endregion


        #region actions

        [HttpGet]
        public IActionResult Index(string ename = "")
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

            if (ename == "" || ename == null)
            {
                var data = mapper.Map<IEnumerable<employeevm>>(employeee.get());
                return View(data);
            }
            else
            {
                var data = mapper.Map<IEnumerable<employeevm>>(employeee.searchbyname(ename));
                return View(data);
            }

        }


        public IActionResult create()
        {
            var dapartmentmodel = mapper.Map<IEnumerable<departmentvm>>(departmentt.get());

            ViewBag.departmentlist = new SelectList(departmentt.get(),"id","departmentname");
            return View();
        }



        [HttpPost]
        public IActionResult create(employeevm model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var data = mapper.Map<employee>(model);
                    employeee.creat(data);
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
            var model = employeee.getbyid(id);
            var data = mapper.Map<employeevm>(model);
            var dapartmentmodel = mapper.Map<IEnumerable<departmentvm>>(departmentt.get());
            ViewBag.departmentlist = new SelectList(dapartmentmodel, "id", "departmentname", data.departmentid);

            return View(data);
        }




        [HttpPost]
        public IActionResult edit(employeevm model)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    var obj = mapper.Map<employee>(model);

                    employeee.update(obj);
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
            var model = employeee.getbyid(id);
            var data = mapper.Map<employeevm>(model);
            var dapartmentmodel = mapper.Map<IEnumerable<departmentvm>>(departmentt.get());
            ViewBag.departmentlist = new SelectList(dapartmentmodel, "id", "departmentname", data.departmentid);

            return View(data);
        }




        [HttpPost]
        [ActionName("delete")]
        public IActionResult confirmdelete(int id)
        {
            try
            {

                var model = employeee.getbyid(id);

                employeee.delete(model);
                return RedirectToAction("Index");



            }
            catch (Exception ex)
            {
                return View();
            }
        }




        public IActionResult details(int id)
        {
            var model = employeee.getbyid(id);

            var data = mapper.Map<employeevm>(model);
            var dapartmentmodel = mapper.Map<IEnumerable<departmentvm>>(departmentt.get());
            ViewBag.departmentlist = new SelectList(dapartmentmodel, "id", "departmentname", data.departmentid);

            return View(data);
        }



        public IActionResult test()
        {
            return View();
        }

        #endregion
    }
}
