using Microsoft.AspNetCore.Mvc;
using TutoringPlatformBackEnd.StudyMaterials.Services;
using TutoringPlatformBackEnd.StudyMaterials.Model;
using TutoringPlatformBackEnd.StudyMaterials.Actor;

namespace TutoringPlatformBackEnd.StudyMaterials.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudyMaterialController : ControllerBase
    {
        private readonly IStudyMaterialService _studyMaterialService;

        public StudyMaterialController(IStudyMaterialService studyMaterialService)
        {
            _studyMaterialService = studyMaterialService ?? throw new ArgumentNullException(nameof(studyMaterialService));
        }

        [HttpGet]
        public async Task<ActionResult<List<StudyMaterial>>> GetAllStudyMaterials()
        {
            var studyMaterials = await _studyMaterialService.GetAllStudyMaterialsAsync();
            return Ok(studyMaterials);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<StudyMaterial>> GetStudyMaterialById(string id)
        {
            var studyMaterial = await _studyMaterialService.GetStudyMaterialByIdAsync(id);
            if (studyMaterial == null)
            {
                return NotFound();
            }
            return Ok(studyMaterial);
        }

        [HttpGet("tutor/{tutorId}")]
        public async Task<ActionResult<List<StudyMaterial>>> GetStudyMaterialsByTutorId(string tutorId)
        {
            var studyMaterials = await _studyMaterialService.GetStudyMaterialsByTutorIdAsync(tutorId);
            return Ok(studyMaterials);
        }

        [HttpPost]
        public async Task<ActionResult<StudyMaterial>> CreateStudyMaterial([FromBody] StudyMaterial studyMaterial)
        {
            if (studyMaterial == null)
            {
                return BadRequest("Invalid request payload");
            }

            var createdStudyMaterial = await _studyMaterialService.CreateStudyMaterialAsync(studyMaterial);
            return CreatedAtAction(nameof(GetStudyMaterialById), new { id = createdStudyMaterial.Id }, createdStudyMaterial);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStudyMaterial(string id, StudyMaterial studyMaterial)
        {
            try
            {
                await _studyMaterialService.UpdateStudyMaterialAsync(id, studyMaterial);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while updating study material: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudyMaterial(string id)
        {
            try
            {
                await _studyMaterialService.DeleteStudyMaterialAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while deleting study material: {ex.Message}");
            }
        }
    }
}
