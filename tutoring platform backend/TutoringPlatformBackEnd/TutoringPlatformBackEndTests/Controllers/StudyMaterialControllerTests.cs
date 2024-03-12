using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NUnit.Framework;
using TutoringPlatformBackEnd.Models;
using TutoringPlatformBackEnd.Services;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace TutoringPlatformBackEnd.Controllers.Tests
{
    [TestClass()]
    public class StudyMaterialControllerTests
    {
        private Mock<IStudyMaterialService> _mockStudyMaterialService;
        private StudyMaterialController _studyMaterialController;
        
        [SetUp]
        public void Setup()
        {
            _mockStudyMaterialService = new Mock<IStudyMaterialService>();
            _studyMaterialController = new StudyMaterialController(_mockStudyMaterialService.Object);
        }

        [TestMethod()]
        public void GetStudyMaterialById_ValidId_ReturnsMaterial()
        {
            // Arrange
            var expectedMaterial = new StudyMaterial { Id = 1, Title = "Material 1", EducationLevel = "High School", Tags = new List<string> { "Math", "Algebra" }, Content = "path/to/file1.pdf" };
            _mockStudyMaterialService.Setup(service => service.GetStudyMaterialById(1)).Returns(expectedMaterial);

            // Act
            var result = _studyMaterialController.GetStudyMaterialById(1);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(expectedMaterial, result);
        }

        [TestMethod()]
        public void GetAllMaterials_ReturnsAllMaterials()
        {
            // Arrange
            var expectedMaterials = new List<StudyMaterial>
            {
                new StudyMaterial { Id = 1, Title = "Material 1", EducationLevel = "High School", Tags = new List<string> { "Math", "Algebra" }, Content = "path/to/file1.pdf" },
                new StudyMaterial { Id = 2, Title = "Material 2", EducationLevel = "College", Tags = new List<string> { "Physics", "Mechanics" }, Content = "path/to/file2.pdf" }
            };
            _mockStudyMaterialService.Setup(service => service.GetAllStudyMaterials()).Returns(expectedMaterials);

            // Act
            var result = _studyMaterialController.GetAllStudyMaterials();

            // Assert
            NUnit.Framework.Assert.That(result, Is.Not.Null);
            Assert.Equals(expectedMaterials, result);
        }

        [TestMethod()]
        public void CreateMaterial_ValidMaterial_ReturnsCreatedMaterial()
        {
            // Arrange
            var newMaterial = new StudyMaterial { Title = "New Material", EducationLevel = "High School", Tags = new List<string> { "Biology" }, Content = "path/to/new_file.pdf" };
            _mockStudyMaterialService.Setup(service => service.CreateStudyMaterial(newMaterial)).Returns(newMaterial);

            // Act
            var result = _studyMaterialController.CreateStudyMaterial(newMaterial);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(newMaterial, result);
        }

        [TestMethod()]
        public void UpdateMaterial_ValidIdAndMaterial_ReturnsUpdatedMaterial()
        {
            // Arrange
            int materialId = 1;
            var updatedMaterial = new StudyMaterial { Id = materialId, Title = "Updated Material", EducationLevel = "High School", Tags = new List<string> { "Math", "Algebra" }, Content = "path/to/updated_file.pdf" };
            _mockStudyMaterialService.Setup(service => service.UpdateStudyMaterial(materialId, updatedMaterial)).Returns(updatedMaterial);

            // Act
            var result = _studyMaterialController.UpdateStudyMaterial(materialId, updatedMaterial);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(updatedMaterial, result);
        }

        [TestMethod()]
        public void DeleteMaterial_ValidId_DeletesMaterial()
        {
            // Arrange
            int materialId = 1;

            // Act
            _studyMaterialController.DeleteStudyMaterial(materialId);

            // Assert
            _mockStudyMaterialService.Verify(service => service.DeleteStudyMaterial(materialId), Moq.Times.Once);
        }
    }
}
