using System;
using System.Collections.Generic;


public class Book
{
    public string Title { get; set; }
    public string Author { get; set; }
    public string ISBN { get; set; }
    public int PublicationYear { get; set; }
    public Book(string title, string author, string isbn, int publicationYear)
    {
        Title = title;
        Author = author;
        ISBN = isbn;
        PublicationYear = publicationYear;
    }

}

public class MediaItem
{
    public string Title { get; set; }
    public string MediaType { get; set; }
    public int Duration { get; set; }

    public MediaItem(string title, string mediaType, int duration)
    {
        Title = title;
        MediaType = mediaType;
        Duration = duration;
    }
}

public class Library
{
    public string Name { get; set; }
    public string Address { get; set; }
    public List<Book> Books;
    public List<MediaItem> MediaItems;
    public Library(string name, string address){
        Name = name;
        Address = address;
        Books = new List<Book>();
        MediaItems = new List<MediaItem>();
    }

    public void AddBook(Book book)
    {
        Books.Add(book);
    }

    public void RemoveBook(string ISBN)
    {
        var book = Books.Find(book=> book.ISBN == ISBN);
        if(book == null){
            Console.WriteLine("The book doesn't found");
            return;
        }
        Books.Remove(book);
    }

    public void AddMediaItem(MediaItem item)
    {
        MediaItems.Add(item);
    }

    public void RemoveMediaItem(string title)
    {
        var item = MediaItems.Find(item=> item.Title == title);
        if(item == null){
            Console.WriteLine("The media item doesn't found");
            return;
        }
        MediaItems.Remove(item);
    }

    public void PrintCatalog()
    {
        Console.WriteLine("Books:");
        Console.WriteLine("{0,-10}{1,-10}{2,-10}{3}","Title","Author","ISBN","Year");
        foreach (Book book in Books)
        {
            Console.WriteLine("{0,-10}{1,-10}{2,-10}{3}",book.Title,book.Author,book.ISBN,book.PublicationYear);
        }

        Console.WriteLine("\nMedia Items:");
        Console.WriteLine("{0,-10}{1,-10}{2}","Title","Type","Duration");
        foreach (MediaItem item in MediaItems)
        {
           Console.WriteLine("{0,-10}{1,-10}{2}",item.Title,item.MediaType,item.Duration); 
        }
    }
}

public class Program
{
    public static void Main(){
        Library library = new Library("Abrehot","4 kilo");

        library.AddBook(new Book("book1", "author1", "ISBN1", 1111));
        library.AddBook(new Book("book2", "author2", "ISBN2", 2222));
        library.AddBook(new Book("book3", "author3", "ISBN3", 3333));
        library.AddBook(new Book("book4", "author4", "ISBN4", 4444));

        library.AddMediaItem(new MediaItem("AA", "CD",10));
        library.AddMediaItem(new MediaItem("BB", "DVD",20));
        library.AddMediaItem(new MediaItem("CC", "DVD",30));
        library.AddMediaItem(new MediaItem("DD", "CD",50));

        library.RemoveBook("ISBN5");
        library.PrintCatalog();

    }
}
