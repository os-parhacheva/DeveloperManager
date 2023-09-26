using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Developer.Domain
{
    public enum LessonType 
    {
        TrainingModule =10,
        LaboratoryPracticalModule=20,
        LaboratoryWork=30,
        PracticalWork=40,
        Colloquium=50,
        CourseProject=60,
        CourseWork=70,
        ControlWork=80
    }
    public class Lesson
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
        public List<Agent> Agents { get; set; } = new List<Agent>();
        public List<ExerciseBlock> ExerciseBlocks { get; set; } = new List<ExerciseBlock>();


        public int GetBlocksCount() 
        {                     
            return ExerciseBlocks.Count;
        }
    }
}
