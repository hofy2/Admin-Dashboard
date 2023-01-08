using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using template.bl.helper;
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
        private readonly Icountryrep countryy;
        private readonly Icityrep cityy;
        private readonly Idistrictrep districtt;
        private readonly IMapper mapper;
        #endregion

        #region constractor
        public employeeController(Iemployeerep employeee, Icountryrep countryy, Icityrep cityy, Idistrictrep districtt, Idepartmentrep departmentt, IMapper mapper)
        {
            this.departmentt = departmentt;
            this.employeee = employeee;
            this.countryy = countryy;
            this.cityy = cityy;
            this.districtt = districtt;
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
            ViewBag.departmentlist = new SelectList(dapartmentmodel, "id","departmentname");

            var countrymodel = mapper.Map<IEnumerable<countryvm>>(countryy.get());
            ViewBag.countrylist = new SelectList(countrymodel, "id", "countryname");


            return View();
        }



        [HttpPost]
        public IActionResult create(employeevm model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                  


                  


                    model.cvurl = uploadfilehelper.uploadfile("files/cvs" , model.cv );
                    model.imgurl = uploadfilehelper.uploadfile("files/imgs", model.img );


                    var data = mapper.Map<employee>(model);
                    employeee.creat(data);
                    return RedirectToAction("Index");

                }

                var countrymodel = mapper.Map<IEnumerable<countryvm>>(countryy.get());
                ViewBag.countrylist = new SelectList(countrymodel, "id", "countryname");
                return View();

            }
            catch (Exception ex)
            {
                var countrymodel = mapper.Map<IEnumerable<countryvm>>(countryy.get());
                ViewBag.countrylist = new SelectList(countrymodel, "id", "countryname");
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
                 uploadfilehelper.fileremover("files/cvs", model.cvurl);
                uploadfilehelper.fileremover("files/imgs", model.imgurl);

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

        #region ajax 

        [HttpPost]
        public JsonResult getcitybycountryid(int cntryid)
        {

            var model = cityy.get(a => a.countryid == cntryid);
            var data = mapper.Map<IEnumerable<cityvm>>(model) ;

            return Json(data);
        }
        [HttpPost]

        public JsonResult getdistrictbycityid(int ctyid)
        {

            var model = districtt.get(a => a.cityid == ctyid);
            var data = mapper.Map<IEnumerable<districtvm>>(model);

            return Json(data);
        }

        #endregion
    }
}
