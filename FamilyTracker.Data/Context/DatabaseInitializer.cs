using System.Data.Entity;

namespace FamilyTracker.Data.Context
{
    public class DatabaseInitializer : CreateDatabaseIfNotExists<DataContext>
    {
        protected override void Seed(DataContext context)
        {
            base.Seed(context);
        }
    }
}
