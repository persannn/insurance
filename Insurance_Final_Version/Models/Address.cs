using Insurance_Final_Version.Interfaces;

namespace Insurance_Final_Version.Models
{
    /// <summary>
    /// The Address class stored in the database. It's got one FK - CustomerId - corresponding
    /// to the Id column in Customer table, and a navigation property Customer.
    /// </summary>
    public class Address : IAddress
    {
        /// <summary>
        /// PK of the Address table
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// FK corresponding to the Id column in the Customer table
        /// </summary>
        public int? CustomerId { get; set; }
        public string? Street { get; set; }
        public int? HouseNumber { get; set; }
        public int? RegistryNumber { get; set; }
        public string? City { get; set; }
        /// <summary>
        /// Navigation property
        /// </summary>
        public virtual Customer Customer { get; set; }

        public Address() { }
        /// <summary>
        /// Constructor using the CustomerId parameter
        /// </summary>
        /// <param name="customerId">FK from the Id column in Customer table</param>
        public Address(int customerId)
        {
            CustomerId = customerId;
        }
    }
}
