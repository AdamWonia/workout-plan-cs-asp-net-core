using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyProject.Models;

namespace MyProject.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<MyProject.Models.BackExercises> BackExercises { get; set; }
        public DbSet<MyProject.Models.ChestExercises> ChestExercises { get; set; }
        public DbSet<MyProject.Models.HandsExercises> HandsExercises { get; set; }
        public DbSet<MyProject.Models.LegsExercises> LegsExercises { get; set; }
        public DbSet<MyProject.Models.StomachExercises> StomachExercises { get; set; }
    }
}
