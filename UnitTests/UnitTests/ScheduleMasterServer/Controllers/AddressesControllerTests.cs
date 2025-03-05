using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using ScheduleMasterServer.Controllers;
using Services;
using Task = System.Threading.Tasks.Task;

public class AddressesControllerTests
{
    private readonly Mock<IAddressService> _mockAddressService;
    private readonly AddressesController _controller;

    public AddressesControllerTests()
    {
        _mockAddressService = new Mock<IAddressService>();
        _controller = new AddressesController(_mockAddressService.Object);
    }

    [Fact]
    public async Task GetReturnsOkResultWithAddresses()
    {
        // Arrange
        var addresses = new List<Address> { new Address() }; // Assume Address is a valid model
        _mockAddressService.Setup(service => service.GetAllAsync()).ReturnsAsync(addresses);

        // Act
        var result = await _controller.Get();

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var returnAddresses = Assert.IsAssignableFrom<List<Address>>(okResult.Value);
        Assert.Equal(1, returnAddresses.Count);
    }

    [Fact]
    public async Task GetByIdReturnsOkResultWithAddress()
    {
        // Arrange
        var address = new Address { Id = 1 };
        _mockAddressService.Setup(service => service.GetByIdAsync(1)).ReturnsAsync(address);

        // Act
        var result = await _controller.Get(1);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var returnAddress = Assert.IsType<Address>(okResult.Value);
        Assert.Equal(1, returnAddress.Id);
    }

    [Fact]
    public async Task PostReturnsCreatedAtActionResult()
    {
        // Arrange
        var address = new Address();
        _mockAddressService.Setup(service => service.AddAsync(address)).ReturnsAsync(1);

        // Act
        var result = await _controller.Post(address);

        // Assert
        var createdResult = Assert.IsType<CreatedAtActionResult>(result);
        Assert.Equal(1, createdResult.RouteValues["id"]);
    }

    [Fact]
    public async Task PutReturnsOkResultWithUpdatedAddress()
    {
        // Arrange
        var address = new Address { Id = 1 };
        _mockAddressService.Setup(service => service.UpdateAsync(1, address)).ReturnsAsync(address);

        // Act
        var result = await _controller.Put(1, address);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var returnAddress = Assert.IsType<Address>(okResult.Value);
        Assert.Equal(1, returnAddress.Id);
    }

    [Fact]
    public async Task GetReturnsNotFoundWhenAddressesAreNull()
    {
        // Arrange
        _mockAddressService.Setup(service => service.GetAllAsync()).ReturnsAsync((List<Address>)null);

        // Act
        var result = await _controller.Get();

        // Assert
        Assert.IsType<NotFoundResult>(result);
    }

    [Fact]
    public async Task GetByIdReturnsNoContentWhenAddressDoesNotExist()
    {
        // Arrange
        _mockAddressService.Setup(service => service.GetByIdAsync(1)).ReturnsAsync((Address)null);

        // Act
        var result = await _controller.Get(1);

        // Assert
        Assert.IsType<NoContentResult>(result);
    }

    [Fact]
    public async Task PostReturnsBadRequestWhenModelIsInvalid()
    {
        // Arrange
        var address = new Address(); // Assuming this is invalid
        _mockAddressService.Setup(service => service.AddAsync(address)).ReturnsAsync(0); // Assuming 0 means failure

        // Act
        var result = await _controller.Post(address);

        // Assert
        Assert.IsType<BadRequestResult>(result);
    }

    [Fact]
    public async Task PutReturnsBadRequestWhenUpdateFails()
    {
        // Arrange
        var address = new Address { Id = 1 };
        _mockAddressService.Setup(service => service.UpdateAsync(1, address)).ReturnsAsync((Address)null); // Assuming null means failure

        // Act
        var result = await _controller.Put(1, address);

        // Assert
        Assert.IsType<BadRequestResult>(result);
    }

}
