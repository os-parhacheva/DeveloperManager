using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Developer.Domain
{
    public enum OptionType
    {
        FillForm = 10,
        LoadImg = 20,
        LoadVideo = 30,
        LoadFile = 40
    }
    public enum FormatType
    {
        Nothing = 10,
        InputForm = 20,
        OneFilePerOption = 30,
        MultipleFilesPerOption = 40
    }

    public class ExerciseOption
    {
        public Guid Id { get; set; }
        public int OptionNumber { get; set; }
        public OptionType Type { get; set; }
        public string Description { get; set; } = "";
        public FormatType Format { get; set; } //0-ничего, 1-форма ввода, 2-один файл, 3-один и больше

        public Guid ExerciseId { get; set; }
        public Exercise Exercise { get; set; } = new Exercise();
    }
}
