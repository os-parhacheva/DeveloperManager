using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Developer.Domain
{
    public class SubjectVO
    {
        public Guid Id { get; set; }
        public string FullName { get; set; } = "";
        public string ShortName { get; set; } = "";

    }
}
