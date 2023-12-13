using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvanceProject.Dal.Base
{
	public abstract class BaseRepository
	{
        protected IDbTransaction Transaction { get; private set; }
        protected IDbConnection Connection { get; private set; }


        public BaseRepository(IDbConnection connection, IDbTransaction transaction)
        {
            Connection = connection;
            Transaction = transaction;
        }
    }
}
