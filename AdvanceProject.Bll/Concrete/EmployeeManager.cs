using AdvanceProject.Bll.Abstract;
using AdvanceProject.Bll.Mapper;
using AdvanceProject.Core.Entities;
using AdvanceProject.Core.Result;
using AdvanceProject.Dal.UnitofWork;
using AdvanceProject.Dto.Employee;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdvanceProject.Bll.Concrete
{
	public class EmployeeManager : IEmployeeManager
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly MyMapper _mapper;
		public EmployeeManager(IUnitOfWork unitOfWork, MyMapper mapper)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
			
		}
		public async Task<IDataResult<EmployeeRegisterDTO>> GetUserByMail(string email)
		{
			var user = await _unitOfWork.EmployeeRepository.GetUserByEmail(email);

			
			if (user != null)
			{
				var userDto = _mapper.Map<Employee, EmployeeRegisterDTO>(user);
				return new SuccessDataResult<EmployeeRegisterDTO>(userDto,"Kullanıcı mevcut");
			}

			// Kullanıcı bulunamadı
			return new ErrorDataResult<EmployeeRegisterDTO>("Kullanıcı bulunamadı.");
		}

		public async Task<IDataResult<List<EmployeeSelectDTO>>> GetAll()
		{
			var data = await _unitOfWork.EmployeeRepository.GetAll();
			if (data == null)
			{
				return new ErrorDataResult<List<EmployeeSelectDTO>>("Veri bulunamadı");
			}

			var entity = _mapper.Map<List<Employee>, List<EmployeeSelectDTO>>(data);


			return new SuccessDataResult<List<EmployeeSelectDTO>>(entity, "Giriş başarılı");
		}
	}
}
