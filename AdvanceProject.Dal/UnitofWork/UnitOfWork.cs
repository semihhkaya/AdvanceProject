using AdvanceProject.Dal.Abstract;
using AdvanceProject.Dal.Concrete;
using AdvanceProject.Dal.Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvanceProject.Dal.UnitofWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private IDbConnection _connection;
        private IDbTransaction _transaction;

        private bool _dispose;

        private IAuthRepository _authRepository;
        private IEmployeeRepository _employeeRepository;
        private IBusinessUnitRepository _businessUnitRepository;
        private ITitleRepository _titleRepository;


        public UnitOfWork()
        {
            _connection = new SqlConnection(ConnectionHelper.GetConnectionString());
            _connection.Open();
        }

        public IAuthRepository AuthRepository
        {
            get { return _authRepository ?? (_authRepository = new AuthRepository(_connection, _transaction)); }
        }
        public IEmployeeRepository EmployeeRepository
        {
            get { return _employeeRepository ?? (_employeeRepository = new EmployeeRepository(_connection, _transaction)); }
        }

        public IBusinessUnitRepository BusinessUnitRepository
        {
            get { return _businessUnitRepository ?? (_businessUnitRepository = new BusinessUnitRepository(_connection, _transaction)); }
        }

        public ITitleRepository TitleRepository
        {
            get { return _titleRepository ?? (_titleRepository = new TitleRepository(_connection, _transaction)); }
        }

        public void BeginTransaction()
        {
            try
            {
                _transaction = _connection.BeginTransaction();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Commit()
        {
            try
            {
                _transaction.Commit();
            }
            catch
            {
                _transaction.Rollback();
            }
            finally
            {
                _transaction.Dispose();
                
            }
        }

        

        public void Dispose()
        {
            dispose(true);
            GC.SuppressFinalize(this);
        }

        private void dispose(bool disposing)
        {
            if (!_dispose)
            {
                if (disposing)
                {
                    if (_transaction != null)
                    {
                        _transaction.Dispose();
                        _transaction = null;
                    }
                    if (_connection != null)
                    {
                        _connection.Dispose();
                        _connection = null;
                    }
                }
                _dispose = true;
            }
        }
        ~UnitOfWork()
        {
            dispose(false);
        }
    }
}
