using System.Configuration;
using System.Data.Entity;
using FamilyTracker.Data.Entity;

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

        public static string ConnectionString => ConfigurationManager.ConnectionStrings["FamilyTrackerConnectionString"] != null 
                                                 ? ConfigurationManager.ConnectionStrings["FamilyTrackerConnectionString"].ConnectionString 
                                                 : "FamilyTrackerConnectionString";

        public DbSet<Event> Events { get; set; }
        public DbSet<Marker> Markers { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Zone> Zones { get; set; }
    }
}
