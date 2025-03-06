using Moq;
using Xunit;
using Services;
using Entities.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Repositories;
using Task = System.Threading.Tasks.Task;

namespace UnitTests.Services;

public class AddressServiceTests
{
    private readonly Mock<IAddressRepository> _mockRepository;
    private readonly AddressService _addressService;

    public AddressServiceTests()
    {
        _mockRepository = new Mock<IAddressRepository>();
        _addressService = new AddressService(_mockRepository.Object);
    }

    [Fact]
    public async Task GetAllAsyncHappyPathReturnsAddressList()
    {
        // Arrange
        var addresses = new List<Address>
    {
        new() { Id = 1, Street = "Main St", City = "Sample City" },
        new() { Id = 2, Street = "Second St", City = "Sample City" }
    };

        _mockRepository.Setup(repo => repo.GetAllAsync()).ReturnsAsync(addresses);

        // Act
        var result = await _addressService.GetAllAsync();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(2, result.Count());
    }

    [Fact]
    public async Task GetByIdAsyncHappyPathReturnsAddress()
    {
        // Arrange
        var address = new Address { Id = 1, Street = "Main St", City = "Sample City" };
        _mockRepository.Setup(repo => repo.GetByIdAsync(1)).ReturnsAsync(address);

        // Act
        var result = await _addressService.GetByIdAsync(1);

        // Assert
        Assert.NotNull(result);
        Assert.Equal("Main St", result.Street);
    }

    [Fact]
    public async Task AddAsyncHappyPathReturnsId()
    {
        // Arrange
        var address = new Address { Street = "Main St", City = "Sample City" };
        _mockRepository.Setup(repo => repo.AddAsync(address)).ReturnsAsync(1);

        // Act
        var result = await _addressService.AddAsync(address);

        // Assert
        Assert.Equal(1, result);
    }

    [Fact]
    public async Task UpdateAsyncHappyPathReturnsUpdatedAddress()
    {
        // Arrange
        var address = new Address { Id = 1, Street = "Main St", City = "Sample City" };
        _mockRepository.Setup(repo => repo.UpdateAsync(1, address)).ReturnsAsync(address);

        // Act
        var result = await _addressService.UpdateAsync(1, address);

        // Assert
        Assert.NotNull(result);
        Assert.Equal("Main St", result.Street);
    }

    [Fact]
    public async Task GetByIdAsyncUnhappyPathReturnsNull()
    {
        // Arrange
        _mockRepository.Setup(repo => repo.GetByIdAsync(It.IsAny<int>())).ReturnsAsync((Address)null);

        // Act
        var result = await _addressService.GetByIdAsync(99);

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public async Task AddAsync_UnhappyPath_ReturnsNegativeId()
    {
        // Arrange
        var address = new Address { Street = "Main St", City = "Sample City" };
        _mockRepository.Setup(repo => repo.AddAsync(address)).ReturnsAsync(-1);

        // Act
        var result = await _addressService.AddAsync(address);

        // Assert
        Assert.Equal(-1, result);
    }

    [Fact]
    public async Task UpdateAsyncUnhappyPathReturnsNull()
    {
        // Arrange
        var address = new Address { Id = 1, Street = "Main St", City = "Sample City" };
        _mockRepository.Setup(repo => repo.UpdateAsync(1, address)).ReturnsAsync((Address)null);

        // Act
        var result = await _addressService.UpdateAsync(1, address);

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public async Task GetAllAsyncUnhappyPathReturnsEmptyList()
    {
        // Arrange
        _mockRepository.Setup(repo => repo.GetAllAsync()).ReturnsAsync(new List<Address>());
        // Act
        var result = await _addressService.GetAllAsync();

        // Assert
        Assert.NotNull(result);
        Assert.Empty(result);
    }

}