﻿using System;
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

        [Display(Name = "Part of Stomach")]
        public string StomachPart { get; set; }

        [Display(Name = "Exercise Name")]
        public string ExerciseName { get; set; }

        [Display(Name = "Number of Repeats")]
        public int Reps { get; set; }

        [Display(Name = "Break Time [min]")]
        public int BreakTime { get; set; }

        public StomachExercises()
        {

        }
    }
}
