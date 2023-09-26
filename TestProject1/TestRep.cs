using Xunit;
using Developer.Domain;
using System;

namespace TestProject1
{
    public class TestRep
    {
        [Fact]
        public void TestAdd()
        {
            var testHelper = new TestHelper();
            var exerRepository = testHelper.ExerRepository;

        }
    }
}