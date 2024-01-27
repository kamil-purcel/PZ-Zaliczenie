using AutoMapper;
using Moq;
using WarehouseMVC.Application.Services;
using WarehouseMVC.Application.ViewModels.Customer;
using WarehouseMVC.Domain.Interfaces;
using WarehouseMVC.Domain.Model;

namespace WarehouseMVC.Tests;

public class UnitTest1
{
    [Fact]
        public void GetAllCustomersForList_ReturnsCorrectList()
        {
            var mockCustomerRepository = new Mock<ICustomerRepository>();
            var mockAddressRepository = new Mock<IAddressRepository>();
            var mockMapper = new Mock<IMapper>();

            var customers = new List<Customer>
            {
                new Customer { Id = 1, Name = "test 1", IsActive = true },
                new Customer { Id = 2, Name = "test 1", IsActive = true }
            };

            mockCustomerRepository.Setup(repo => repo.GetAllActiveCustomers()).Returns(customers.AsQueryable());
            
            mockMapper.Setup(mapper => mapper.ConfigurationProvider).Returns(new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Customer, CustomerForListVm>();
            }));
            
            var customerService = new CustomerService(mockCustomerRepository.Object, mockAddressRepository.Object, mockMapper.Object);

            // Act
            var result = customerService.GetAllCustomersForList();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count);
            Assert.Equal(customers.Count, result.Customers.Count);
            Assert.Equal(customers.First().Name, result.Customers.First().Name);
            Assert.Equal(customers.Last().Name, result.Customers.Last().Name);
        }

        [Fact]
        public void GetAllCustomersForList_PaginatesCorrectly()
        {
            // Arrange
            var pageSize = 1;
            var pageNo = 2;
            var searchString = "Test";

            var mockCustomerRepository = new Mock<ICustomerRepository>();
            var mockAddressRepository = new Mock<IAddressRepository>();
            var mockMapper = new Mock<IMapper>();

            var customers = new List<Customer>
            {
                new Customer { Id = 1, Name = "Test 1", IsActive = true },
                new Customer { Id = 2, Name = "Test 2", IsActive = true },
                new Customer { Id = 3, Name = "Another Test", IsActive = true }
            };

            mockCustomerRepository.Setup(repo => repo.GetAllActiveCustomers()).Returns(customers.AsQueryable());
            mockMapper.Setup(mapper => mapper.ConfigurationProvider).Returns(new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Customer, CustomerForListVm>();
            }));
            
            var customerService = new CustomerService(mockCustomerRepository.Object, mockAddressRepository.Object, mockMapper.Object);

            // Act
            var result = customerService.GetAllCustomersForList(pageSize, pageNo, searchString);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(pageNo, result.CurrentPage);
            Assert.Equal(pageSize, result.PageSize);
            Assert.Equal(searchString, result.SearchString);
            Assert.Equal(1, result.Customers.Count);
        }
    
}