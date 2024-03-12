using Microsoft.AspNetCore.Mvc;
using TutoringPlatformBackEnd.Models;
using TutoringPlatformBackEnd.Services;

namespace TutoringPlatformBackEnd.Controllers
{
    [ApiController]
    [Route("api")]
    public class StudyMaterialController :ControllerBase
    {
        private readonly IStudyMaterialService _materialService;

        public StudyMaterialController(IStudyMaterialService materialService)
        {
            _materialService = materialService;
        }

        [HttpGet("{id}")]
        public IActionResult GetStudyMaterialById(int id)
        {
            var studyMaterial = _materialService.GetStudyMaterialById(id);
            if (studyMaterial == null)
            {
                return NotFound();
            }
            return Ok(studyMaterial);
        }

        [HttpGet("all")]
        public IActionResult GetAllStudyMaterials()
        {
            var studyMaterials = _materialService.GetAllStudyMaterials();
            return Ok(studyMaterials);
        }

        [HttpPost]
        public IActionResult CreateStudyMaterial(StudyMaterial studyMaterial)
        {
            var createdMaterial = _materialService.CreateStudyMaterial(studyMaterial);
            return CreatedAtAction(nameof(GetStudyMaterialById), new { id = createdMaterial.Id }, createdMaterial);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateStudyMaterial(int id, StudyMaterial studyMaterial)
        {
            var updatedMaterial = _materialService.UpdateStudyMaterial(id, studyMaterial);
            if (updatedMaterial == null)
            {
                return NotFound();
            }
            return Ok(updatedMaterial);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteStudyMaterial(int id)
        {
            _materialService.DeleteStudyMaterial(id);
            return NoContent();
        }
    }
}
