﻿namespace EfInheritanceLab.Models
{
    public class Group
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";

        public List<Student> Students { get; set; } = new();
    }
}
