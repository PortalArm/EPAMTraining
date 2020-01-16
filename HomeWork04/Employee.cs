using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork04
{

    public enum Gender { Male, Female, Unknown}
    public enum Qualification { F = 1, E, D, C, B, A, S, SS}
    public class Employee
    {
        public string Name { get; set; }
        public int Year { get; set; }
        public Gender Gender { get; set; }
        public Qualification Level { get; set; }
        public int Salary { get => 10000 + 1000*(int)Level; }
        public Employee(string name, int year, Gender gender = Gender.Unknown, Qualification qualification = Qualification.F)
        {
            Name = name; Year = year; Gender = gender; Level = qualification;
        }

    }
}
