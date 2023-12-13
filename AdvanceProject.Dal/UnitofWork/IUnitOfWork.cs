using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvanceProject.Dal.UnitofWork
{
	interface IUnitOfWork:IDisposable
    {
        //Repolar buraya gelicek abstract concrete şeklinde
        
        
        void Commit();
        void BeginTransaction();
    }
}
