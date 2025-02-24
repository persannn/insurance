using Insurance_Final_Version.Models;

namespace Insurance_Final_Version.Interfaces
{
    /// <summary>
    /// Interface defining the properties that a Customer should have
    /// </summary>
    public interface ICustomer : IViewModelable
    {
        public abstract string Name { get; set; }
        public abstract string Surname { get; set; }
        public abstract int Age { get; set; }
        public abstract string PhoneNumberPrefix { get; set; }
        public abstract int PhoneNumber { get; set; }
        public abstract string Email { get; set; }
        public abstract List<Insurance>? Insurances { get; }
        public abstract Address Address { get; set; }
    }
}
