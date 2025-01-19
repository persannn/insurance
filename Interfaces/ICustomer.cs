using Insurance_Two_Tables.Models;

namespace Insurance_Two_Tables.Interfaces
{
    /// <summary>
    /// Interface defining the properties that a Customer should have
    /// </summary>
    public interface ICustomer
    {
        public abstract int Id { get; set; }
        public abstract string Name { get; set; }
        public abstract string Surname { get; set; }
        public abstract int Age { get; set; }
        public List<Insurance> Insurance { get; }
        public abstract Address Address { get; set; }
    }
}
