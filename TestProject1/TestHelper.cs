using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Developer.Domain;
using Developer.Infrastructure;


namespace TestProject1
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
    }
}
