using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyProject.Models
{
    public class Workout
    {
        [Key]
        public int WorkoutId { get; set; }
        public DateTime Date { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Set> Sets { get; set; }
    }

    public class Set
    {
        public int Id { get; set; }
        public int ExerciseId { get; set; }
        public int WorkoutId { get; set; }
        public decimal Weight { get; set; }
        public int Reps { get; set; }

       // public virtual Exercise Exercise { get; set; }
       // public virtual Workout Workout { get; set; }
    }
}
