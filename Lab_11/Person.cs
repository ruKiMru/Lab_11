using System;
using System.Collections.Generic;
using System.Text;

namespace Lab_11
{
    abstract class Person:IMovable //нельзя добавлять в коллекцию
    {
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public void Move()
        {
            throw new NotImplementedException(); //метод не реализован
        }
        public Person()
        {
            Name = "Иван";
            DateOfBirth = DateTime.Now;
        }
        public Person(string name, DateTime dateOfBirth)
        {
            Name = name;
            DateOfBirth = dateOfBirth;
        }
    }
}
