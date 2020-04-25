using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab_11
{
    class Program
    {
        static List<Person> persons = new List<Person>();

        static List<Person> personsClone = new List<Person>();
        static Person[] masPerson;
        
        static void Main(string[] args)
        {
            persons.Add(new Student("Антон", DateTime.Parse("07.05.2000"),4,"ПИ",new List<int> { 7, 4, 9, 4, 7 }));
            persons.Add(new School("Иван", DateTime.Parse("07.05.2012"), 3,"Ирина Ивановна" ));
            bool exit = true;
            do
            {
                exit = Menu();
            } while (!exit);
        }


        static public void Sort()
        {
            foreach (var item in persons.OrderBy(x => x.Name))
            {
                Console.WriteLine(item.ToString());
            }
        }
        static public bool Menu()
        {
            int index = 0;
            Console.WriteLine("1.Добавить объект");
            Console.WriteLine("2.Удалить объект");
            Console.WriteLine("3.Сделать запрос");
            Console.WriteLine("4.Копировать");
            Console.WriteLine("5.Выход");
            index = int.Parse(Console.ReadLine());
            switch (index)
            {
                case 1:
                    AddObject();
                    break;
                case 2:
                    DeleteObject();
                    break;
                case 3:
                    Query();
                    break;
                case 4:
                    Copy();
                    break;
                case 5:
                    return true;
                    break;
            }
            return false;
        }
        static public void Copy()
        {
            persons.CopyTo(0, masPerson, 0, persons.Count);
            personsClone = masPerson.ToList();
        }

        static public void AddObject()
        {
            int index = 0;
            Console.WriteLine("1.Добавить школьника");
            Console.WriteLine("2.Добавить студента");
            index = int.Parse(Console.ReadLine());
            switch (index)
            {
                case 1:
                    Console.WriteLine("1.введите имя школьника");
                    string nameSchool = Console.ReadLine();
                    Console.WriteLine("2.введите класс школьника");
                    int Class = int.Parse(Console.ReadLine());
                    Console.WriteLine("3.введите классного руководителя");
                    string HeadTeacher = Console.ReadLine();
                    School schoolGuy = new School(nameSchool,DateTime.Now,Class, HeadTeacher);
                    persons.Add(schoolGuy);
                    break;

                case 2:
                    Console.WriteLine("1.Введите имя студента");
                    string nameStud = Console.ReadLine();
                    Console.WriteLine("2.Введите курс студента");
                    int courseStud = int.Parse(Console.ReadLine());
                    Console.WriteLine("3.Введите образовательную программу");
                    string programmStud = Console.ReadLine();
                    School studGuy = new School(nameStud, DateTime.Now, courseStud, programmStud);                 
                    break;
            }
        }
        static public void DeleteObject()
        {
            int index = 0;
            Console.WriteLine("1.Удалить школьника");
            Console.WriteLine("2.Удалить студента");
            index = int.Parse(Console.ReadLine());
            switch (index)
            {
                case 1:
                    Console.WriteLine("Как зовут школьника?");
                    int DeleteClass = int.Parse(Console.ReadLine());
                    string DeleteHeadTeacher = Console.ReadLine();
                    try
                    {
                        Person deletePerson = persons.Find(x => ((School)x).Class == DeleteClass && ((School)x).HeadTeacher==DeleteHeadTeacher);
                        persons.Remove(deletePerson);
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Такого школьника нет"); 
                    }                    
                    break;

                case 2:
                    Console.WriteLine("Как зовут Студента?");
                    string DeleteNameStud = Console.ReadLine();
                    try
                    {
                        Person deletePerson = persons.Find(x => ((Student)x).Name == DeleteNameStud); 
                        persons.Remove(deletePerson);
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Такого студента нет");
                    }
                    break;
            }
        }
        static void Query()
        {

            int index = 0;
            Console.WriteLine("1.Поиск по студентам");
            Console.WriteLine("2.Поиск по школьникам");
            Console.WriteLine("3.Поиск по людям");
            index = int.Parse(Console.ReadLine());
            switch (index)
            {
                case 1:
                    Console.WriteLine("Введите имя студента");
                    string FindName = Console.ReadLine();
                    var studCheck = persons.Where(x => x.Name == FindName).Where(x => x is Student);
                    if (studCheck.Any())
                    {
                        foreach (Person person in studCheck)
                        {
                            Console.WriteLine(person.ToString());
                        }
                    }else Console.WriteLine("Таких студентов нет");
                    break;

                case 2:
                    Console.WriteLine("Введите класс");
                    int FindClass = int.Parse(Console.ReadLine());
                    var schools = persons.Where(x => x is School).Where(x => (x as School).Class == FindClass);
                    if (schools.Any())
                    {
                        foreach (Person person in schools)
                        {
                            Console.WriteLine(person.ToString());
                        }
                    } else Console.WriteLine("Таких школьников нет");
                    break;

                case 3:
                    DateTime FindPerson = DateTime.Parse(Console.ReadLine());
                    foreach (Person person in persons.Where(x => x.DateOfBirth == FindPerson))
                    {
                        Console.WriteLine(person.ToString());
                    }
                    break;
            }
        }

        
    }
}
