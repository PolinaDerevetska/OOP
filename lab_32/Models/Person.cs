﻿namespace EfInheritanceLab.Models
{
    public abstract class Person
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public int Age { get; set; }
    }
}
