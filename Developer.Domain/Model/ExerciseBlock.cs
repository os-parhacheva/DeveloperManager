using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Developer.Domain
{
    public enum SubType
    {
        Allowance = 10,  //задание на допуск     
        ControlExercise = 20, //задание на закрепление материала
        ProtectionExercise = 30, //задание на защиту
        Experiment=40
    }
    public class ExerciseBlock
    {
        public Guid Id { get; set; }
        public SubType SubType { get; set; } 
        public string Comments { get; set; } = "";        

        public Guid LessonId { get; set; }
        public Lesson Lesson { get; set; }=new Lesson();
        public List<Exercise> Exercises { get; set; } = new List<Exercise>();
        public ContentUrlVO Content { get; set; } = new ContentUrlVO();

        public int GetExercisesCount()
        {
            return Exercises.Count;
        }
    }
}
