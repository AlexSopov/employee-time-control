using EmployeeTimeControl.Data.Models;
using System;

namespace EmployeeTimeControl.Data.AccessLayer
{
    public class UnitOfWork : IDisposable
    {
        EmployeeTimeControlDataContext employeeTimeControlDataContext;

        public UnitOfWork()
        {
            this.employeeTimeControlDataContext = new EmployeeTimeControlDataContext();
        }

        public DataRepository<Employee> Employees
        {
            get
            {
                return new DataRepository<Employee>(employeeTimeControlDataContext);
            }
        }

        public DataRepository<AccessAttemption> AccessAttemptions
        {
            get
            {
                return new DataRepository<AccessAttemption>(employeeTimeControlDataContext);
            }
        }

        public DataRepository<Card> Cards
        {
            get
            {
                return new DataRepository<Card>(employeeTimeControlDataContext);
            }
        }

        #region IDisposable Support

        private bool disposedValue = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }

                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }

        #endregion
    }
}
