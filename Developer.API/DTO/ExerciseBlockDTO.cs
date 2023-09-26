using Developer.Domain;

namespace Developer.API
{
    public class ExerciseBlockDTO
    {
        public Guid Id { get; set; }
        public SubType SubType { get; set; }
      //  public ExerciseType ExerciseType { get; set; }
        public string Comments { get; set; } = "";

        public ContentUrlVO Content { get; set; } = new ContentUrlVO();

        public Guid LessonId { get; set; }
        public List<ExerciseDTO> Exercises { get; set; } = new List<ExerciseDTO>();
    }
}
