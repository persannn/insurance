using Insurance_Final_Version.Interfaces;

namespace Insurance_Final_Version.Models
{
    public class Insurance : IInsurance
    {
        /// <summary>
        /// PK of the Insurance table
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// FK corresponding to the ID column in the Customer table
        /// </summary>
        public int CustomerId { get; set; }
        /// <summary>
        /// What the insurance is for
        /// </summary>
        public string InsuranceType { get; set; } = "";
        /// <summary>
        /// The monetary value of the insurance in CZK
        /// </summary>
        public int InsuranceValue { get; set; }
        /// <summary>
        /// Navigation property
        /// </summary>
        public virtual Customer Customer { get; set; } = null!;

        public Insurance() { }
        /// <summary>
        /// Constructor using the CustomerId parameter
        /// </summary>
        /// <param name="customerId"></param>
        public Insurance(int customerId)
        {
            CustomerId = customerId;
        }
    }
}
