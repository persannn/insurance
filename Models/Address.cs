using Insurance_Two_Tables.Interfaces;

namespace Insurance_Two_Tables.Models
{
    public class Address : IAddress
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string? Street { get; set; }
        public int? HouseNumber { get; set; }
        public int? RegistryNumber { get; set; }
        public string? City { get; set; }
        public virtual Customer Customer { get; set; }

        public Address() { }
        public Address(int customerId)
        {
            CustomerId = customerId;
        }
    }
}
