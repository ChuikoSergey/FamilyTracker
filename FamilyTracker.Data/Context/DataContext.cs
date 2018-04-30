using System.Configuration;
using System.Data.Entity;

namespace FamilyTracker.Data.Context
{
    public class DataContext : DbContext
    {
        public DataContext() : this(ConnectionString)
        {
            Database.SetInitializer(new DatabaseInitializer());
        }

        public DataContext(string connectionString) : base(connectionString)
        {

        }

        public static string ConnectionString
        {
            get
            {
                var temp = ConfigurationManager.ConnectionStrings["FamilyTrackerConnectionString"];
                return temp != null ? ConfigurationManager.ConnectionStrings["FamilyTrackerConnectionString"].ConnectionString : "FamilyTrackerConnectionString";
            }
        }
    }
}
