using AdvanceProject.Dal.Abstract;
using AdvanceProject.Dal.Base;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvanceProject.Dal.Concrete
{
	public class AdvanceRepository: BaseRepository, IAdvanceRepository
	{
		public AdvanceRepository(IDbConnection connection, IDbTransaction transaction) : base(connection, transaction)
		{
		}
		//Avans repo
	}
}
