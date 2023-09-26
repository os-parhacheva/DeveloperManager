using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Developer.Domain
{
    //Value Object
    public class TestRefVO
    {
        public Guid TestId { get; set; }
        public string Name { get; set; } = "";
        public string ServiceUrl { get; set; } = "";

        public TestRefVO()
        {
            ServiceUrl = "";
        }

    }

}
