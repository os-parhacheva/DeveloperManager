using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Developer.Domain
{
    public class ExerciseVariant
    {
        public Guid Id { get; set; }
        public int VariantNumber { get; set; }
        public int DifficultyCoefficient { get; set; }

        public ContentUrlVO Content { get; set; } = new ContentUrlVO();

        public Guid ExerciseId { get; set; }
        public Exercise Exercise { get; set; } = new Exercise();

    }
}
