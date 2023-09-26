using Developer.Domain;

namespace Developer.API
{
    public class LessonDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = "";
        public int LessonNumber { get; set; }
        public string Status { get; set; } = "";                            //статус 
        public int LaborIntensity { get; set; }                             //трудоемкость
        public LessonType LessonType { get; set; }                          // тип занятия
        public string Comments { get; set; } = "";


        public ContentUrlVO TheoryBlock { get; set; } = new ContentUrlVO();     //теория     
        public SubjectVO Subject { get; set; } = new SubjectVO();               //дисциплина

        public List<ExerciseBlockDTO> ExerciseBlocks { get; set; } = new List<ExerciseBlockDTO>();
        public List<AgentDTO> Agents { get; set; } = new List<AgentDTO>();

    }
}
