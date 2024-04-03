﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using TutoringPlatformBackEnd.StudyMaterials.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TutoringPlatformBackEnd.StudyMaterials.Model;
using TutoringPlatformBackEnd.StudyMaterials.Services;
using Moq;
using MongoDB.Bson;

namespace TutoringPlatformBackEnd.StudyMaterials.Controllers.Tests
{
    [TestClass()]
    public class StudyMaterialControllerTests
    {
        [TestMethod]
        public async Task GetAllStudyMaterials_ReturnsOkResultWithStudyMaterials()
        {
            // Arrange
            var mockService = new Mock<IStudyMaterialService>();
            mockService.Setup(service => service.GetAllStudyMaterialsAsync())
                       .ReturnsAsync(new List<StudyMaterial>());

            var controller = new StudyMaterialController(mockService.Object);

            // Act
            var result = await controller.GetAllStudyMaterials();

            // Assert
            Assert.IsInstanceOfType(result.Result, typeof(OkObjectResult));
            Assert.IsNotNull((result.Result as OkObjectResult)?.Value);
            CollectionAssert.AreEqual(new List<StudyMaterial>(), (result.Result as OkObjectResult)?.Value as List<StudyMaterial>);
        }

        [TestMethod]
        public async Task GetStudyMaterialById_ExistingId_ReturnsOkResultWithStudyMaterial()
        {
            // Arrange
            var mockService = new Mock<IStudyMaterialService>();
            var expectedStudyMaterial = new StudyMaterial { Id = ObjectId.GenerateNewId(), Title = "test Material" };

            mockService.Setup(service => service.GetStudyMaterialByIdAsync("1"))
                       .ReturnsAsync(expectedStudyMaterial);

            var controller = new StudyMaterialController(mockService.Object);

            // Act
            var result = await controller.GetStudyMaterialById("1");

            // Assert
            Assert.IsInstanceOfType(result.Result, typeof(OkObjectResult));
            Assert.AreEqual(expectedStudyMaterial, (result.Result as OkObjectResult)?.Value);
        }

        [TestMethod]
        public async Task GetStudyMaterialById_NonExistingId_ReturnsNotFoundResult()
        {
            // Arrange
            var mockService = new Mock<IStudyMaterialService>();
            mockService.Setup(service => service.GetStudyMaterialByIdAsync("100"))
                       .ReturnsAsync((StudyMaterial)null);

            var controller = new StudyMaterialController(mockService.Object);

            // Act
            var result = await controller.GetStudyMaterialById("100");

            // Assert
            Assert.IsInstanceOfType(result.Result, typeof(NotFoundResult));
        }

        [TestMethod]
        public async Task GetStudyMaterialsByTutorId_ReturnsOkResultWithStudyMaterials()
        {
            // Arrange
            var mockService = new Mock<IStudyMaterialService>();
            mockService.Setup(service => service.GetStudyMaterialsByTutorIdAsync("tutorId"))
                       .ReturnsAsync(new List<StudyMaterial>());

            var controller = new StudyMaterialController(mockService.Object);

            // Act
            var result = await controller.GetStudyMaterialsByTutorId("tutorId");

            // Assert
            Assert.IsInstanceOfType(result.Result, typeof(OkObjectResult));
            Assert.IsNotNull((result.Result as OkObjectResult)?.Value);
            CollectionAssert.AreEqual(new List<StudyMaterial>(), (result.Result as OkObjectResult)?.Value as List<StudyMaterial>);
        }

        [TestMethod]
        public async Task CreateStudyMaterial_ValidInput_ReturnsCreatedAtActionResult()
        {
            // Arrange
            var mockService = new Mock<IStudyMaterialService>();
            var inputStudyMaterial = new StudyMaterial { Title = "Sample Material" };
            var expectedStudyMaterial = new StudyMaterial { Id = ObjectId.GenerateNewId(), Title = "test Material" };

            mockService.Setup(service => service.CreateStudyMaterialAsync(inputStudyMaterial))
                       .ReturnsAsync(expectedStudyMaterial);

            var controller = new StudyMaterialController(mockService.Object);

            // Act
            var result = await controller.CreateStudyMaterial(inputStudyMaterial);

            // Assert
            Assert.IsInstanceOfType(result.Result, typeof(CreatedAtActionResult));
            Assert.AreEqual(nameof(StudyMaterialController.GetStudyMaterialById), (result.Result as CreatedAtActionResult)?.ActionName);
        }

        [TestMethod]
        public async Task UpdateStudyMaterial_ValidInput_ReturnsNoContentResult()
        {
            // Arrange
            var mockService = new Mock<IStudyMaterialService>();
            var inputId = "1";
            var inputStudyMaterial = new StudyMaterial { Title = "Updated Material" };

            var controller = new StudyMaterialController(mockService.Object);

            // Act
            var result = await controller.UpdateStudyMaterial(inputId, inputStudyMaterial);

            // Assert
            Assert.IsInstanceOfType(result, typeof(NoContentResult));
        }

        [TestMethod]
        public async Task DeleteStudyMaterial_ValidId_ReturnsNoContentResult()
        {
            // Arrange
            var mockService = new Mock<IStudyMaterialService>();
            var inputId = "1";

            var controller = new StudyMaterialController(mockService.Object);

            // Act
            var result = await controller.DeleteStudyMaterial(inputId);

            // Assert
            Assert.IsInstanceOfType(result, typeof(NoContentResult));
        }
    }
}