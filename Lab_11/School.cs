using System;
using System.Collections.Generic;
using System.Text;

namespace Lab_11
{
    class School:Person
    {
        public string HeadTeacher { get; set; }
        public int Class { get; set; }

        public School()
        {
            Class = 1;
            HeadTeacher = "Ирина Ивановна";
        }

        public School(int _class, string headTeacher)
        {
            Class = _class;
            HeadTeacher = headTeacher;
        }
        public School(string name, DateTime dateOfBirth, int _class, string headTeacher): base(name, dateOfBirth)
        {
            Class = _class;
            HeadTeacher = headTeacher;
        }
        public override string ToString()
        {
            return $"{Name}, {DateOfBirth}, {Class}, {HeadTeacher}.";
        }
    }
}
