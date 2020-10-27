using System;
using System.Collections.Generic;
using System.Text;

namespace Stud
{
    public class Student
    {
        public String Fname { get; set; }
        public String Lname { get; set; }
        public String Group { get; set; }
        public int Age { get; set; }
        public DateTime DateBirth{ get; set; }
        

        public override string? ToString()
        {
            string? str = Fname + " " + Lname + " " + Group + " " + Age + " " + DateBirth.ToString("dd.MM.yyyy");
            return str;
        }


    }
}
