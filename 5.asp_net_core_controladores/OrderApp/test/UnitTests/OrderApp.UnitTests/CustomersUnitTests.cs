using FluentAssertions;
using OrderApp.Domain;
using OrderApp.Domain.Exceptions;
using System;
using Xunit;

namespace OrderApp.UnitTests
{
    public class CustomersUnitTests
    {
        private readonly Random _random;

        public CustomersUnitTests() 
        {
            _random = new Random();
        }

        [Fact]
        public void create_customer_is_ok_when_pass_params_ok() 
        {
            // Arrange
            var id = _random.Next(1, 100);
            var name = "Pepe";
            var surname = "Lopez";
            var age = _random.Next(18, 100);
            var email = "email@email.com";

            //Act
            var customer = new Customer(id, name, surname, age, email);

            //Assert
            customer.Id.Should().Be(id);
            customer.Name.Should().Be(name);
            customer.Surname.Should().Be(surname);
            customer.Age.Should().Be(age);
            customer.Email.Should().Be(email);
            customer.Active.Should().Be(true);
        }


        [Fact]
        public void create_customer_with_name_null_should_thrown_an_exception()
        {
            // Arrange
            var id = _random.Next(1, 100);
            string name = null;
            var surname = "Lopez";
            var age = 20;
            var email = "email@email.com";

            //Act
            Action customerCreate = () => new Customer(id, name, surname, age, email);

            //Assert
            Assert.Throws<CustomerConfigurationException>(customerCreate);
        }

        [Fact]
        public void create_customer_with_name_empty_should_thrown_an_exception()
        {
            // Arrange
            var id = _random.Next(1, 100);
            string name = "";
            var surname = "Lopez";
            var age = 20;
            var email = "email@email.com";

            //Act
            Action customerCreate = () => new Customer(id, name, surname, age, email);

            //Assert
            Assert.Throws<CustomerConfigurationException>(customerCreate);
        }

        [Fact]
        public void create_customer_with_surname_null_should_thrown_an_exception()
        {
            // Arrange
            var id = _random.Next(1, 100);
            var name = "Pepe";
            string surname = null;
            var age = 20;
            var email = "email@email.com";

            //Act
            Action customerCreate = () => new Customer(id, name, surname, age, email);

            //Assert
            Assert.Throws<CustomerConfigurationException>(customerCreate);
        }


        [Fact]
        public void create_customer_with_age_minor_18_null_should_thrown_an_exception()
        {
            // Arrange
            var id = _random.Next(1, 100);
            var name = "Pepe";
            string surname = "Lopez";
            var age = _random.Next(1, 17); ;
            var email = "email@email.com";

            //Act
            Action customerCreate = () => new Customer(id, name, surname, age, email);

            //Assert
            Assert.Throws<CustomerConfigurationException>(customerCreate);
        }

        [Fact]
        public void create_customer_with_email_without_arroba_null_should_thrown_an_exception()
        {
            // Arrange
            var id = _random.Next(1, 100);
            var name = "Pepe";
            string surname = "Lopez";
            var age = _random.Next(18, 100);
            var email = "email";

            //Act
            Action customerCreate = () => new Customer(id, name, surname, age, email);

            //Assert
            Assert.Throws<CustomerConfigurationException>(customerCreate);
        }

        [Fact]
        public void update_customer_with_data_ok()
        {
            // Arrange
            var customer = new Customer(1, "Pepe", "Lopez", 25, "email@email.com");
            var name = "Juan";
            string surname = "Sanchez";
            var age = _random.Next(18, 100);
            var email = "newemail@email.com";

            //Act
            customer.Update(name, surname, age, email);

            //Assert
            customer.Id.Should().Be(1);
            customer.Name.Should().Be(name);
            customer.Surname.Should().Be(surname);
            customer.Age.Should().Be(age);
            customer.Email.Should().Be(email);
            customer.Active.Should().Be(true);
        }

        [Fact]
        public void update_customer_with_name_null_thrown_an_exception()
        {
            // Arrange
            var customer = new Customer(1, "Pepe", "Lopez", 25, "email@email.com");
            string name = null;
            string surname = "Sanchez";
            var age = _random.Next(18, 100);
            var email = "newemail@email.com";

            //Act
            Action updateCustomer = () => customer.Update(name, surname, age, email);

            //Assert
            Assert.Throws<CustomerConfigurationException>(updateCustomer);
        }

        [Fact]
        public void update_customer_with_surname_null_thrown_an_exception()
        {
            // Arrange
            var customer = new Customer(1, "Pepe", "Lopez", 25, "email@email.com");
            string name = "Pepe";
            string surname = null;
            var age = _random.Next(18, 100);
            var email = "newemail@email.com";

            //Act
            Action updateCustomer = () => customer.Update(name, surname, age, email);

            //Assert
            Assert.Throws<CustomerConfigurationException>(updateCustomer);
        }

        [Fact]
        public void desactive_customer_should_put_active_to_false()
        {
            // Arrange
            var customer = new Customer(1, "Pepe", "Lopez", 25, "email@email.com");

            // Act
            customer.Desactive();

            // Assert
            customer.Active.Should().Be(false);
        }

        [Fact]
        public void reactive_customer_should_put_active_to_true()
        {
            // Arrange
            var customer = new Customer(1, "Pepe", "Lopez", 25, "email@email.com");

            // Act
            customer.Reactive();

            // Assert
            customer.Active.Should().Be(true);
        }

        [Fact]
        public void reactive_customer_when_is_desactive_should_put_active_to_true()
        {
            // Arrange
            var customer = new Customer(1, "Pepe", "Lopez", 25, "email@email.com");
            customer.Desactive();

            // Act
            customer.Reactive();

            // Assert
            customer.Active.Should().Be(true);
        }
    }
}
