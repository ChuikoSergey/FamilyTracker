using System;
using System.ComponentModel.DataAnnotations;
using FamilyTracker.Data.Entity.Base;

namespace FamilyTracker.Data.Entity
{
    public class Log : IEntity
    {
        [Key]
        public int Id { get; set; }
        public int EventId { get; set; }
        public Event Event { get; set; }
        [StringLength(256)]
        public string Message { get; set; }
        public DateTime EventDate { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }

    }
}