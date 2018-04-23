using System;

namespace PrototypePattern
{
    public class Book : ICloneable
    {
        public string Author { get; set; }
        public string Title { get; set; }
        public Pages Pages { get; set; }

        public Book(string author, string title, int pageCount)
        {
            Author = author;
            Title = title;
            Pages = new Pages(pageCount);
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }

        public Book DeepCopy()
        {
            Book clone = (Book)this.MemberwiseClone();

            clone.Title = String.Copy(Title);
            clone.Author = String.Copy(Author);
            clone.Pages = new Pages(Pages.PageCount);

            return clone;
        }

        public override string ToString()
        {
            return $"{Author}\t{Title}\t{Pages.PageCount}";
        }
    }

    public class Pages
    {
        public int PageCount { get; set; }

        public Pages(int pageCount)
        {
            PageCount = pageCount;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var baseBook = new Book("Tolkien", "Lord od the Rings", 999);

            Console.WriteLine($"Base book:\t {baseBook}");

            var shallowCopy = baseBook.Clone();
            var deepCopy = baseBook.DeepCopy();

            baseBook.Author = "Mickiewicz";
            baseBook.Pages.PageCount = 99;

            Console.WriteLine($"Modified base:\t {baseBook}");
            Console.WriteLine($"ShallowCopy:\t {shallowCopy}");
            Console.WriteLine($"DeepCopy:\t {deepCopy}");

            Console.ReadKey();
        }
    }
}