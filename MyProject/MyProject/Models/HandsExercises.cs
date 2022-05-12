using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MyProject.Models
{
    public class HandsExercises
    {
        [Key]
        public int ExerciseId { get; set; }
        public string HandParty { get; set; }
        public string ExerciseName { get; set; }
        public int Reps { get; set; }
        public int BreakTime { get; set; }
    }
}
