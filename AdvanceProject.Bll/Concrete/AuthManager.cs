using AdvanceProject.Bll.Abstract;
using AdvanceProject.Bll.Mapper;
using AdvanceProject.Core.Entities;
using AdvanceProject.Core.Result;
using AdvanceProject.Dal.UnitofWork;
using AdvanceProject.Dto.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvanceProject.Bll.Concrete
{
	public class AuthManager : IAuthManager
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IEmployeeManager _employeeManager;
		private readonly MyMapper _mapper;
		public AuthManager(IUnitOfWork unitOfWork, MyMapper mapper,IEmployeeManager employeeManager)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
			_employeeManager = employeeManager;
		}

        public async Task<IDataResult<EmployeeSelectDTO>> Login(EmployeeLoginDTO dto)
        {
            
            var user = await _unitOfWork.AuthRepository.Login(dto.Email, dto.Password);

            
            if (user == null)
            {
                return new ErrorDataResult<EmployeeSelectDTO>("E-posta veya şifre hatalı.");
            }

            var entity = _mapper.Map<Employee, EmployeeSelectDTO>(user);
            

            return new SuccessDataResult<EmployeeSelectDTO>(entity, "Giriş başarılı");
        }

        public async Task<IDataResult<EmployeeRegisterDTO>> Register(EmployeeRegisterDTO dto, string password)
        {
            
            //var existingUser = await _employeeManager.GetUserByMail(dto.Email);
            //if (existingUser.Success)
            //{
            //    //Kullanıcı zaten varsa->
            //    return new ErrorDataResult<EmployeeRegisterDTO>("Bu e-posta adresi zaten kayıtlı.");
            //}

            // Kullanıcıyı kaydet
            var entity = _mapper.Map<EmployeeRegisterDTO, Employee>(dto);
            var data = await _unitOfWork.AuthRepository.Register(entity, password);

            if (data == null)
            {
                return new ErrorDataResult<EmployeeRegisterDTO>("Bir hata oluştu");
            }

            return new SuccessDataResult<EmployeeRegisterDTO>(dto, "Kullanıcı kaydedildi");
        }


    }
}
