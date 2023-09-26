using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Developer.Domain;
using Microsoft.EntityFrameworkCore;

namespace Developer.Infrastructure
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options)
      : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Lesson>().OwnsOne(p => p.TheoryBlock);
            modelBuilder.Entity<Lesson>().OwnsOne(p => p.Subject);


            modelBuilder.Entity<Exercise>().OwnsOne(p => p.Content);
            modelBuilder.Entity<Exercise>().OwnsOne(p => p.Test);

            
            modelBuilder.Entity<ExerciseBlock>().OwnsOne(p => p.Content);

            modelBuilder.Entity<ExerciseVariant>().OwnsOne(p => p.Content);

            
        }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<Agent> Agents { get; set; }
        public DbSet<ExerciseBlock> ExerciseBlocks { get; set; }
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<ExerciseVariant> ExerciseVariants { get; set; }
        public DbSet<ExerciseOption> ExerciseOptions { get; set; }
    }

}
