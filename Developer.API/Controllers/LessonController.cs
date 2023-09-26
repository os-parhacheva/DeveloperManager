using Microsoft.AspNetCore.Mvc;
using Developer.Domain;
using Developer.Infrastructure;


namespace Developer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LessonController : Controller
    {
        private readonly LesRepository _lesRepository;

        public LessonController(Context context)
        {
            _lesRepository = new LesRepository(context);
        }
        // GET: api/Lesson
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LessonDTO>>> GetLessons()
        {
            var lessons = await _lesRepository.GetAllAsync();
            List<LessonDTO> comDTOs = new List<LessonDTO>();
            foreach (var lesson in lessons)
            {
                comDTOs.Add(ToLessonDTO(lesson));
            }
            return comDTOs;
        }

        // GET api/Lesson/:id
        [HttpGet("{id}")]
        public async Task<ActionResult<LessonDTO>> GetLesson(Guid id)
        {
            var lesson = await _lesRepository.GetByIdAsync(id);

            if (lesson == null)
            {
                return NotFound();
            }
            return ToLessonDTO(lesson);
        }

        // POST api/Lesson
        [HttpPost]
        public async Task<ActionResult<Lesson>> PostLesson(Lesson lesson)
        {
            await _lesRepository.AddAsync(lesson);
            return Ok();
        }

        // PUT api/Lesson/:id
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLesson(Guid id, Lesson lesson)
        {
            var les = await _lesRepository.GetByIdAsync(id);
            if (id != lesson.Id || les == null)
            {
                return BadRequest();
            }
            await _lesRepository.UpdateAsync(lesson);
            return NoContent();
        }

        // DELETE api/Lesson/:id
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLesson(Guid id)
        {
            var lesson = await _lesRepository.GetByIdAsync(id);

            if (lesson == null)
            {
                return NotFound();
            }
            await _lesRepository.DeleteAsync(id);
            return NoContent();
        }

        private LessonDTO ToLessonDTO(Lesson lesson)
        {
            LessonDTO lessonDTO = new LessonDTO
            {
                Id = lesson.Id,
                Name = lesson.Name,
                LessonNumber = lesson.LessonNumber,
                Status = lesson.Status,
                LaborIntensity = lesson.LaborIntensity,
                LessonType = lesson.LessonType,
                Comments = lesson.Comments,
                TheoryBlock = lesson.TheoryBlock,
                Subject= lesson.Subject,
                ExerciseBlocks=ToExBlockDTOs(lesson.ExerciseBlocks),
                Agents= ToAgentDTO(lesson.Agents)                
            };
            return lessonDTO;
        }
        private List<AgentDTO> ToAgentDTO (List<Agent> agents)
        {
            List<AgentDTO> agentDTOs = new List<AgentDTO>();
            foreach (Agent ag in agents)
            {
                AgentDTO agentDTO = new AgentDTO
                {
                    Id = ag.Id,
                    UserId = ag.UserId,
                    LessonId = ag.LessonId,
                    RoleCode = ag.RoleCode
                };
                agentDTOs.Add(agentDTO);
            }
            return agentDTOs;
        }
        private List<ExerciseBlockDTO> ToExBlockDTOs(List<ExerciseBlock> blocks)
        {
            List<ExerciseBlockDTO> exBlDTOs = new List<ExerciseBlockDTO>();
            foreach (var bl in blocks)
            {
                ExerciseBlockDTO blDTO = new ExerciseBlockDTO
                {
                    Id = bl.Id,
                    SubType = bl.SubType,
                    Comments= bl.Comments,
                    Content = bl.Content,
                    LessonId= bl.LessonId,
                    Exercises=ToExDTO(bl.Exercises)                    
                };
                exBlDTOs.Add(blDTO);
            }
            return exBlDTOs;
        }
        private List<ExerciseDTO> ToExDTO(List<Exercise> exercises)
        {
            List<ExerciseDTO> exDTOs = new List<ExerciseDTO>();
            foreach (var ex in exercises)
            {
                ExerciseDTO exDTO = new ExerciseDTO
                {
                    Id = ex.Id,
                    ExerciseNumber = ex.ExerciseNumber,
                    DifficultyCoefficient = ex.DifficultyCoefficient,
                    Type=ex.Type,
                    Content = ex.Content,
                    Test=ex.Test,
                    ExerciseBlockId=ex.ExerciseBlockId,
                    ExerciseVariants = ToVarDTO(ex.ExerciseVariants),
                    Options=ToOpDTO(ex.Options)                    
                };
                exDTOs.Add(exDTO);
            }
            return exDTOs;
        }
        private List<ExerciseVariantDTO> ToVarDTO(List<ExerciseVariant> variants)
        {
            List<ExerciseVariantDTO> vrDTOs = new List<ExerciseVariantDTO>();
            foreach (var vr in variants)
            {
                ExerciseVariantDTO vrDTO = new ExerciseVariantDTO
                {
                    Id = vr.Id,
                    VariantNumber = vr.VariantNumber,
                    DifficultyCoefficient= vr.DifficultyCoefficient,
                    Content = vr.Content,
                    ExerciseId=vr.ExerciseId                    
                };
                vrDTOs.Add(vrDTO);
            }
            return vrDTOs;
        }
        private List<ExerciseOptionDTO> ToOpDTO(List<ExerciseOption> options)
        {
            List<ExerciseOptionDTO> opDTOs = new List<ExerciseOptionDTO>();
            foreach (var op in options)
            {
                ExerciseOptionDTO opDTO = new ExerciseOptionDTO
                {
                    Id = op.Id,
                    OptionNumber = op.OptionNumber,
                    Type = op.Type,
                    Description = op.Description,
                    Format = op.Format,
                    ExerciseId = op.ExerciseId                    
                };
                opDTOs.Add(opDTO);
            }
            return opDTOs;
        }
    }
}
