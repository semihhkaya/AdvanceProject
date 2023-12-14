using AdvanceProject.Bll.Abstract;
using AdvanceProject.Bll.Mapper;
using AdvanceProject.Core.Entities;
using AdvanceProject.Core.Result;
using AdvanceProject.Dal.UnitofWork;
using AdvanceProject.Dto.Employee;
using AdvanceProject.Dto.Title;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvanceProject.Bll.Concrete
{
	public class TitleManager : ITitleManager
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly MyMapper _mapper;
		public TitleManager(IUnitOfWork unitOfWork, MyMapper mapper)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;

		}

		public async Task<IDataResult<List<TitleSelectDTO>>> GetAll()
		{
			var data = await _unitOfWork.TitleRepository.GetAll();
			if (data == null)
			{
				return new ErrorDataResult<List<TitleSelectDTO>>("Veri bulunamadı");
			}

			var entity = _mapper.Map<List<Title>, List<TitleSelectDTO>>(data);


			return new SuccessDataResult<List<TitleSelectDTO>>(entity, "Giriş başarılı");
		}
	}
}
