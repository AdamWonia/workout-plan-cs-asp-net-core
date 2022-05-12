using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MyProject.Models
{
    public class StomachExercises
    {
        [Key]
        public int ExerciseId { get; set; }
        public string StomachParty { get; set; }
        public string ExerciseName { get; set; }
        public int Reps { get; set; }
        public int BreakTime { get; set; }
    }
}
