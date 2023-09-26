using Developer.Domain;

namespace Developer.API
{
    public class ExerciseVariantDTO
    {
        public Guid Id { get; set; }
        public int VariantNumber { get; set; }
        public int DifficultyCoefficient { get; set; }

        public ContentUrlVO Content { get; set; } = new ContentUrlVO();

        public Guid ExerciseId { get; set; }
    }
}
