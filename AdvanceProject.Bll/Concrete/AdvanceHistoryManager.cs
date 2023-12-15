using AdvanceProject.Bll.Abstract;
using AdvanceProject.Bll.Mapper;
using AdvanceProject.Dal.UnitofWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvanceProject.Bll.Concrete
{
	public class AdvanceHistoryManager:IAdvanceHistoryManager
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly MyMapper _mapper;
		public AdvanceHistoryManager(IUnitOfWork unitOfWork, MyMapper mapper)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
		}
	}
}
