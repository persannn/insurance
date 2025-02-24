using Insurance_Final_Version.Models;

namespace Insurance_Final_Version.Interfaces
{
    /// <summary>
    /// Interface that defines what properties an Insurance should have
    /// </summary>
    public interface IInsurance : IViewModelable
    {
        /// <summary>
        /// What the insurance is for
        /// </summary>
        public abstract string InsuranceType { get; set; }
        /// <summary>
        /// The monetary value of the insurance
        /// </summary>
        public abstract int InsuranceValue { get; set; }
        /// <summary>
        /// Navigation property
        /// </summary>
        public abstract Customer Customer { get; set; }
    }
}
