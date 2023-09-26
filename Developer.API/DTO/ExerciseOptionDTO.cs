using Developer.Domain;
namespace Developer.API
{
    public class ExerciseOptionDTO
    {
        public Guid Id { get; set; }
        public int OptionNumber { get; set; }
        public OptionType Type { get; set; }
        public string Description { get; set; } = "";
        public FormatType Format { get; set; }

        public Guid ExerciseId { get; set; }
    }
}
