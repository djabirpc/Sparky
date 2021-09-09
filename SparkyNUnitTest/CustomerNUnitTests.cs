using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparky
{
    [TestFixture]
    public class CustomerNUnitTests
    {
        private Customer customer;
        [SetUp]
        public void Setup()
        {
            customer = new Customer();
        }

        [Test]
        public void CombineName_InputFirstAndLastName_ReturnFullName()
        {
            //Arrange
            //var customer = new Customer();

            //Act
            customer.GreetAndCombineName("Djabir", "Kahlouche");

            //Assert
            Assert.Multiple(() =>
            {
                Assert.AreEqual(customer.GreetMessage, "Hello, Djabir Kahlouche");
                Assert.That(customer.GreetMessage, Is.EqualTo("Hello, Djabir Kahlouche"));
                Assert.That(customer.GreetMessage, Does.Contain("djabir").IgnoreCase);
                Assert.That(customer.GreetMessage, Does.StartWith("Hello,"));
                Assert.That(customer.GreetMessage, Does.EndWith("Kahlouche"));
                Assert.That(customer.GreetMessage, Does.Match("Hello, [A-Z]{1}[a-z]+ [A-Z]{1}[a-z]+"));
            });
            
        }
    
        [Test]
        public void GreetMessage_NotGreeted_ReturnsNull()
        {
            //Arrange
            //var customer = new Customer();

            //Act
            //customer.GreetAndCombineName("Djabir", "Kahlouche");

            //Assert
            Assert.IsNull(customer.GreetMessage);
        }

        [Test]
        public void DiscountCheck_DefaultCustomer_ReturnsDiscountInRange()
        {
            int result = customer.Discount;
            Assert.That(result, Is.InRange(10, 25));
        }

        [Test]
        public void GreetMessage_GreetedWithoutLastName_ReturnsNotNull()
        {
            customer.GreetAndCombineName("ben", "");

            Assert.IsNotNull(customer.GreetMessage);
            Assert.IsFalse(string.IsNullOrEmpty(customer.GreetMessage));
        }

        [Test]
        public void GreetMessage_EmptyFirstName_ThrowsException()
        {
            var exeptionDetails = Assert.Throws<ArgumentException>(() => customer.GreetAndCombineName("","Kahlouche"));
            Assert.AreEqual("Empty First Name", exeptionDetails.Message);

            Assert.That(() => customer.GreetAndCombineName("", "Kahlouche"),
                Throws.ArgumentException.With.Message.EqualTo("Empty First Name"));

            Assert.Throws<ArgumentException>(() => customer.GreetAndCombineName("", "Kahlouche"));

            Assert.That(() => customer.GreetAndCombineName("", "Kahlouche"),
                Throws.ArgumentException);
        }
    
        [Test]
        public void CustomerType_CreateCustomerWithLessThan100Order_ReturnBasicCustomer()
        {
            customer.OrderTotal = 10;
            var result = customer.GetCustomerDetails();
            Assert.That(result, Is.TypeOf<BasicCustomer>());
        }

        [Test]
        public void CustomerType_CreateCustomerWithMoreThan100Order_ReturnPlatinumCustomer()
        {
            customer.OrderTotal = 110;
            var result = customer.GetCustomerDetails();
            Assert.That(result, Is.TypeOf<PlatinumCustomer>());
        }
    }
}
