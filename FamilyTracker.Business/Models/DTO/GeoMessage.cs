using FamilyTracker.Business.Enums;

namespace FamilyTracker.Business.Models.DTO
{
    public class GeoMessage
    {
        public double Longitude { get; set; }

        public double Latitude { get; set; }

        public string DeviceId { get; set; }

        public MessageType? Type { get; set; }
    }
}