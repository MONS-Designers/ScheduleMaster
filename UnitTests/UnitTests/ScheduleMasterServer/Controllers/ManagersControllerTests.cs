using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.DTOs;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using Moq;
using ScheduleMasterServer.Controllers;
using Services;
using Task = System.Threading.Tasks.Task;

namespace UnitTests.ScheduleMasterServer.Controllers
{
    public class ManagersControllerTests
    {
        [Fact]
        public async Task GetReturnsOkWhenManagersExist()
        {
            // Arrange
            var mockService = new Mock<IManagerService>();
            mockService.Setup(service => service.GetAllAsync()).ReturnsAsync(new List<Manager> { new Manager() });
            var controller = new ManagersController(mockService.Object);

            // Act
            var result = await controller.Get();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var managers = Assert.IsAssignableFrom<IEnumerable<Manager>>(okResult.Value);
            Assert.NotEmpty(managers);
        }

        [Fact]
        public async Task GetReturnsNotFoundWhenNoManagersExist()
        {
            // Arrange
            var mockService = new Mock<IManagerService>();
            mockService.Setup(service => service.GetAllAsync()).ReturnsAsync((IEnumerable<Manager>)null);
            var controller = new ManagersController(mockService.Object);

            // Act
            var result = await controller.Get();

            // Assert
            Assert.IsType<NotFoundResult>(result.Result);
        }

        [Fact]
        public async Task GetByIdReturnsOkWhenManagerExists()
        {
            // Arrange
            var mockService = new Mock<IManagerService>();
            var manager = new Manager { Id = 1 };
            mockService.Setup(service => service.GetByIdAsync(1)).ReturnsAsync(manager);
            var controller = new ManagersController(mockService.Object);

            // Act
            var result = await controller.Get(1);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnedManager = Assert.IsType<Manager>(okResult.Value);
            Assert.Equal(manager.Id, returnedManager.Id);
        }

        [Fact]
        public async Task GetByIdReturnsNotFoundWhenManagerDoesNotExist()
        {
            // Arrange
            var mockService = new Mock<IManagerService>();
            mockService.Setup(service => service.GetByIdAsync(1)).ReturnsAsync((Manager)null);
            var controller = new ManagersController(mockService.Object);

            // Act
            var result = await controller.Get(1);

            // Assert
            Assert.IsType<NotFoundResult>(result.Result);
        }

        [Fact]
        public async Task PutReturnsOkWhenUpdateIsSuccessful()
        {
            // Arrange
            var mockService = new Mock<IManagerService>();
            var manager = new Manager { Id = 1 };
            mockService.Setup(service => service.UpdateAsync(1, manager)).ReturnsAsync(manager);
            var controller = new ManagersController(mockService.Object);

            // Act
            var result = await controller.Put(1, manager);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var updatedManager = Assert.IsType<Manager>(okResult.Value);
            Assert.Equal(manager.Id, updatedManager.Id);
        }

        [Fact]
        public async Task PutReturnsBadRequestWhenIdDoesNotMatch()
        {
            // Arrange
            var mockService = new Mock<IManagerService>();
            var manager = new Manager { Id = 2 };
            var controller = new ManagersController(mockService.Object);

            // Act
            var result = await controller.Put(1, manager);

            // Assert
            Assert.IsType<BadRequestResult>(result);
        }

        [Fact]
        public async Task PutReturnsBadRequestWhenUpdateFails()
        {
            // Arrange
            var mockService = new Mock<IManagerService>();
            var manager = new Manager { Id = 1 };
            mockService.Setup(service => service.UpdateAsync(1, manager)).ReturnsAsync((Manager)null);
            var controller = new ManagersController(mockService.Object);

            // Act
            var result = await controller.Put(1, manager);

            // Assert
            Assert.IsType<BadRequestResult>(result);
        }

        [Fact]
        public async Task PostReturnsCreatedAtActionWhenManagerIsAdded()
        {
            // Arrange
            var mockService = new Mock<IManagerService>();
            var manager = new Manager();
            mockService.Setup(service => service.AddAsync(manager)).ReturnsAsync(1);
            var controller = new ManagersController(mockService.Object);

            // Act
            var result = await controller.Post(manager);

            // Assert
            var createdResult = Assert.IsType<CreatedAtActionResult>(result.Result);
            Assert.Equal(1, createdResult.RouteValues["id"]);
        }

        [Fact]
        public async Task PostReturnsBadRequestWhenManagerCannotBeAdded()
        {
            // Arrange
            var mockService = new Mock<IManagerService>();
            var manager = new Manager();
            mockService.Setup(service => service.AddAsync(manager)).ReturnsAsync(0);
            var controller = new ManagersController(mockService.Object);

            // Act
            var result = await controller.Post(manager);

            // Assert
            Assert.IsType<BadRequestResult>(result.Result);
        }

        [Fact]
        public async Task GetTeachersByParametersReturnsOkWhenTeachersExist()
        {
            // Arrange
            var mockService = new Mock<IManagerService>();
            var teachers = new List<TeacherDetailsDTO> { new TeacherDetailsDTO() };
            mockService.Setup(service => service.GetTeachersByParametersAsync(1, null, null, null, null, null, null)).ReturnsAsync(teachers);
            var controller = new ManagersController(mockService.Object);

            // Act
            var result = await controller.GetTeachersByParameters(1);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnedTeachers = Assert.IsAssignableFrom<IEnumerable<TeacherDetailsDTO>>(okResult.Value);
            Assert.NotEmpty(returnedTeachers);
        }

        [Fact]
        public async Task GetTeachersByParametersReturnsNotFoundWhenNoTeachersExist()
        {
            // Arrange
            var mockService = new Mock<IManagerService>();
            mockService.Setup(service => service.GetTeachersByParametersAsync(1, null, null, null, null, null, null)).ReturnsAsync((IEnumerable<TeacherDetailsDTO>)null);
            var controller = new ManagersController(mockService.Object);

            // Act
            var result = await controller.GetTeachersByParameters(1);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }


    }
}
