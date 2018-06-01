using System.Collections.Generic;
using FamilyTracker.Data.Entity.Base;
using System.ComponentModel.DataAnnotations;

namespace FamilyTracker.Data.Entity
{
    public class Event: IEntity
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Log> Logs { get; set; }

        public Event()
        {
            Logs = new List<Log>();
        }
    }
}
