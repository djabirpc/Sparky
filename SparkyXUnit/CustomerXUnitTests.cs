using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Sparky
{
    public class CustomerXUnitTests
    {
        private Customer customer;
        public CustomerXUnitTests()
        {
            customer = new Customer();
        }

        [Fact]
        public void CombineName_InputFirstAndLastName_ReturnFullName()
        {
            //Arrange
            //var customer = new Customer();

            //Act
            customer.GreetAndCombineName("Djabir", "Kahlouche");

            //Assert
            Assert.Equal("Hello, Djabir Kahlouche",customer.GreetMessage );
            Assert.Contains("Djabir kahlouche".ToLower(),customer.GreetMessage.ToLower());
            Assert.StartsWith("Hello,",customer.GreetMessage);
            Assert.EndsWith("Kahlouche",customer.GreetMessage);

            Assert.Matches("Hello, [A-Z]{1}[a-z]+ [A-Z]{1}[a-z]+",customer.GreetMessage);
            

        }

        [Fact]
        public void GreetMessage_NotGreeted_ReturnsNull()
        {
            //Arrange
            //var customer = new Customer();

            //Act
            //customer.GreetAndCombineName("Djabir", "Kahlouche");

            //Assert
            Assert.Null(customer.GreetMessage);
        }

        [Fact]
        public void DiscountCheck_DefaultCustomer_ReturnsDiscountInRange()
        {
            int result = customer.Discount;
            Assert.InRange(result, 10, 25);
        }

        [Fact]
        public void GreetMessage_GreetedWithoutLastName_ReturnsNotNull()
        {
            customer.GreetAndCombineName("ben", "");

            Assert.NotNull(customer.GreetMessage);
            Assert.False(string.IsNullOrEmpty(customer.GreetMessage));
        }

        [Fact]
        public void GreetMessage_EmptyFirstName_ThrowsException()
        {
            var exeptionDetails = Assert.Throws<ArgumentException>(() => customer.GreetAndCombineName("", "Kahlouche"));
            Assert.Equal("Empty First Name", exeptionDetails.Message);

            Assert.Throws<ArgumentException>(() => customer.GreetAndCombineName("", "Kahlouche"));
        }

        [Fact]
        public void CustomerType_CreateCustomerWithLessThan100Order_ReturnBasicCustomer()
        {
            customer.OrderTotal = 10;
            var result = customer.GetCustomerDetails();
            Assert.IsType<BasicCustomer>(result);
        }

        [Fact]
        public void CustomerType_CreateCustomerWithMoreThan100Order_ReturnPlatinumCustomer()
        {
            customer.OrderTotal = 110;
            var result = customer.GetCustomerDetails();
            Assert.IsType<PlatinumCustomer>(result);
        }
    }
}
