using Insurance_Two_Tables.Interfaces;

namespace Insurance_Two_Tables.Models
{
    /// <summary>
    /// A class that contains the data of a customer and the customer's address
    /// </summary>
    public class CustomerAddress : ICustomer, IAddress
    {
        public Customer Customer { get; set; }
        public Address Address { get; set; }
        public int Id { get { return Customer.Id; } set { Customer.Id = value; } }
        public string Name { get { return Customer.Name; } set { Customer.Name = value; } }
        public string Surname { get { return Customer.Surname; } set { Customer.Surname = value; } }
        public int Age { get { return Customer.Age; } set { Customer.Age = value; } }
        public Insurance Insurance { get { return Customer.Insurance; } set { Customer.Insurance = value; } }
        public int CustomerId { get { return Customer.Id; } set { Customer.Id = value; } }
        public string? Street { get { return Address.Street; } set { Address.Street = value; } }
        public int? HouseNumber { get { return Address.HouseNumber; } set { Address.HouseNumber = value; } }
        public int? RegistryNumber { get { return Address.RegistryNumber; } set { Address.RegistryNumber = value; } }
        public string? City { get { return Address.City; } set { Address.City = value; } }

        public CustomerAddress(Customer customer, Address address)
        {
            Customer = customer;
            Address = address;
        }
    }
}
