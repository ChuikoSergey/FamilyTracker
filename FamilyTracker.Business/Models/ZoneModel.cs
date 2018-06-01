using FamilyTracker.Business.Models.Base;

namespace FamilyTracker.Business.Models
{
    public class ZoneModel : IModel
    {
        public int Id { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public double Radius { get; set; }
        public UserModel User { get; set; }
        public string Name { get; set; }
    }
}