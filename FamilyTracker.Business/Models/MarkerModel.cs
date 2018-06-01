using System;
using FamilyTracker.Business.Models.Base;

namespace FamilyTracker.Business.Models
{
    public class MarkerModel : IModel
    {
        public int Id { get; set; }
        public UserModel User { get; set; }
        public string Name { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}