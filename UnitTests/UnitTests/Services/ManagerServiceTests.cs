using Moq;
using Xunit;
using Services;
using Entities.Models;
using Entities.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;
using Repositories;
using Task = System.Threading.Tasks.Task;

public class ManagerServiceTests
{
    private readonly Mock<IManagerRepository> _mockRepository;
    private readonly ManagerService _managerService;

    public ManagerServiceTests()
    {
        _mockRepository = new Mock<IManagerRepository>();
        _managerService = new ManagerService(_mockRepository.Object);
    }

    [Fact]
    public async Task GetAllAsync_HappyPath_ReturnsManagerList()
    {
        // Arrange
        var managers = new List<Manager>
        {
            new Manager { Id = 1, UserId = 1 },
            new Manager { Id = 2, UserId = 2 }
        };

        _mockRepository.Setup(repo => repo.GetAllAsync()).ReturnsAsync(managers);

        // Act
        var result = await _managerService.GetAllAsync();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(2, result.Count());
    }

    [Fact]
    public async Task GetByIdAsync_HappyPath_ReturnsManager()
    {
        // Arrange
        var manager = new Manager { Id = 1, UserId = 1 };
        _mockRepository.Setup(repo => repo.GetByIdAsync(1)).ReturnsAsync(manager);

        // Act
        var result = await _managerService.GetByIdAsync(1);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(1, result.UserId);
    }

    [Fact]
    public async Task AddAsync_HappyPath_ReturnsId()
    {
        // Arrange
        var manager = new Manager { UserId = 1 };
        _mockRepository.Setup(repo => repo.AddAsync(manager)).ReturnsAsync(1);

        // Act
        var result = await _managerService.AddAsync(manager);

        // Assert
        Assert.Equal(1, result);
    }

    [Fact]
    public async Task UpdateAsync_HappyPath_ReturnsUpdatedManager()
    {
        // Arrange
        var manager = new Manager { Id = 1, UserId = 1 };
        _mockRepository.Setup(repo => repo.UpdateAsync(1, manager)).ReturnsAsync(manager);

        // Act
        var result = await _managerService.UpdateAsync(1, manager);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(1, result.UserId);
    }

    [Fact]
    public async Task GetTeachersByParametersAsync_HappyPath_ReturnsTeacherDetails()
    {
        // Arrange
        var teacherDetails = new List<TeacherDetailsDTO>
        {
            new TeacherDetailsDTO { TeacherId = 1, FirstName = "Teacher 1" },
            new TeacherDetailsDTO { TeacherId = 2, FirstName = "Teacher 2" }
        };

        _mockRepository.Setup(repo => repo.GetTeachersByParametersAsync(1, null, null, null, null, null, null)).ReturnsAsync(teacherDetails);

        // Act
        var result = await _managerService.GetTeachersByParametersAsync(1, null, null, null, null, null, null);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(2, result.Count());
    }

    [Fact]
    public async Task GetByIdAsync_UnhappyPath_ReturnsNull()
    {
        // Arrange
        _mockRepository.Setup(repo => repo.GetByIdAsync(It.IsAny<int>())).ReturnsAsync((Manager)null);

        // Act
        var result = await _managerService.GetByIdAsync(99);

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public async Task AddAsync_UnhappyPath_ReturnsNegativeId()
    {
        // Arrange
        var manager = new Manager { UserId = 1 };
        _mockRepository.Setup(repo => repo.AddAsync(manager)).ReturnsAsync(-1);

        // Act
        var result = await _managerService.AddAsync(manager);

        // Assert
        Assert.Equal(-1, result);
    }

    [Fact]
    public async Task UpdateAsync_UnhappyPath_ReturnsNull()
    {
        // Arrange
        var manager = new Manager { Id = 1, UserId = 1 };
        _mockRepository.Setup(repo => repo.UpdateAsync(1, manager)).ReturnsAsync((Manager)null);

        // Act
        var result = await _managerService.UpdateAsync(1, manager);

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public async Task GetAllAsync_UnhappyPath_ReturnsEmptyList()
    {
        // Arrange
        _mockRepository.Setup(repo => repo.GetAllAsync()).ReturnsAsync(new List<Manager>());

        // Act
        var result = await _managerService.GetAllAsync();

        // Assert
        Assert.NotNull(result);
        Assert.Empty(result);
    }

    [Fact]
    public async Task GetTeachersByParametersAsync_UnhappyPath_ReturnsEmptyList()
    {
        // Arrange
        _mockRepository.Setup(repo => repo.GetTeachersByParametersAsync(It.IsAny<int>(), null, null, null, null, null, null)).ReturnsAsync(new List<TeacherDetailsDTO>());

        // Act
        var result = await _managerService.GetTeachersByParametersAsync(1, null, null, null, null, null, null);

        // Assert
        Assert.NotNull(result);
        Assert.Empty(result);
    }
}
