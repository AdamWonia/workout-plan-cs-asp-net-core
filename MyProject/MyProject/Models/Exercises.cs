using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyProject.Models
{
    public class Exercises
    {
        public int ExerciseId { get; set; }
        public string ExerciseName { get; set; }
        public string ExerciseReps { get; set; }
        public int BreakTime { get; set; }

        public Exercises()
        {

        }
    }
}
