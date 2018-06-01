using FamilyTracker.Business.Models.Base;

namespace FamilyTracker.Business.Models
{
    public class PersonModel : IModel
    {
        public int Id { get; set; }
        public UserModel User { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool? Gender { get; set; }
        public byte[] Photo { get; set; }
        public string Email { get; set; }
    }
}