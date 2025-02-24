using Insurance_Final_Version.Managers;
using Insurance_Final_Version.Models;
using Moq;

namespace TestProjectInsurance
{
    public class MyMockFactory
    {
        private List<CustomerViewModel?> viewModels = new List<CustomerViewModel?>
        {
            new CustomerViewModel { Id = 0, CustomerId = 0, Name = "Martha", Surname = "Jennings", Age = 27, Email = "marthajennings@gmail.com", PhoneNumberPrefix = "+180", PhoneNumber = 123456789},
            new CustomerViewModel { Id = 1, CustomerId = 1, Name = "Phil", Surname = "Hode", Age = 33, Email = "philhode@gmail.com", PhoneNumberPrefix = "+180", PhoneNumber = 148935482}
        };


        public List<CustomerViewModel?> CustomerViewModels
        {
            get
            {
                return viewModels;
            }
        }

        public Mock<CustomerManager> GetMockCustomerManager()
        {
            var managerMock = new Mock<CustomerManager>();
            managerMock
                .Setup(m => m.GetAll())
                .Returns(Task.FromResult(viewModels));
            managerMock
                .Setup(m => m.GetById(0))
                .Returns(Task.FromResult(viewModels[0]));
            managerMock
                .Setup(m => m.GetById(1))
                .Returns(Task.FromResult(viewModels[1]));
            managerMock
                .Setup(m => m.GetById(It.IsNotIn(0, 1)))
                .Returns(Task.FromResult((CustomerViewModel?)null));

            return managerMock;
        }
    }
}
