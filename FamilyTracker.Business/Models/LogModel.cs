using FamilyTracker.Business.Models.Base;
using System;

namespace FamilyTracker.Business.Models
{
    public class LogModel : IModel
    {
        public int Id { get; set; }
        public EventModel Event { get; set; }
        public string Message { get; set; }
        public DateTime EventDate { get; set; }
        public UserModel User { get; set; }
    }
}