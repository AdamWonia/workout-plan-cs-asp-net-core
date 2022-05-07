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
        [Display(Name = "List of exercises")]
        public string ExerciseName { get; set; }
        public string ExerciseReps { get; set; }
        public int BreakTime { get; set; }



        // Implementation of List properties - test
        private List<string> _content = new List<string>();

        [NotMapped]
        [Display(Name = "Add Exercise into the Section")]
        public IEnumerable<string> Content
        {
            // it is a list - this is why there is strange field in the form
            get { return _content; }
        }

        public void AddContent(string Content_input)
        {
            _content.Add(Content_input);
        }

        public WorkoutSection()
        {
            this.AddContent("test_X");
            this.AddContent("test_Y");
            this.AddContent("test_Z");
        }
    }
}
