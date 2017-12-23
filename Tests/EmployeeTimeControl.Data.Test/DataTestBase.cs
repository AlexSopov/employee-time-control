using EmployeeTimeControl.Data.AccessLayer;
using System;

namespace EmployeeTimeControl.Data.Test
{
    public class DataTestBase : IDisposable
    {
        public EmployeeTimeControlDataContext employeeTimeControlDataContext;

        public DataTestBase()
        {
            employeeTimeControlDataContext = new EmployeeTimeControlDataContext("TestConnection");
            CleanDatabase();
        }

        public void CleanDatabase()
        {
            employeeTimeControlDataContext.AccessAttemptionSet.RemoveRange(employeeTimeControlDataContext.AccessAttemptionSet);
            employeeTimeControlDataContext.CardSet.RemoveRange(employeeTimeControlDataContext.CardSet);
            employeeTimeControlDataContext.CardAccessSet.RemoveRange(employeeTimeControlDataContext.CardAccessSet);
            employeeTimeControlDataContext.DayVisitingRuleSet.RemoveRange(employeeTimeControlDataContext.DayVisitingRuleSet);
            employeeTimeControlDataContext.EmployeeSet.RemoveRange(employeeTimeControlDataContext.EmployeeSet);
            employeeTimeControlDataContext.PassagePointSet.RemoveRange(employeeTimeControlDataContext.PassagePointSet);
            employeeTimeControlDataContext.VisitingRuleSet.RemoveRange(employeeTimeControlDataContext.VisitingRuleSet);
            employeeTimeControlDataContext.DayOffSet.RemoveRange(employeeTimeControlDataContext.DayOffSet);
        }

        #region IDisposable Support
        private bool disposedValue = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    employeeTimeControlDataContext.Dispose();
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
