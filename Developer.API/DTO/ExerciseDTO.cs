using Developer.Domain;
using static Developer.Domain.Exercise;

namespace Developer.API
{
    public class ExerciseDTO
    {
        public Guid Id { get; set; }
        public int ExerciseNumber { get; set; }
        public int DifficultyCoefficient { get; set; }
        public ExerciseType Type { get; set; }

        public ContentUrlVO Content { get; set; } = new ContentUrlVO();
        public TestRefVO? Test { get; set; }

        public Guid ExerciseBlockId { get; set; }

        public List<ExerciseOptionDTO> Options { get; set; } = new List<ExerciseOptionDTO>();
        public List<ExerciseVariantDTO> ExerciseVariants { get; set; } = new List<ExerciseVariantDTO>();
    }
}
