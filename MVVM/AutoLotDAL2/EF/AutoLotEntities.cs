namespace AutoLotDAL2.EF
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using AutoLotDAL2.Models;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Infrastructure.Interception;
    using AutoLotDAL2.Interception;
    using System.Data.Entity.Core.Objects;

    public class AutoLotEntities : DbContext
    {
        // Your context has been configured to use a 'AutoLotEntities' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'AutoLotDAL2.EF.AutoLotEntities' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'AutoLotEntities' 
        // connection string in the application configuration file.

        static readonly DatabaseLogger DatabaseLogger = new DatabaseLogger("sqllog.txt", true);
        public AutoLotEntities(): base("name=AutoLotConnection")
        {
            DbInterception.Add(new ConsoleWriterInterceptor());
            DatabaseLogger.StartLogging();
            DbInterception.Add(DatabaseLogger);

            var context = (this as IObjectContextAdapter).ObjectContext;
            context.ObjectMaterialized += Context_ObjectMaterialized;
            context.SavingChanges += Context_SavingChanges;
        }

        private void Context_SavingChanges(object sender, EventArgs e)
        {
            //Sender is of type ObjectContext.  Can get current and original values, and 
            //cancel/modify the save operation as desired.
            //var context = sender as ObjectContext;
            //if (context == null) return;
            //foreach (ObjectStateEntry item in context.ObjectStateManager.GetObjectStateEntries(EntityState.Modified | EntityState.Added))
            //{
            //    //Do something important here
            //    if ((item.Entity as Car) != null)
            //    {
            //        var entity = (Car)item.Entity;
            //        if (entity.Color == "Red")
            //        {
            //            item.RejectPropertyChanges(nameof(entity.Color));
            //        }
            //    }
            //}
        }

        private void Context_ObjectMaterialized(object sender, System.Data.Entity.Core.Objects.ObjectMaterializedEventArgs e)
        {
            var model = (e.Entity as EntityBase);
            if (model != null) model.IsChanged = false;
        }

        protected override void Dispose(bool disposing)
        {
            DbInterception.Remove(DatabaseLogger);
            DatabaseLogger.StopLogging();
            base.Dispose(disposing);
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }

        public virtual DbSet<CreditRisk> CreditRisks { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Car> Inventory { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}