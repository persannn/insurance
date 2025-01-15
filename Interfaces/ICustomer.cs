using Insurance_Two_Tables.Models;

namespace Insurance_Two_Tables.Interfaces
{
    public interface ICustomer
    {
        public abstract int Id { get; set; }
        public abstract string Name { get; set; }
        public abstract string Surname { get; set; }
        public abstract int Age { get; set; }
        public string Insurance { get; set; }
        public abstract Address Address { get; set; }
    }
}
