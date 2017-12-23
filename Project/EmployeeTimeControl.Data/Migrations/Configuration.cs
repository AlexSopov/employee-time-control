namespace EmployeeTimeControl.Data.Migrations
{
    using AccessLayer;
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<EmployeeTimeControl.Data.AccessLayer.EmployeeTimeControlDataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(EmployeeTimeControl.Data.AccessLayer.EmployeeTimeControlDataContext context)
        {
        }
    }
}
