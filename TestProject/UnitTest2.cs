using Developer.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace TestProject
{
    public class UnitTest2
    {
      /*  [Fact]
        public void TestAdd()
        {
            var testHelper = new TestHelper();
            var lesRepository = testHelper.LesRepository;
            var exRep = testHelper.ExerRepository;

            Lesson lesson = new Lesson
            {
                Id = Guid.NewGuid(),
                Name="TheFirstLesson",
                LessonNumber=1
            };

            lesson.ExerciseBlocks.Add(new ExerciseBlock {  Comments = "1" });
          //  lesson.ExerciseBlocks.Add(new ExerciseBlock {  Comments = "2" });
          //  lesson.ExerciseBlocks.Add(new ExerciseBlock {  Comments = "3" });

            lesson.ExerciseBlocks[0].Exercises.Add(new Exercise { ExerciseNumber = 1 });
            lesson.ExerciseBlocks[0].Exercises.Add(new Exercise { ExerciseNumber = 2 });
            lesson.ExerciseBlocks[0].Exercises[0].Options.Add(new ExerciseOption { OptionNumber = 1 });
            lesson.ExerciseBlocks[0].Exercises[0].ExerciseVariants.Add(new ExerciseVariant { VariantNumber = 5 });

            lesRepository.AddAsync(lesson).Wait();
            // Assert.Equal(1, lesRepository.GetByIdAsync(lesson.Id).Result.ExerciseBlocks[0].Exercises[0].Options[0].OptionNumber);
            Guid VarId= lesson.ExerciseBlocks[0].Exercises[0].ExerciseVariants[0].Id;

             Assert.Equal(5, lesRepository.GetByIdAsync(lesson.Id).Result.ExerciseBlocks[0].Exercises[0].ExerciseVariants[0].VariantNumber);

            //  Assert.Equal(2, exRep.GetAllAsync().Result.Count);
            //  Assert.Equal(1, lesRepository.GetByIdAsync(lesson.Id).Result.LessonNumber);
            //  Assert.Equal(3, lesRepository.GetByIdAsync(lesson.Id).Result.ExerciseBlocks.Count);
            //  Assert.Equal(3, lesRepository.GetByIdAsync(lesson.Id).Result.GetBlocksCount());


            //  lesson.ExerciseBlocks.Add(new ExerciseBlock { Comments = "4" });
            //  lesson.ExerciseBlocks[0].Exercises.Add(new Exercise {  ExerciseNumber = 0 });
            //  lesson.ExerciseBlocks[0].Exercises[0].ExerciseNumber = 11;


            //lesson.ExerciseBlocks[0].Exercises[0].Options[0].OptionNumber = 11;
            lesson.ExerciseBlocks[0].Exercises[0].ExerciseVariants[0].VariantNumber = 55;
            lesRepository.UpdateAsync(lesson).Wait();

           // Assert.Equal(11, lesRepository.GetByIdAsync(lesson.Id).Result.ExerciseBlocks[0].Exercises[0].Options[0].OptionNumber);
            Assert.Equal(VarId, lesRepository.GetByIdAsync(lesson.Id).Result.ExerciseBlocks[0].Exercises[0].ExerciseVariants[0].Id);
            Assert.Equal(1, lesRepository.GetByIdAsync(lesson.Id).Result.ExerciseBlocks[0].Exercises[0].ExerciseVariants.Count);

            // Assert.Equal(3, exRep.GetAllAsync().Result.Count);
            //  Assert.Equal(11, lesRepository.GetByIdAsync(lesson.Id).Result.ExerciseBlocks[0].Exercises[0].ExerciseNumber);
            // Assert.Equal(4, lesRepository.GetByIdAsync(lesson.Id).Result.ExerciseBlocks.Count);






            lesRepository.DeleteAsync(lesson.Id).Wait();
            Assert.Equal(0,exRep.GetAllAsync().Result.Count );

        }*/

        [Fact]
        public void TestRepTest()
        {
            var testHelper = new TestHelper();
            var testRep = testHelper.testRep;

            Lesson lesson = new Lesson
            {
                Id = Guid.NewGuid(),
                Name = "Lesson",
                LessonNumber = 1
            };

            lesson.ExerciseBlocks.Add(new ExerciseBlock { Comments = "1" });
            lesson.ExerciseBlocks.Add(new ExerciseBlock { Comments = "2" });
            lesson.ExerciseBlocks[0].Exercises.Add(new Exercise { ExerciseNumber = 1 });
            lesson.ExerciseBlocks[0].Exercises.Add(new Exercise { ExerciseNumber = 2 });
            lesson.ExerciseBlocks[0].Exercises.Add(new Exercise { ExerciseNumber = 3 });

            testRep.AddAsync(lesson).Wait();
            Assert.Equal(2, testRep.GetByIdAsync(lesson.Id).Result.ExerciseBlocks.Count);
            Assert.Equal(3, testRep.GetByIdAsync(lesson.Id).Result.ExerciseBlocks[0].Exercises.Count);

            lesson.ExerciseBlocks.Add(new ExerciseBlock { Comments = "3" });
            lesson.ExerciseBlocks[0].Exercises.Add(new Exercise { ExerciseNumber = 0 });
            lesson.ExerciseBlocks[0].Exercises[0].ExerciseNumber = 11;

            testRep.UpdateAsync(lesson).Wait();
            Assert.Equal(3, testRep.GetByIdAsync(lesson.Id).Result.ExerciseBlocks.Count);
            Assert.Equal(4, testRep.GetByIdAsync(lesson.Id).Result.ExerciseBlocks[0].Exercises.Count);
            Assert.Equal(11, testRep.GetByIdAsync(lesson.Id).Result.ExerciseBlocks[0].Exercises[0].ExerciseNumber);


        }


    }
}
