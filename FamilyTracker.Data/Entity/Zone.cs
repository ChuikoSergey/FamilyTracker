using System.ComponentModel.DataAnnotations;
using FamilyTracker.Data.Entity.Base;

namespace FamilyTracker.Data.Entity
{
    public class Zone: IEntity
    {
        [Key]
        public int Id { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public double Radius { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public string Name { get; set; }
    }
}