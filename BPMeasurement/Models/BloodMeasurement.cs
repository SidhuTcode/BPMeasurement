using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace BPMeasurement.Models
{
    public class BloodMeasurement
    {
        [Key]
        public int BPId { get; set; }

        [Required]
        [Range(20, 400, ErrorMessage = "Systolic Values must be positive and between 20 and 400")]
        public int Systolic { get; set; }

        [Required]
        [Range(10, 300, ErrorMessage = "Diastolic Values must be positive and between 10 and 300")]
        public int Diastolic { get; set; }

        [Required(ErrorMessage = "Please specify a date and time")]
        public DateTime? Date {  get; set; }


        [Required(ErrorMessage = "Please specify a position for the measurement")]
        public string PositionId { get; set; }

        [ValidateNever]
        public Position Position { get; set; }

        public string Category
        {
            get
            {
                int systolic = Systolic;
                int diastolic = Diastolic;

                if (systolic < 120 && diastolic < 80)
                {
                    return "Normal";
                }
                else if (systolic >= 120 && systolic <= 129 && diastolic < 80)
                {
                    return "Elevated";
                }
                else if ((systolic >= 130 && systolic <= 139) || (diastolic >= 80 && diastolic <= 89))
                {
                    return "Hypertension Stage 1";
                }
                else if ((systolic >= 140) || (diastolic >= 90))
                {
                    return "Hypertension Stage 2";
                }
                else
                {
                    return "Hypertensive Crisis";
                }
            }
        }
    }
}
