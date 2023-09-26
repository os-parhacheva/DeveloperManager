using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Developer.Infrastructure;

namespace TestProject
{
    public class TestHelper
    {
        private readonly Context _context;
        public TestHelper()
        {
            var builder = new DbContextOptionsBuilder<Context>();
            builder.UseInMemoryDatabase(databaseName: "LibraryDbInMemory");

            var dbContextOptions = builder.Options;
            _context = new Context(dbContextOptions);
            // Delete existing db before creating a new one
            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();
        }

        public ExerRepository ExerRepository
        {
            get
            {
                return new ExerRepository(_context);
            }
        }

        public LesRepository LesRepository
        {
            get
            {
                return new LesRepository(_context);
            }
        }

        public TestRep testRep
        {
            get
            {
                return new TestRep(_context);
            }
        }
    }
}
