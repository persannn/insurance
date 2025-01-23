using Insurance_Final_Version.Models;

namespace Insurance_Final_Version.Interfaces
{
    /// <summary>
    /// Interface for CustomerRepository
    /// </summary>
    public interface ICustomerRepository : IBaseRepository<Customer>
    {
        /// <summary>
        /// Method that returns a customer entity with loaded Insurance entities.
        /// </summary>
        /// <param name="id">ID of the Customer.</param>
        /// <returns>Customer entity with loaded Insurance entitiles</returns>
        Task<Customer>? GetWithDetails(int id);
    }
}
