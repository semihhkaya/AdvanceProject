using AdvanceProject.Core.Entities;
using AdvanceProject.Dto.Advance;
using AdvanceProject.Dto.AdvanceHistory;
using AdvanceProject.Dto.BusinessUnit;
using AdvanceProject.Dto.Employee;
using AdvanceProject.Dto.Payment;
using AdvanceProject.Dto.Project;
using AdvanceProject.Dto.Receipt;
using AdvanceProject.Dto.Status;
using AdvanceProject.Dto.Title;
using AutoMapper;

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
			CreateMap<Project, ProjectSelectDTO>().ReverseMap();
			CreateMap<Payment, PaymentSelectDTO>().ReverseMap();

			CreateMap<Advance, AdvanceSelectDTO>().ReverseMap();
			CreateMap<Advance, AdvanceInsertDTO>().ReverseMap();

			CreateMap<AdvanceHistory, AdvanceHistorySelectDTO>().ReverseMap();
			CreateMap<AdvanceHistory, AdvanceHistoryInsertDTO>().ReverseMap();

			CreateMap<Status, StatusSelectDTO>().ReverseMap();
			CreateMap<Receipt, ReceiptSelectDTO>().ReverseMap();

		}
	}
}
