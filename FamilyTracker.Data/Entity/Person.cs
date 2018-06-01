using System.ComponentModel.DataAnnotations;
using FamilyTracker.Data.Entity.Base;

namespace FamilyTracker.Data.Entity
{
    public class Person : IEntity 
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool? Gender { get; set; }
        public byte[] Photo { get; set; }
        public string Email { get; set; }
    }
}
