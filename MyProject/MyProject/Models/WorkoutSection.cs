using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyProject.Models
{
    public class WorkoutSection
    {
        // First part of the model - section in the Index
        [Key]
        public int WorkoutSectionId { get; set; }
        public string WorkoutSectionName { get; set; }

        // Second part of the model - exercises in a specific section
        public string ExerciseName { get; set; }
        public string ExerciseReps { get; set; }
        public int BreakTime { get; set; }

        // Implementation of List properties - test
        private List<string> _content = new List<string>();

        [NotMapped]
        public IEnumerable<string> Content
        {
            set { _content.Add(value.ToString()); }
            // it is a list - this is why there is strange field in the form
            get { return _content; }
        }

        public void AddContent(String argValue)
        {
            _content.Add(argValue);
        }

        public WorkoutSection()
        {
            this.AddContent("test_X");
        }
    }
}
