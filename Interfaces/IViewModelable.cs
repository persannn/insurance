namespace Insurance_Final_Version.Interfaces
{
    public interface IViewModelable
    {
        /// <summary>
        /// PK of the table
        /// </summary>
        public abstract int Id { get; set; }
        /// <summary>
        /// FK corresponding to the ID column in the Customers table
        /// </summary>
        public abstract int? CustomerId { get; set; }
    }
}
