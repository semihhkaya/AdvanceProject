using AdvanceProject.Bll.Abstract;
using AdvanceProject.Bll.Mapper;
using AdvanceProject.Core.Entities;
using AdvanceProject.Core.Result;
using AdvanceProject.Dal.UnitofWork;
using AdvanceProject.Dto.BusinessUnit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvanceProject.Bll.Concrete
{
	public class BusinessUnitManager : IBusinessUnitManager
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly MyMapper _mapper;
		public BusinessUnitManager(IUnitOfWork unitOfWork, MyMapper mapper)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;

		}
		public async Task<IDataResult<List<BusinessUnitSelectDTO>>> GetAll()
		{
			var data = await _unitOfWork.BusinessUnitRepository.GetAll();
			if (data == null)
			{
				return new ErrorDataResult<List<BusinessUnitSelectDTO>>("Veri bulunamadı");
			}

			var entity = _mapper.Map<List<BusinessUnit>, List<BusinessUnitSelectDTO>>(data);


			return new SuccessDataResult<List<BusinessUnitSelectDTO>>(entity, "Giriş başarılı");
		}
	}
}
