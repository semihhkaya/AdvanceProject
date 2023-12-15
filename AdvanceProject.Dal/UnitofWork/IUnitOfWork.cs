using AdvanceProject.Dal.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvanceProject.Dal.UnitofWork
{
	public interface IUnitOfWork:IDisposable
    {
        IAuthRepository AuthRepository { get; }
        IEmployeeRepository EmployeeRepository { get; }
        IBusinessUnitRepository BusinessUnitRepository { get; }
        ITitleRepository TitleRepository { get; }
        IAdvanceRepository AdvanceRepository { get; }
        IProjectRepository ProjectRepository { get; }
        
        
        void Commit();
        void BeginTransaction();
    }
}
