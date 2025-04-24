
using System;
using Microsoft.EntityFrameworkCore;

namespace backendExercises3_4;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddDbContext<AppContext>();



        var app = builder.Build();

        Run();



        app.Run();
    }

    private static void Run()
    {


        while (true)
        {
            System.Console.WriteLine("\n Type 'add', 'Print', 'Delete', 'Update' or 'add-author', 'delete-author', 'print-author' ");
            string input = Console.ReadLine()!;
            switch (input)
            {
                case "add":
                    AddQuote();
                    break;
                case "print":
                    PrintQuotes();
                    break;
                case "delete":
                    DeleteQuotes();
                    break;
                    case "add-author": AddAuthor();
                    break;
                default:
                    System.Console.WriteLine("you are exiting");
                    return;
            }
        }

    }
    private static void AddAuthor()
    {
        System.Console.WriteLine("Enter authors name to add: ");
        string authorName = Console.ReadLine()!;
        System.Console.WriteLine("Enter description: ");
        string description = Console.ReadLine()!;

        using var context = new AppContext();
        context.Authors.Add( new Author{
            Name = authorName,
            Description = description

        });
        context.SaveChanges();
        System.Console.WriteLine("Author name has been successfully added!");
    }

    private static void AddQuote()
    {
        System.Console.WriteLine("Enter a quote: ");
        string QuoteInput = Console.ReadLine()!;

        System.Console.WriteLine("Enter auhtor name: ");
        string AuthorName = Console.ReadLine()!;

        using var context = new AppContext();
        context.Echos.Add(new Echo
        {
            Quote = QuoteInput,
           // Author = AuthorName
        });
        context.SaveChanges();
        System.Console.WriteLine("Quote added successfully!");
    }

    private static void PrintQuotes()
    {
        //print all quotes 
       /* using var context = new AppContext();
        var quotes = context.Echos.ToList();
        if (quotes.Any())
        {
            Console.WriteLine("\n All quotes");

            foreach (var quote in quotes)
            {
                Console.WriteLine($"\n '{quote.Quote}' - by: {quote.Author}");
            }
        } */

        //retreive quotes from database based on auhtors name
        // System.Console.WriteLine("Enter authors name: ");
        // string AuthorName = Console.ReadLine()!;

        // using var context = new AppContext();
        // var quotes = context.Echos.Where(e => e.Author.Equals(AuthorName)).ToList();
        // if (quotes.Any())
        // {
        //     System.Console.WriteLine($"These are {AuthorName} quotes: ");
        //     foreach( var quote in quotes)
        //     {
        //         System.Console.WriteLine(quote.Quote);
        //     }
        // }
    }
    private static void DeleteQuotes()
    {
        //delete quote based the content itself
      /*  System.Console.WriteLine("enter the quote you want to remove: ");
        string QuoteInput = Console.ReadLine()!;

        using var context = new AppContext();
        var quoteToDelete = context.Echos.FirstOrDefault(e => e.Quote == QuoteInput);
        if (quoteToDelete != null)
        {
            context.Echos.Remove(quoteToDelete);
            context.SaveChanges();
            System.Console.WriteLine("Entered quote has been deleted!");
        }
        else
        {
            System.Console.WriteLine("quote not found!");
        } */


        //delete quote based on the author
        System.Console.WriteLine("Enter auhtors name:");
        string AuthorName = Console.ReadLine()!;

        using var context = new AppContext();
        var AuthorsQuote = context.Echos.Where(e => e.Author.Equals(AuthorName)).ToList();

        if (AuthorsQuote.Any())
        {
            context.Echos.RemoveRange(AuthorsQuote);
            context.SaveChanges();
            System.Console.WriteLine("Specified author quotes have been removed");
        }
        else{
            System.Console.WriteLine("somehing went wrong!");
        }
        
         
        
    }
}


public class Author
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
}


public class Echo
{
    public int Id { get; set; }
    public string Quote { get; set; }
    public int AuthorId { get; set; }
    public Author Author { get; set; }



}




public class AppContext : DbContext
{
    public DbSet<Echo> Echos => Set<Echo>();
    public DbSet<Author> Authors => Set<Author>();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=localhost;Database=backendexercises3_4;Username=postgres;Password=password");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Echo>()
        .HasOne(e => e.Author)
        .WithMany()
        .HasForeignKey(e => e.AuthorId);
    }
}

