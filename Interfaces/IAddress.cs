using Insurance_Two_Tables.Models;

namespace Insurance_Two_Tables.Interfaces
{
    /// <summary>
    /// Interface defining the properties that an Address should have
    /// </summary>
    public interface IAddress
    {
        public abstract int Id { get; set; }
        public abstract int CustomerId { get; set; } 
        public abstract string? Street { get; set; }
        public abstract int? HouseNumber { get; set; }
        public abstract int? RegistryNumber { get; set; }
        public abstract string? City { get; set; }
        public abstract Customer Customer { get; set; }
    }
}
