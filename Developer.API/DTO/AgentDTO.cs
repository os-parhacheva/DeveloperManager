namespace Developer.API
{
    public class AgentDTO
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public int RoleCode { get; set; } //1000-ведущий разработчик, 800- разработчик, 200-тьютер, 600-оператор 
        public Guid LessonId { get; set; }
    }
}
