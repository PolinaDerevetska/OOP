using EfInheritanceLab.Data;
using EfInheritanceLab.Models;
using Microsoft.EntityFrameworkCore;

using var db = new AppDbContext();
db.Database.EnsureDeleted();
db.Database.EnsureCreated();

var group = new Group { Name = "CS-101" };
db.Groups.Add(group);

db.People.AddRange(
    new Student { Name = "Anna", Age = 19, StudentNumber = "S123", Group = group },
    new Student { Name = "Ivan", Age = 17, StudentNumber = "S456" },
    new Teacher { Name = "Dr. Smith", Age = 45, Department = "Math" }
);

db.SaveChanges();

// Фільтрація студентів за віком
var adultStudents = db.Students.Where(s => s.Age > 18).ToList();
Console.WriteLine("Студенти старші 18:");
foreach (var s in adultStudents)
    Console.WriteLine($"{s.Name} ({s.Age})");

// Include
var studentsWithGroups = db.Students.Include(s => s.Group).ToList();
Console.WriteLine("\nСтуденти з групами:");
foreach (var s in studentsWithGroups)
    Console.WriteLine($"{s.Name} -> {s.Group?.Name ?? "Немає групи"}");

// Викладачі певного департаменту
var mathTeachers = db.Teachers.Where(t => t.Department == "Math").ToList();
Console.WriteLine("\nВикладачі кафедри Math:");
foreach (var t in mathTeachers)
    Console.WriteLine(t.Name);
