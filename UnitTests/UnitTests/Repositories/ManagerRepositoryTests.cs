using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities.DTOs;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Moq;
using Moq.EntityFrameworkCore;
using Xunit;
using Task = System.Threading.Tasks.Task;

namespace Repositories.Tests
{
    public class ManagerRepositoryTests
    {
        private readonly Mock<ScheduleMasterContext> _mockContext;
        private readonly ManagerRepository _repository;

        public ManagerRepositoryTests()
        {
            var options = new DbContextOptionsBuilder<ScheduleMasterContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            _mockContext = new Mock<ScheduleMasterContext>();
            _repository = new ManagerRepository(_mockContext.Object);
        }

        [Fact]
        public async Task GetAllAsync_ReturnsAllManagers()
        {
            // Arrange
            var managers = new List<Manager>
            {
                new Manager { Id = 1, UserId = 1 },
                new Manager { Id = 2, UserId = 2 }
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Manager>>();
            mockSet.As<IQueryable<Manager>>().Setup(m => m.Provider).Returns(managers.Provider);
            mockSet.As<IQueryable<Manager>>().Setup(m => m.Expression).Returns(managers.Expression);
            mockSet.As<IQueryable<Manager>>().Setup(m => m.ElementType).Returns(managers.ElementType);
            mockSet.As<IQueryable<Manager>>().Setup(m => m.GetEnumerator()).Returns(managers.GetEnumerator());

            _mockContext.Setup(c => c.Managers).Returns(mockSet.Object);

            // Act
            var result = await _repository.GetAllAsync();

            // Assert
            Assert.Equal(2, result.Count());
        }

        [Fact]
        public async Task GetAllAsync_ReturnsEmpty_WhenNoManagers()
        {
            // Act
            var result = await _repository.GetAllAsync();

            // Assert
            Assert.Empty(result);
        }

        [Fact]
        public async Task GetByIdAsync_ReturnsManager_WhenExists()
        {
            // Arrange
            var manager = new Manager { Id = 1, UserId = 1 };
            _mockContext.Setup(c => c.Managers.FindAsync(1)).ReturnsAsync(manager);

            // Act
            var result = await _repository.GetByIdAsync(1);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(manager.UserId, result.UserId);
        }

        [Fact]
        public async Task GetByIdAsync_ReturnsNull_WhenNotExists()
        {
            // Act
            var result = await _repository.GetByIdAsync(999);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public async Task UpdateAsync_UpdatesManager_WhenExists()
        {
            // Arrange
            var manager = new Manager { Id = 1, UserId = 1 };
            var managers = new List<Manager> { manager }.AsQueryable();

            var mockSet = new Mock<DbSet<Manager>>();
            mockSet.As<IQueryable<Manager>>().Setup(m => m.Provider).Returns(managers.Provider);
            mockSet.As<IQueryable<Manager>>().Setup(m => m.Expression).Returns(managers.Expression);
            mockSet.As<IQueryable<Manager>>().Setup(m => m.ElementType).Returns(managers.ElementType);
            mockSet.As<IQueryable<Manager>>().Setup(m => m.GetEnumerator()).Returns(managers.GetEnumerator());

            _mockContext.Setup(c => c.Managers).Returns(mockSet.Object);
            _mockContext.Setup(c => c.SaveChangesAsync(It.IsAny<CancellationToken>())).ReturnsAsync(1);

            var updatedManager = new Manager { UserId = 2 };

            // Act
            var result = await _repository.UpdateAsync(1, updatedManager);

            // Assert
            Assert.Equal(1, result.Id);
            Assert.Equal(2, result.UserId);
        }

        [Fact]
        public async Task UpdateAsync_ThrowsException_WhenManagerNotExists()
        {
            // Arrange
            var updatedManager = new Manager { UserId = 2 };

            // Act & Assert
            await Assert.ThrowsAsync<DbUpdateConcurrencyException>(() => _repository.UpdateAsync(999, updatedManager));
        }

        [Fact]
        public async Task AddAsync_AddsManager_WhenValid()
        {
            // Arrange
            var manager = new Manager { UserId = 1 };

            // Act
            var resultId = await _repository.AddAsync(manager);

            // Assert
            Assert.Equal(1, resultId);
            Assert.NotNull(await _repository.GetByIdAsync(resultId));
        }

        [Fact]
        public async Task AddAsync_ThrowsException_WhenManagerIsNull()
        {
            // Act & Assert
            await Assert.ThrowsAsync<ArgumentNullException>(() => _repository.AddAsync(null));
        }

        [Fact]
        public async Task GetTeachersByParametersAsync_ReturnsTeachers_WhenExists()
        {
            // Arrange
            var manager = new Manager { Id = 1, UserId = 1 };
            var teacher = new Teacher
            {
                Id = 1,
                User = new User { Username = "teacher@example.com", FirstName = "John", LastName = "Doe" },
            };
            var school = new SchoolManager
            {
                Id = 1,
                ManagerId = manager.Id,
                SchoolId = 1
            };

            var managers = new List<Manager> { manager }.AsQueryable();
            var mockManagersSet = new Mock<DbSet<Manager>>();
            mockManagersSet.As<IQueryable<Manager>>().Setup(m => m.Provider).Returns(managers.Provider);
            mockManagersSet.As<IQueryable<Manager>>().Setup(m => m.Expression).Returns(managers.Expression);
            mockManagersSet.As<IQueryable<Manager>>().Setup(m => m.ElementType).Returns(managers.ElementType);
            mockManagersSet.As<IQueryable<Manager>>().Setup(m => m.GetEnumerator()).Returns(managers.GetEnumerator());

            var managerSchoolTeachers = new List<ManagerSchoolTeacher>
        {
            new ManagerSchoolTeacher { SchoolManager = school, Teacher = teacher }
        }.AsQueryable();
            var mockManagerSchoolTeachersSet = new Mock<DbSet<ManagerSchoolTeacher>>();
            mockManagerSchoolTeachersSet.As<IQueryable<ManagerSchoolTeacher>>().Setup(m => m.Provider).Returns(managerSchoolTeachers.Provider);
            mockManagerSchoolTeachersSet.As<IQueryable<ManagerSchoolTeacher>>().Setup(m => m.Expression).Returns(managerSchoolTeachers.Expression);
            mockManagerSchoolTeachersSet.As<IQueryable<ManagerSchoolTeacher>>().Setup(m => m.ElementType).Returns(managerSchoolTeachers.ElementType);
            mockManagerSchoolTeachersSet.As<IQueryable<ManagerSchoolTeacher>>().Setup(m => m.GetEnumerator()).Returns(managerSchoolTeachers.GetEnumerator());

            _mockContext.Setup(c => c.Managers).Returns(mockManagersSet.Object);
            _mockContext.Setup(c => c.ManagerSchoolTeachers).Returns(mockManagerSchoolTeachersSet.Object);
            _mockContext.Setup(c => c.SaveChangesAsync(It.IsAny<CancellationToken>())).ReturnsAsync(1);

            // Act
            var result = await _repository.GetTeachersByParametersAsync(1, "John", null, null, null, null, null);

            // Assert
            Assert.Single(result);
            Assert.Equal("John", result.First().FirstName);
        }

        [Fact]
        public async Task GetTeachersByParametersAsync_ReturnsEmpty_WhenNoTeachersMatch()
        {
            // Arrange
            var manager = new Manager { Id = 1, UserId = 1 };

            var managers = new List<Manager> { manager }.AsQueryable();
            var mockManagersSet = new Mock<DbSet<Manager>>();
            mockManagersSet.As<IQueryable<Manager>>().Setup(m => m.Provider).Returns(managers.Provider);
            mockManagersSet.As<IQueryable<Manager>>().Setup(m => m.Expression).Returns(managers.Expression);
            mockManagersSet.As<IQueryable<Manager>>().Setup(m => m.ElementType).Returns(managers.ElementType);
            mockManagersSet.As<IQueryable<Manager>>().Setup(m => m.GetEnumerator()).Returns(managers.GetEnumerator());

            // Setup context
            _mockContext.Setup(c => c.Managers).Returns(mockManagersSet.Object);
            _mockContext.Setup(c => c.SaveChangesAsync(It.IsAny<CancellationToken>())).ReturnsAsync(1);

            // Act
            var result = await _repository.GetTeachersByParametersAsync(1, "NonExistent", null, null, null, null, null);

            // Assert
            Assert.Empty(result);
        }
    }
}
