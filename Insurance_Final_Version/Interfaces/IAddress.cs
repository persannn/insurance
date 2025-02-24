using Insurance_Final_Version.Models;

namespace Insurance_Final_Version.Interfaces
{
    /// <summary>
    /// Interface defining the properties that an Address should have
    /// </summary>
    public interface IAddress : IViewModelable
    {
        public abstract string? Street { get; set; }
        public abstract int? HouseNumber { get; set; }
        public abstract int? RegistryNumber { get; set; }
        public abstract string? City { get; set; }
        /// <summary>
        /// Navigation property
        /// </summary>
        public abstract Customer Customer { get; set; }
    }
}
