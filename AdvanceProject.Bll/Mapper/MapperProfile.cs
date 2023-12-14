using AdvanceProject.Core.Entities;
using AdvanceProject.Dto.BusinessUnit;
using AdvanceProject.Dto.Employee;
using AdvanceProject.Dto.Title;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvanceProject.Bll.Mapper
{
	public class MapperProfile:Profile
	{
		public MapperProfile()
		{
			CreateMap<Employee, EmployeeRegisterDTO>().ReverseMap();
			CreateMap<Employee, EmployeeLoginDTO>().ReverseMap();
			CreateMap<Employee, EmployeeSelectDTO>().ReverseMap();

			CreateMap<Title, TitleSelectDTO>().ReverseMap();
			CreateMap<BusinessUnit, BusinessUnitSelectDTO>();

		}
	}
}
