using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Stud
{
    public class Student
    {
        [StringLength(20)]
        public String Fname { get; set; }
        [StringLength(20)]
        public String Lname { get; set; }
        [StringLength(10)]
        public String Group { get; set; }
        public int Age { get; set; }
        public DateTime DateBirth{ get; set; }
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();


        public override string? ToString()
        {
            string? str = Fname + " " + Lname + " " + Group + " " + Age + " " + DateBirth.ToString("dd.MM.yyyy");
            return str;
        }


    }
}
