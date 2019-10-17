using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Belt_Exam.Models
{
    public class LoginUser
    {
        // No other fields!
        public string Email { get; set; }
        public string Password { get; set; }
    }
}