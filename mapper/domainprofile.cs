using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using template.dal.entity;

namespace template.bl.models
{
   public class domainprofile : Profile
    {
       public domainprofile()
        {
            CreateMap<departmentvm, department>();
            CreateMap<department, departmentvm>();
            CreateMap<employee, employeevm>();
            CreateMap<employeevm, employee>();

            CreateMap<country, countryvm>();
            CreateMap<countryvm, country>();

            CreateMap<city, cityvm>();
            CreateMap<cityvm, city>();

            CreateMap<district, districtvm>();
            CreateMap<districtvm, district>();



        }
    }
}
