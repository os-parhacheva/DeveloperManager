using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Developer.Domain
{
    public class Agent
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }        
        public int RoleCode { get; set; } //1000-ведущий разработчик, 800- разработчик, 200-тьютер, 600-оператор 
        public Guid LessonId { get; set; }
        public Lesson Lesson { get; set; } = new Lesson();

    }
}
