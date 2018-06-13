using Microsoft.VisualStudio.TestTools.UnitTesting;
using PinnacleSample;

namespace PinnacleSampleTests
{
    [TestClass]
    public class PartInvoiceControllerTests
    {
        FakeConnection FakeConnectionInstance = new FakeConnection();
        FakeAvailabilityServiceClient FakeAvailabilityServiceClientInstance = new FakeAvailabilityServiceClient();
        private CreatePartInvoiceResult CreatePartInvoiceResultSuccessful = new CreatePartInvoiceResult(true);
        private CreatePartInvoiceResult CreatePartInvoiceResultUnsuccessful = new CreatePartInvoiceResult(false);

        // TestMethod names are self-explanatory..

        [TestMethod]
        public void CreatePartInvoice_WithEmptyStockCode_ShouldReturnCreatePartInvoiceResultWithSuccessFalse()
        {
            // Arrange
            PartInvoiceController PartInvoiceControllerInstance = new PartInvoiceController(FakeConnectionInstance, FakeAvailabilityServiceClientInstance);
            string stockCode = string.Empty;
            int quantity = 1;
            string customerName = "Abernathy";
            CreatePartInvoiceResult expected = CreatePartInvoiceResultUnsuccessful;

            // Act
            var actual = PartInvoiceControllerInstance.CreatePartInvoice(stockCode, quantity, customerName);

            // Assert
            Assert.IsInstanceOfType(actual, typeof(CreatePartInvoiceResult));
            Assert.AreEqual(actual.GetType(), expected.GetType());
            Assert.AreEqual(actual.Success, expected.Success);
        }

        [TestMethod]
        public void CreatePartInvoice_WithZeroQuantity_ShouldReturnCreatePartInvoiceResultWithSuccessFalse()
        {
            // Arrange
            PartInvoiceController PartInvoiceControllerInstance = new PartInvoiceController(FakeConnectionInstance, FakeAvailabilityServiceClientInstance);
            string stockCode = "HON";
            int quantity = 0;
            string customerName = "Abernathy";
            CreatePartInvoiceResult expected = CreatePartInvoiceResultUnsuccessful;

            // Act
            var actual = PartInvoiceControllerInstance.CreatePartInvoice(stockCode, quantity, customerName);

            // Assert
            Assert.IsInstanceOfType(actual, typeof(CreatePartInvoiceResult));
            Assert.AreEqual(actual.GetType(), expected.GetType());
            Assert.AreEqual(actual.Success, expected.Success);
        }

        [TestMethod]
        public void CreatePartInvoice_WithCustomerIDLessThanOrEqualZero_ShouldReturnCreatePartInvoiceResultWithSuccessFalse()
        {
            // Arrange
            PartInvoiceController PartInvoiceControllerInstance = new PartInvoiceController(FakeConnectionInstance, FakeAvailabilityServiceClientInstance);
            string stockCode = "ASA";
            int quantity = 0;
            string customerName = "Agos";
            CreatePartInvoiceResult expected = CreatePartInvoiceResultUnsuccessful;

            // Act
            var actual = PartInvoiceControllerInstance.CreatePartInvoice(stockCode, quantity, customerName);

            // Assert
            Assert.IsInstanceOfType(actual, typeof(CreatePartInvoiceResult));
            Assert.AreEqual(actual.GetType(), expected.GetType());
            Assert.AreEqual(actual.Success, expected.Success);
        }

        [TestMethod]
        public void CreatePartInvoice_WithAvailabilityLessThanOrEqualZero_ShouldReturnCreatePartInvoiceResultWithSuccessFalse()
        {
            // Arrange
            PartInvoiceController PartInvoiceControllerInstance = new PartInvoiceController(FakeConnectionInstance, FakeAvailabilityServiceClientInstance);
            string stockCode = "ASA";
            int quantity = 0;
            string customerName = "Agos";
            CreatePartInvoiceResult expected = CreatePartInvoiceResultUnsuccessful;

            // Act
            var actual = PartInvoiceControllerInstance.CreatePartInvoice(stockCode, quantity, customerName);

            // Assert
            Assert.IsInstanceOfType(actual, typeof(CreatePartInvoiceResult));
            Assert.AreEqual(actual.GetType(), expected.GetType());
            Assert.AreEqual(actual.Success, expected.Success);
        }

        [TestMethod]
        public void CreatePartInvoice_WithSatisfactoryArgument_ShouldReturnCreatePartInvoiceResultWithSuccessTrue()
        {
            // Arrange
            PartInvoiceController PartInvoiceControllerInstance = new PartInvoiceController(FakeConnectionInstance, FakeAvailabilityServiceClientInstance);
            string stockCode = "HON";
            int quantity = 10;
            string customerName = "Abernathy";
            CreatePartInvoiceResult expected = CreatePartInvoiceResultSuccessful;

            // Act
            var actual = PartInvoiceControllerInstance.CreatePartInvoice(stockCode, quantity, customerName);

            // Assert
            Assert.IsInstanceOfType(actual, typeof(CreatePartInvoiceResult));
            Assert.AreEqual(actual.GetType(), expected.GetType());
            Assert.AreEqual(actual.Success, expected.Success);
        }
    }

    /// <summary>
    /// Mock implementation for database connection
    /// </summary>
    public class FakeConnection : IPersistanceConnection
    {
        public Customer GetCustomer(string customerName)
        {
            Customer _customer;
            if (customerName == "Abernathy")
            {
                _customer = new Customer
                {
                    Name = "Abernathy",
                    Address = "Cook County",
                    ID = 1
                };
            }
            else
            {
                _customer = new Customer
                {
                    Name = "Lockhart",
                    Address = "Chicago",
                    ID = 0
                };
            }
            return _customer;
        }

        public void AddPartInvoice(PartInvoice partInvoice)
        {
        }
    }

    /// <summary>
    /// Mock implementation for service client
    /// </summary>
    public class FakeAvailabilityServiceClient: IPartAvailabilityServiceClient
    {
        public int GetAvailability(string stockCode)
        {
            if(stockCode == "HON")
            {
                return 10;
            }
            else
            {
                return 0;
            }
        }
    }

}
