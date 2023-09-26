using System;
using Xunit;
using Developer.Domain;

namespace TestProject
{
    public class UnitTest1
    {
        [Fact]
        public void TestAdd()
        {
            var testHelper = new TestHelper();
            var exerRepository = testHelper.ExerRepository;

            Exercise exercise = new Exercise
            {
                Id = Guid.NewGuid(),
                ExerciseNumber = 1
            };

            exercise.Options.Add(new ExerciseOption { Id = Guid.NewGuid(), OptionNumber = 1 });
            exercise.Options.Add(new ExerciseOption { Id = Guid.NewGuid(), OptionNumber = 2 });
            exercise.Options.Add(new ExerciseOption { Id = Guid.NewGuid(), OptionNumber = 3 });

            exercise.ExerciseVariants.Add(new ExerciseVariant { Id = Guid.NewGuid(), VariantNumber = 1 });
            exercise.ExerciseVariants.Add(new ExerciseVariant { Id = Guid.NewGuid(), VariantNumber = 2 });
            exercise.ExerciseVariants.Add(new ExerciseVariant { Id = Guid.NewGuid(), VariantNumber = 3 });

            exerRepository.AddAsync(exercise).Wait();

            Assert.Equal(1, exerRepository.GetByIdAsync(exercise.Id).Result.ExerciseNumber);
            Assert.Equal(3, exerRepository.GetByIdAsync(exercise.Id).Result.Options.Count);

        }

        [Fact]
        public void TestUpdate()
        {
            var testHelper = new TestHelper();
            var exerRepository = testHelper.ExerRepository;

            Exercise exercise = new Exercise
            {
                Id = Guid.NewGuid(),
                ExerciseNumber = 1
            };

            exercise.Options.Add(new ExerciseOption { Id = Guid.NewGuid(), OptionNumber = 1 });
            exercise.Options.Add(new ExerciseOption { Id = Guid.NewGuid(), OptionNumber = 2 });
            exerRepository.AddAsync(exercise).Wait();
            Assert.Equal(2, exerRepository.GetByIdAsync(exercise.Id).Result.Options.Count);


            var exerciseNew = exerRepository.GetByIdAsync(exercise.Id).Result;
            exerciseNew.Options.Add(new ExerciseOption { OptionNumber = 3 });
            exerciseNew.Options.Add(new ExerciseOption { OptionNumber = 4 });
            exerciseNew.Options.Add(new ExerciseOption { OptionNumber = 5 });
            exerRepository.UpdateAsync(exerciseNew).Wait();

            Assert.Equal(5, exerRepository.GetByIdAsync(exerciseNew.Id).Result.Options.Count);
            Assert.Equal(4, exerRepository.GetByIdAsync(exerciseNew.Id).Result.Options[3].OptionNumber);

            exerciseNew.Options.RemoveAt(0);
            exerRepository.UpdateAsync(exerciseNew).Wait();
            Assert.Equal(4, exerRepository.GetByIdAsync(exercise.Id).Result.Options.Count);
            Assert.Equal(2, exerRepository.GetByIdAsync(exercise.Id).Result.Options[0].OptionNumber);
        }


        [Fact]
        public void TestUpLes()
        {
            var testHelper = new TestHelper();
            var lesRepository = testHelper.LesRepository;


            Lesson lesson = new Lesson
            {
                Id = Guid.NewGuid(),
                LessonNumber = 1
            };

          //  lesson.ExerciseBlocks.Add(new ExerciseBlock { SubType = SubType.ControlExercise });
          //  lesson.ExerciseBlocks.Add(new ExerciseBlock { SubType = SubType.Allowance });


            lesRepository.AddAsync(lesson).Wait();

            lesson.ExerciseBlocks[0].Exercises.Add(new Exercise { ExerciseNumber = 3 });
            lesson.ExerciseBlocks[0].Exercises.Add(new Exercise { ExerciseNumber = 1 });
            lesson.ExerciseBlocks[1].Exercises.Add(new Exercise { ExerciseNumber = 1 });

            lesRepository.UpdateAsync(lesson).Wait();

            Assert.Equal(2, lesRepository.GetByIdAsync(lesson.Id).Result.ExerciseBlocks[0].Exercises.Count);
            Assert.Equal(1, lesRepository.GetByIdAsync(lesson.Id).Result.ExerciseBlocks[1].Exercises.Count);


            var lessonNew = lesRepository.GetByIdAsync(lesson.Id).Result;
         //   lessonNew.ExerciseBlocks[0].SubType = SubType.Allowance;
            lesRepository.UpdateAsync(lessonNew).Wait();

         //   Assert.Equal(SubType.Allowance, lesRepository.GetByIdAsync(lessonNew.Id).Result.ExerciseBlocks[0].SubType);

            lessonNew.ExerciseBlocks[0].Exercises[0].ExerciseNumber = 3012;
            Assert.Equal(3012, lesRepository.GetByIdAsync(lesson.Id).Result.ExerciseBlocks[0].Exercises[0].ExerciseNumber);



            lessonNew.Agents.Add(new Agent { RoleCode = 300 });
            lessonNew.Agents.Add(new Agent { RoleCode = 500 });
            lessonNew.Agents.Add(new Agent { RoleCode = 1000 });
            lesRepository.UpdateAsync(lessonNew).Wait();
            Assert.Equal(3, lesRepository.GetByIdAsync(lessonNew.Id).Result.Agents.Count);

            lessonNew.Agents.RemoveAt(0);
            lessonNew.Agents.RemoveAt(1);
            Assert.Equal(500, lesRepository.GetByIdAsync(lessonNew.Id).Result.Agents[0].RoleCode);


        }



    }
}