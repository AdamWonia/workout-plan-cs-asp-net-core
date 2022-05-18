using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MyProject.Models
{
    public class BackExercises
    {
        [Key]
        public int ExerciseId { get; set; }

        [Display(Name = "Part of Back")]
        public string BackPart { get; set; }

        [Display(Name = "Exercise Name")]
        public string ExerciseName { get; set; }

        [Display(Name = "Number of Repeats")]
        public int Reps { get; set; }

        [Display(Name = "Break time [min]")]
        public int BreakTime { get; set; }

        public BackExercises()
        {

        }
    }
}
