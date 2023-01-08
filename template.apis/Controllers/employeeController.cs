using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using template.bl.helper;
using template.bl.Interface;
using template.bl.models;
using template.dal.entity;

namespace template.apis.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class employeeController : ControllerBase
    {
        #region field
        private readonly Iemployeerep employee;
        private readonly IMapper mapper;

        #endregion


        #region con

       public employeeController(Iemployeerep employee , IMapper mapper)
        {
            this.employee = employee;
            this.mapper = mapper;
        }


        #endregion


        #region apis

        [HttpGet]
        [Route("~/api/Getemployee")]

        public IActionResult Getemployee()
        {
            try
            {
                var data = employee.get();

                var model = mapper.Map<IEnumerable<employeevm>>(data);
                return Ok(new apiresponse<IEnumerable<employeevm>>
                {

                    code = "200",
                    status = "ok",
                    message = "data retreved",
                    data = model


                });
            } catch(Exception ex)
            {
                return NotFound(new apiresponse<string>
                {

                    code = "404",
                    status = "not found",
                    message = "data not found",
                   error = ex.Message


                });
            }
        }



        [HttpGet]
        [Route("~/api/Getemployeebyid/{id}")]
        public IActionResult Getemployeebyid( int id)
        {
            try
            {
                var data = employee.getbyid(id);

                var model = mapper.Map<employeevm>(data);
                return Ok(new apiresponse<employeevm>
                {

                    code = "200",
                    status = "ok",
                    message = "data retreved",
                    data = model


                });
            }
            catch (Exception ex)
            {
                return NotFound(new apiresponse<string>
                {

                    code = "404",
                    status = "not found",
                    message = "data not found",
                    error = ex.Message


                });
            }
        }



        [HttpPost]
        [Route("~/api/postemployee")]

        public IActionResult postemployee(employeevm model)
        {
            try
            {
                if ( ModelState.IsValid)
                {

                    var data = mapper.Map<employee>(model);
                    var result = employee.creat(data);

                    return Ok(new apiresponse<employee>
                    {

                        code = "201",
                        status = "saved",
                        message = "data seved",
                        data = result


                    });
                }


                return BadRequest(new apiresponse<string>
                {

                    code = "402",
                    status = "bad request",
                    message = "no data saved",
                    error = "bad request"


                });

            }
            catch (Exception ex)
            {
                return NotFound(new apiresponse<string>
                {

                    code = "402",
                    status = "bad request",
                    message = "no data saved",
                    error = ex.Message


                });
            }
        }


        [HttpPut]
        [Route("~/api/putemployee")]

        public IActionResult putemployee(employeevm model)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    var data = mapper.Map<employee>(model);
                   employee.update(data);

                    return Ok(new apiresponse<employeevm>
                    {

                        code = "201",
                        status = "updated",
                        message = "data updated",
                        data = model


                    });
                }


                return BadRequest(new apiresponse<string>
                {

                    code = "402",
                    status = "bad request",
                    message = "no data saved",
                    error = "bad request"


                });

            }
            catch (Exception ex)
            {
                return NotFound(new apiresponse<string>
                {

                    code = "402",
                    status = "bad request",
                    message = "no data saved",
                    error = ex.Message


                });
            }
        }

        [HttpDelete]
        [Route("~/api/deleteemployee")]

        public IActionResult deleteemployee(employeevm model)
        {
            try
            {
               

                    var data = mapper.Map<employee>(model);
                    employee.delete(data);

                    return Ok(new apiresponse<employeevm>
                    {

                        code = "201",
                        status = "deleted",
                        message = "data deleted",
                        data = model


                    });
                


            }
            catch (Exception ex)
            {
                return NotFound(new apiresponse<string>
                {

                    code = "402",
                    status = "bad request",
                    message = "no data saved",
                    error = ex.Message


                });
            }
        }
        #endregion

    }
}
