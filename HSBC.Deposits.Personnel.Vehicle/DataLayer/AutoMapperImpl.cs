using AutoMapper;
using Data.domainModels;
using DataLayer.BusinessModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer
{
    public class AutoMapperImpl : Profile
    {
        public AutoMapperImpl()
        {
            CreateMap<Employee, EmployeeDTO>().ReverseMap();

            //CreateMap<List<Employee>, List<EmployeeDTO>>().ReverseMap();

        }
    }
}
