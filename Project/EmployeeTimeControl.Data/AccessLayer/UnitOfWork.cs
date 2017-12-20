using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeTimeControl.Data.AccessLayer
{
    public class UnitOfWork : IDisposable
    {
        EmployeeTimeControlDataContext employeeTimeControlDataContext;

        public UnitOfWork()
        {
            this.employeeTimeControlDataContext = new EmployeeTimeControlDataContext();
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
