using System;
using System.Collections.Generic;
using FamilyTracker.Business.Models.Base;
using FamilyTracker.Data.Entity;

namespace FamilyTracker.Business.Models
{
    public class UserModel : IModel
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string DeviceId { get; set; }
        public bool IsAdmin { get; set; }
        public DateTime CreatedDate { get; set; }
        public List<Marker> Markers { get; set; }
        public List<Zone> Zones { get; set; }
    }
}