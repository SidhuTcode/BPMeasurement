using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Security.AccessControl;

namespace BPMeasurement.Models
{
    public class BPContext : DbContext
    {
        public BPContext(DbContextOptions<BPContext> options) : base(options)
        {
        }

        public DbSet<BloodMeasurement> BPMeasurements { get; set; }
        public DbSet<Position> Positions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            
            modelBuilder.Entity<Position>().HasData(
                new Position { PositionId = "A", Name = "Standing" },
                new Position { PositionId = "T", Name = "Sitting" },
                new Position { PositionId = "L", Name = "Lying Down" }
            );
            DateTime customDate = new DateTime(2023, 09, 12);
            modelBuilder.Entity<BloodMeasurement>().HasData(
               new BloodMeasurement
               {
                   BPId = 1,
                   Systolic = 118,
                   Diastolic = 70,
                   PositionId = "A",
                   Date = customDate,
                 
               },
               new BloodMeasurement
               {
                   BPId = 2,
                   Systolic = 127,
                   Diastolic = 78,
                   PositionId="L",
                   Date = customDate,
                   
               },
               new BloodMeasurement
               {
                   BPId = 3,
                   Systolic = 137,
                   Diastolic = 85,
                   PositionId = "T",
                   Date = customDate,
                   
               },
               new BloodMeasurement
               {
                   BPId = 4,
                   Systolic = 150,
                   Diastolic = 90,
                   PositionId = "T",
                   Date = customDate,

               },
               new BloodMeasurement
               {
                   BPId = 5,
                   Systolic = 190,
                   Diastolic = 130,
                   PositionId = "T",
                   Date = customDate,

               }
           );
    }   }
}
