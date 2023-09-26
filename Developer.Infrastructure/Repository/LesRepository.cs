using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Developer.Domain;

namespace Developer.Infrastructure
{
    public class LesRepository
    {
        private readonly Context _context;
        public Context UnitOfWork
        {
            get
            {
                return _context;
            }
        }
        public LesRepository(Context context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task<List<Lesson>> GetAllAsync()
        {
            return await _context.Lessons.OrderBy(p => p.LessonNumber).Include(p => p.ExerciseBlocks).ThenInclude(p => p.Exercises)
                .Include(p=>p.Agents).ToListAsync();
        }
        public async Task<Lesson> GetByIdAsync(Guid id)
        {
            return await _context.Lessons.Include(p => p.ExerciseBlocks).ThenInclude(p => p.Exercises).ThenInclude(q=>q.Options)
                                            .Include(p => p.ExerciseBlocks).ThenInclude(p => p.Exercises).ThenInclude(q => q.ExerciseVariants)
                                               .Include(p => p.Agents).SingleOrDefaultAsync(i => i.Id == id);        
        }
        public async Task AddAsync(Lesson lesson)
        {
            _context.Lessons.Add(lesson);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(Lesson lesson)
        {
            var repEx = new ExerRepository(_context);
            var existLes = await _context.Lessons.Include(p => p.ExerciseBlocks).ThenInclude(p => p.Exercises).SingleOrDefaultAsync(i => i.Id == lesson.Id);
            _context.Entry(existLes).CurrentValues.SetValues(lesson);
            _context.Entry(existLes.Subject).CurrentValues.SetValues(lesson.Subject);
            _context.Entry(existLes.TheoryBlock).CurrentValues.SetValues(lesson.TheoryBlock);

            foreach (var bl in lesson.ExerciseBlocks)
            {
                var existBl = existLes.ExerciseBlocks.FirstOrDefault(p => p.Id == bl.Id);
                if (existBl == null)
                {
                    existLes.ExerciseBlocks.Add(bl);
                    _context.Entry(existLes).Reload();
                }
                else
                {
                    _context.Entry(existBl).CurrentValues.SetValues(bl);
                    _context.Entry(existBl.Content).CurrentValues.SetValues(bl.Content);

                    foreach (var ex in bl.Exercises)
                    {
                        var existEx = existBl.Exercises.FirstOrDefault(s => s.Id == ex.Id);

                        if (existEx == null)
                        {
                            existBl.Exercises.Add(ex);
                            _context.Entry(existBl).Reload();
                        }
                        else
                        {
                          repEx.UpdateAsync(ex).Wait();
                            //_context.Entry(existEx).CurrentValues.SetValues(ex);
                        }                      

                    }
                    foreach (var ex in existBl.Exercises)
                    {
                        if (!bl.Exercises.Any(p => p.Id == ex.Id))
                        {
                            _context.Remove(ex);
                        }
                    }
                }
            }
            foreach (var bl in existLes.ExerciseBlocks)
            {
                if (!lesson.ExerciseBlocks.Any(p => p.Id == bl.Id))
                {
                    _context.Remove(bl);
                }
            }
            foreach (var ag in lesson.Agents)
            {
                var existAg = existLes.Agents.FirstOrDefault(p => p.Id == ag.Id);
                if (existAg == null)
                {
                    existLes.Agents.Add(ag);
                    _context.Entry(existLes).Reload();
                }
                else
                {
                    _context.Entry(existAg).CurrentValues.SetValues(ag);
                }
            }
            foreach (var ag in existLes.Agents)
            {
                if (!lesson.Agents.Any(p => p.Id == ag.Id))
                {
                    _context.Remove(ag);
                }
            }
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(Guid id)
        {
            Lesson lesson = await _context.Lessons.FindAsync(id);
            _context.Remove(lesson);
            await _context.SaveChangesAsync();
        }        
    }
}
