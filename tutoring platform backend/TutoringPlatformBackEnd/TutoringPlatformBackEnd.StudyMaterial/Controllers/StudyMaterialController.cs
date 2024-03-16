using Microsoft.AspNetCore.Mvc;
using TutoringPlatformBackEnd.StudyMaterials.Services;
using TutoringPlatformBackEnd.StudyMaterials.Model;

namespace TutoringPlatformBackEnd.StudyMaterials.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudyMaterialController : ControllerBase
    {
        private readonly IStudyMaterialService _studyMaterialService;

        public StudyMaterialController(IStudyMaterialService studyMaterialService)
        {
            _studyMaterialService = studyMaterialService;
        }

        [HttpGet]
        public async Task<ActionResult<List<StudyMaterial>>> GetAllStudyMaterialsAsync()
        {
            var studyMaterials = await _studyMaterialService.GetAllStudyMaterialsAsync();
            return Ok(studyMaterials);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<StudyMaterial>> GetStudyMaterialByIdAsync(int id)
        {
            var studyMaterial = await _studyMaterialService.GetStudyMaterialByIdAsync(id);
            if (studyMaterial == null)
            {
                return NotFound();
            }
            return studyMaterial;
        }

        [HttpPost]
        public async Task<IActionResult> CreateStudyMaterialAsync(StudyMaterial studyMaterial)
        {
            await _studyMaterialService.CreateStudyMaterialAsync(studyMaterial);
            return CreatedAtAction(nameof(GetStudyMaterialByIdAsync), new { id = studyMaterial.Id }, studyMaterial);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStudyMaterialAsync(int id, StudyMaterial studyMaterial)
        {
            if (id != studyMaterial.Id)
            {
                return BadRequest();
            }

            await _studyMaterialService.UpdateStudyMaterialAsync(studyMaterial);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudyMaterialAsync(int id)
        {
            await _studyMaterialService.DeleteStudyMaterialAsync(id);
            return NoContent();
        }
    }
}
