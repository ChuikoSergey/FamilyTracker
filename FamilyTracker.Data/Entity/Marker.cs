using System;
using FamilyTracker.Data.Entity.Base;

namespace FamilyTracker.Data.Entity
{
    public class Marker : IEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public string Name { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}
