using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Belt_Exam.Models
{

    public class Activitys
    {

        [Key]
        public int ActivityId { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        [DataType(DataType.Time)]
        public string Time { get; set; }

        [Required]
        // [FutureDate]
        [DataType(DataType.Date)]
        public string Date { get; set; }

        [Required]
        [Range(1, 100000)]
        public int Duration { get; set; }

        [Required]
        public string DurationType { get; set; }
        [Required]
        public string Desc { get; set; }

        public List<Association> Assoc_Activity { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
    }

    // public class FutureDateAttribute : ValidationAttribute
    // {
    //     protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    //     {
    //         // You first may want to unbox "value" here and cast to to a DateTime variable!
    //         if ((DateTime)value < DateTime.Now)
    //         {
    //             return new ValidationResult("Invalid: Future Date");
    //         }
    //         return ValidationResult.Success;
    //     }
    // }
}