using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Belt_Exam.Models
{
    public class ViewModel
    {
        // User Model
        public User NewUser { get; set; }
        public List<User> AllUsers { get; set; }

        public LoginUser LoginUser { get; set; }
        public List<LoginUser> AllLoginUser { get; set; }

        public Activitys NewActivity { get; set; }
        public List<Activitys> AllActivity { get; set; }

        public Association newAssoc { get; set; }
        public List<Association> AllAssociations { get; set; }
    }
}