using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Reflection.Emit;

public abstract class User
{
    public int UserId { get; set; }
    public string FullName { get; set; }
    public string Email { get; set; }

    public List<Borrowing> Borrowings { get; set; }
}

public class Reader : User
{
    public DateTime MembershipDate { get; set; }
    public List<Borrowing> Borrowings { get; set; } // Зв'язок з позиками
}

public class LibraryWorker : User
{
    public string Position { get; set; }
    public List<Borrowing> Borrowings { get; set; } // Зв'язок з позиками
}

public class Book
{
    public int BookId { get; set; }
    public string Title { get; set; }
    public int YearPublished { get; set; }
}

public class Borrowing
{
    public int BorrowingId { get; set; }
    public int UserId { get; set; }  // Приватний ключ для зв'язку з користувачем
    public int BookId { get; set; }  // Приватний ключ для зв'язку з книгою
    public DateTime BorrowDate { get; set; }
    public DateTime ReturnDate { get; set; }

    public User User { get; set; } // Зв'язок з користувачем
    public Book Book { get; set; } // Зв'язок з книгою
}
public class LibraryContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Reader> Readers { get; set; }
    public DbSet<LibraryWorker> LibraryWorkers { get; set; }
    public DbSet<Book> Books { get; set; }
    public DbSet<Borrowing> Borrowings { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=librarydb;Username=postgres;Password=1234");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Book>().ToTable("books");
        modelBuilder.Entity<Borrowing>().ToTable("borrowings");
        // Налаштування для User
        modelBuilder.Entity<User>().ToTable("Users");

        // Налаштування для Reader
        modelBuilder.Entity<Reader>().ToTable("Readers");
        modelBuilder.Entity<Reader>().HasBaseType<User>(); // Вказуємо, що Reader наслідує від User

        // Налаштування для LibraryWorker
        modelBuilder.Entity<LibraryWorker>().ToTable("LibraryWorkers");
        modelBuilder.Entity<LibraryWorker>().HasBaseType<User>(); // Вказуємо, що LibraryWorker наслідує від User

        // Налаштування для Borrowing (Зв'язок з користувачем та книгою)
        modelBuilder.Entity<Borrowing>()
            .HasKey(b => b.BorrowingId);

        modelBuilder.Entity<Borrowing>()
            .HasOne(b => b.User)
            .WithMany(u => u.Borrowings)
            .HasForeignKey(b => b.UserId)
            .OnDelete(DeleteBehavior.Cascade); // Каскадне видалення, якщо користувача видаляють

        modelBuilder.Entity<Borrowing>()
            .HasOne(b => b.Book)
            .WithMany()
            .HasForeignKey(b => b.BookId)
            .OnDelete(DeleteBehavior.Cascade); // Каскадне видалення, якщо книгу видаляють
    }
}
class Program
{
    static void Main()
    {
        using (var context = new LibraryContext())
        {
            // Створення нових записів
            var book1 = new Book { Title = "C# для початківців", YearPublished = 2020 };
            var book2 = new Book { Title = "Основи баз даних", YearPublished = 2021 };

            context.Books.Add(book1);
            context.Books.Add(book2);
            context.SaveChanges();

            var reader = new Reader { FullName = "Олена Іваненко", Email = "olena@example.com", MembershipDate = DateTime.Now };
            var worker = new LibraryWorker { FullName = "Максим Бойко", Email = "maxym@example.com", Position = "Менеджер", };

            context.Readers.Add(reader);
            context.LibraryWorkers.Add(worker);
            context.SaveChanges();

            // Позика книги
            var borrowing = new Borrowing
            {
                UserId = reader.UserId,
                BookId = book1.BookId,
                BorrowDate = DateTime.Now,
                ReturnDate = DateTime.Now.AddDays(7)
            };

            context.Borrowings.Add(borrowing);
            context.SaveChanges();

            // Отримання позик
            var borrowings = context.Borrowings
                .Include(b => b.User)
                .Include(b => b.Book)
                .ToList();

            foreach (var b in borrowings)
            {
                Console.WriteLine($"{b.User.FullName} позичив {b.Book.Title} на {b.BorrowDate.ToShortDateString()} до {b.ReturnDate.ToShortDateString()}");
            }
        }
    }
}
