using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Developer.Domain
{   
    public class Exercise
    {
        public enum ExerciseType
        {
            Group = 10,         //групповое задание
            Test = 20,               //тест
            IndividualExercise = 30  //индивидуальное задание
        }
        public Guid Id { get; set; }
        public int ExerciseNumber { get; set; }
        public int DifficultyCoefficient { get; set; }
        public ExerciseType Type { get; set; }

        public ContentUrlVO Content { get; set; } = new ContentUrlVO();
        public TestRefVO? Test { get; set; } = new TestRefVO();

        public Guid ExerciseBlockId { get; set; }
        public ExerciseBlock ExerciseBlock { get; set; } = new ExerciseBlock();

        public List<ExerciseOption> Options { get; set; } = new List<ExerciseOption>();
        public List<ExerciseVariant> ExerciseVariants { get; set; } = new List<ExerciseVariant>();

        public int GetVariantsCount()
        {
            return ExerciseVariants.Count;
        }
    }
}
