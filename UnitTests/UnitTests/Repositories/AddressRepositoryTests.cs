using Moq;
using Moq.EntityFrameworkCore;
using Entities.Models;
using Repositories;
using Task = System.Threading.Tasks.Task;

namespace UnitTests.Repositories;

public class AddressRepositoryTests
{
    private readonly Mock<ScheduleMasterContext> _mockContext;
    private readonly AddressRepository _repository;

    public AddressRepositoryTests()
    {
        _mockContext = new Mock<ScheduleMasterContext>();
        _repository = new AddressRepository(_mockContext.Object);
    }

    //[Fact]
    //public async Task GetAllAsync_ReturnsAllAddresses()
    //{
    //    // Arrange
    //    var addresses = new List<Address>
    //{
    //    new() { Id = 1, Street = "123 Main St" },
    //    new() { Id = 2, Street = "456 Maple Ave" }
    //};
    //    var _mockContext = new Mock<ScheduleMasterContext>();
    //    _mockContext.Setup(a => a.Addresses).ReturnsDbSet(addresses);

    //    //var mockSet = new Mock<Address>();
    //    //mockSet.As<IQueryable<Address>>().Setup(m => m.Provider).Returns(addresses.AsQueryable().Provider);
    //    //mockSet.As<IQueryable<Address>>().Setup(m => m.Expression).Returns(addresses.AsQueryable().Expression);
    //    //mockSet.As<IQueryable<Address>>().Setup(m => m.ElementType).Returns(addresses.AsQueryable().ElementType);
    //    //mockSet.As<IQueryable<Address>>().Setup(m => m.GetEnumerator()).Returns(addresses.GetEnumerator());

    //    //_mockContext.Setup(c => c.Addresses).Returns(mockSet.Object);

    //    // Act
    //    var _repository = new AddressRepository(_mockContext.Object);
    //    var result = await _repository.GetAllAsync();

    //    // Assert
    //    Xunit.Assert.Equal(addresses, result);
    //}

    //[Fact]
    //public async Task GetByIdAsync_ReturnsAddress_WhenExists()
    //{
    //    // Arrange
    //    var address = new Address { Id = 1, Street = "123 Main St" };
    //    _mockContext.Setup(c => c.Addresses.FindAsync(1)).ReturnsAsync(address);

    //    // Act
    //    var result = await _repository.GetByIdAsync(1);

    //    // Assert
    //    Assert.NotNull(result);
    //    Assert.Equal("123 Main St", result.Street);
    //}

    //[Fact]
    //public async Task AddAsync_AddsAddress_ReturnsId()
    //{
    //    // Arrange
    //    var address = new Address { Id = 1, Street = "123 Main St" };
    //    _mockContext.Setup(c => c.Addresses.AddAsync(address, CancellationToken.None)).ReturnsAsync((address));
    //    _mockContext.Setup(c => c.SaveChangesAsync(default)).ReturnsAsync(1);

    //    // Act
    //    var result = await _repository.AddAsync(address);

    //    // Assert
    //    Assert.Equal(1, result);
    //}

    //[Fact]
    //public async Task GetByIdAsync_ReturnsNull_WhenNotExists()
    //{
    //    // Arrange
    //    _mockContext.Setup(c => c.Addresses.FindAsync(It.IsAny<int>())).ReturnsAsync((Address)null);

    //    // Act
    //    var result = await _repository.GetByIdAsync(99);

    //    // Assert
    //    Assert.Null(result);
    //}

    //[Fact]
    //public async Task UpdateAsync_ThrowsException_WhenAddressIsNull()
    //{
    //    // Arrange
    //    Address address = null;

    //    // Act & Assert
    //    await Assert.ThrowsAsync<ArgumentNullException>(() => _repository.UpdateAsync(1, address));
    //}

}