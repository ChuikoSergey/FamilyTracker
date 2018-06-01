using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Eventing.Reader;
using FamilyTracker.Data.Entity.Base;

namespace FamilyTracker.Data.Entity
{
    public class User : IEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(128)]
        public string Login { get; set; }
        [Required]
        [StringLength(512)]
        public string Password { get; set; }
        [Required]
        [StringLength(20)]
        public string DeviceId { get; set; }
        public bool IsAdmin { get; set; }
        public DateTime CreatedDate { get; set; }
        public ICollection<Marker> Markers { get; set; }
        public ICollection<Zone> Zones { get; set; }
        //public ICollection<User> Friends { get; set; }

        //modelBuilder.Entity<Project>()
        //.HasMany(u => u.Users)
        //    .WithMany(p => p.Projects)
        //    .Map(cs =>
        //{
        //    cs.MapLeftKey("ProjectId");
        //    cs.MapRightKey("UserId");
        //    cs.ToTable("UserProject");
        //});
    }
}