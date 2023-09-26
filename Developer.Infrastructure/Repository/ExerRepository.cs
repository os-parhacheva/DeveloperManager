using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Developer.Domain;

namespace Developer.Infrastructure
{
    public class ExerRepository
    {
        private readonly Context _context;
        public Context UnitOfWork
        {
            get
            {
                return _context;
            }
        }
        public ExerRepository(Context context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<List<Exercise>> GetAllAsync()
        {
            return await _context.Exercises.OrderBy(p => p.ExerciseNumber).Include(p => p.Options).Include(pa => pa.ExerciseVariants).ToListAsync();
        }
        public async Task<Exercise> GetByIdAsync(Guid id)
        {
            return await _context.Exercises.Include(p => p.Options).Include(pa => pa.ExerciseVariants).SingleOrDefaultAsync(i => i.Id == id);
        }
        public async Task AddAsync(Exercise exercise)
        {
            _context.Exercises.Add(exercise);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(Exercise exercise)
        {
            var existExer = await _context.Exercises.Include(p => p.Options).Include(p => p.ExerciseVariants).SingleOrDefaultAsync(i => i.Id == exercise.Id);
            if (existExer != null)
            {

                _context.Entry(existExer).CurrentValues.SetValues(exercise);
                _context.Entry(existExer.Content).CurrentValues.SetValues(exercise.Content);
                _context.Entry(existExer.Test).CurrentValues.SetValues(exercise.Test);


                foreach (var op in exercise.Options)
                {
                    var existOp = existExer.Options.FirstOrDefault(p => p.Id == op.Id);
                    if (existOp == null)
                    {
                        existExer.Options.Add(op);
                        _context.Entry(existExer).Reload();
                    }
                    else
                    {
                        _context.Entry(existOp).CurrentValues.SetValues(op);
                    }
                }
                foreach (var op in existExer.Options)
                {
                    if (!exercise.Options.Any(p => p.Id == op.Id))
                    {
                        _context.Remove(op);
                    }
                }

                foreach (var vr in exercise.ExerciseVariants)
                {
                    var existV = existExer.ExerciseVariants.FirstOrDefault(p => p.Id == vr.Id);
                    if (existV == null)
                    {
                        existExer.ExerciseVariants.Add(vr);
                        _context.Entry(existExer).Reload();
                    }
                    else
                    {
                        _context.Entry(existV).CurrentValues.SetValues(vr);
                        _context.Entry(existV.Content).CurrentValues.SetValues(vr.Content);
                    }
                }
                foreach (var vr in existExer.ExerciseVariants)
                {
                    if (!exercise.ExerciseVariants.Any(p => p.Id == vr.Id))
                    {
                        _context.Remove(vr);
                    }
                }
            }
            await _context.SaveChangesAsync();

        }

        public async Task DeleteAsync(Guid id)
        {
            Exercise exercise = await _context.Exercises.FindAsync(id);
            _context.Remove(exercise);
            await _context.SaveChangesAsync();
        }
    }
}
