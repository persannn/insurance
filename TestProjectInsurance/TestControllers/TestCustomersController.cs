using Insurance_Final_Version.Controllers;
using Insurance_Final_Version.Managers;
using Insurance_Final_Version.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Moq;

namespace TestProjectInsurance.TestControllers
{
    [TestClass]
    public class TestCustomersController
    {
        private MyMockFactory mockFactory;

        public TestCustomersController()
        {
            mockFactory = new MyMockFactory();
        }

        #region Index()
        [TestMethod]
        public void TestIndex()
        {
            // Arrange
            Mock<CustomerManager> managerMock = mockFactory.GetMockCustomerManager();

            CustomersController controller = new CustomersController(managerMock.Object);

            // Act
            Task<IActionResult> allCustomersView = controller.Index();

            // Assert
            ViewResult result = (ViewResult)allCustomersView.Result;
            List<CustomerViewModel>? resultModel = (List<CustomerViewModel>?)result.Model;

            Assert.IsNotNull(resultModel);
            Assert.AreEqual(mockFactory.CustomerViewModels, resultModel);
        }

        [TestMethod]
        public void TestIndexWasAdded()
        {
            // Arrange
            Mock<CustomerManager> managerMock = mockFactory.GetMockCustomerManager();

            CustomersController controller = new CustomersController(managerMock.Object);

            // Act
            Task<IActionResult> allCustomersView = controller.Index(true, false);

            // Assert
            ViewResult viewResult = (ViewResult)allCustomersView.Result;
            ViewDataDictionary dictionary = viewResult.ViewData;
            Assert.IsTrue(dictionary.ContainsKey("wasAdded"));
            Assert.IsTrue((bool)dictionary["wasAdded"]);
            Assert.IsFalse((bool)dictionary["wasDeleted"]);
        }

        [TestMethod]
        public void TestIndexWasDeleted()
        {
            // Arrange
            Mock<CustomerManager> managerMock = mockFactory.GetMockCustomerManager();

            CustomersController controller = new CustomersController(managerMock.Object);

            // Act
            Task<IActionResult> allCustomersView = controller.Index(false, true);

            // Assert
            ViewResult viewResult = (ViewResult)allCustomersView.Result;
            ViewDataDictionary dictionary = viewResult.ViewData;
            Assert.IsTrue(dictionary.ContainsKey("wasAdded"));
            Assert.IsFalse((bool)dictionary["wasAdded"]);
            Assert.IsTrue((bool)dictionary["wasDeleted"]);
        }
        #endregion

        #region Details
        [TestMethod]
        public void TestDetails()
        {
            // Arrange
            Mock<CustomerManager> managerMock = mockFactory.GetMockCustomerManager();
            managerMock
                .Setup(m => m.Mapper.Map<List<InsuranceViewModel>>(It.IsAny<List<Insurance>?>()))
                .Returns(new List<InsuranceViewModel>());

            CustomersController controller = new CustomersController(managerMock.Object);

            // Act
            Task<IActionResult> detailsView = controller.Details(0);

            // Assert
            ViewResult viewResult = (ViewResult)detailsView.Result;
            CustomerViewModel? viewModel = (CustomerViewModel?)viewResult.Model;

            Assert.IsNotNull(viewModel);
            Assert.IsFalse((bool)viewResult.ViewData["wasEdited"]);
            Assert.AreEqual(viewModel, mockFactory.CustomerViewModels[0]);
        }

        [TestMethod]
        public void TestDetailsWasEdited()
        {
            // Arrange
            Mock<CustomerManager> managerMock = mockFactory.GetMockCustomerManager();
            managerMock
                .Setup(m => m.Mapper.Map<List<InsuranceViewModel>>(It.IsAny<List<Insurance>?>()))
                .Returns(new List<InsuranceViewModel>());

            CustomersController controller = new CustomersController(managerMock.Object);

            // Act
            Task<IActionResult> detailsView = controller.Details(0, true);

            // Assert
            ViewResult viewResult = (ViewResult)detailsView.Result;
            CustomerViewModel? viewModel = (CustomerViewModel?)viewResult.Model;

            Assert.IsNotNull(viewModel);
            Assert.IsTrue((bool)viewResult.ViewData["wasEdited"]);
            Assert.AreEqual(viewModel, mockFactory.CustomerViewModels[0]);
        }

        [TestMethod]
        public void TestDetailsIdNotFound()
        {
            // Arrange
            Mock<CustomerManager> managerMock = mockFactory.GetMockCustomerManager();
            managerMock
                .Setup(m => m.Mapper.Map<List<InsuranceViewModel>>(It.IsAny<List<Insurance>?>()))
                .Returns(new List<InsuranceViewModel>());

            CustomersController controller = new CustomersController(managerMock.Object);

            // Act
            Task<IActionResult> detailsView = controller.Details(1348644982);
            var result = detailsView.Result as NotFoundResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(404, result.StatusCode);
        }
        #endregion

        #region Create()
        [TestMethod]
        public void TestCreateAddToDatabase()
        {
            // Arrange
            CustomerViewModel viewModel = new CustomerViewModel { Id = 2, CustomerId = 2, Name = "Bethadyne", Surname = "Amphetamine", Age = 69, Email = "bethyamphi@gmail.com", PhoneNumberPrefix = "+170", PhoneNumber = 159897023 };

            Mock<CustomerManager> managerMock = mockFactory.GetMockCustomerManager();
            managerMock
                .Setup(m => m.Add(It.IsAny<CustomerViewModel>()))
                .Returns((CustomerViewModel c) => c);

            CustomersController controller = new CustomersController(managerMock.Object);

            // Act
            Task<IActionResult> createView = controller.Create(viewModel);
            ViewResult result = (ViewResult)createView.Result;
            CustomerViewModel? returnedViewModel = (CustomerViewModel?)result.Model;

            // Assert
            Assert.AreEqual(viewModel, returnedViewModel);
        }
        #endregion
    }
}
