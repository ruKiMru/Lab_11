using System;
using System.Collections.Generic;
using System.Text;

namespace Lab_11
{
    class Student:Person
    {
        public int Course { get; set; }
        public string Programm { get; set; }
        List<int> Marks { get; set; } = new List<int>();
        public Student()
        {
            Course = 1;
            Programm = "Программная инженерия";
        }
        public Student(string name, DateTime dateOfBirth, int course, string programm, List<int> marks)
            : base(name, dateOfBirth)
        {
            Marks = marks;
            Course = course;
            Programm = programm;
        }
        public override string ToString() 
        {
            return $"{Name}, {DateOfBirth}, {Course}, {Programm}.";
        }
    }
}
