using System;
using System.Collections.Generic;

using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proxy
{
    class Program
    {
        static void Main(string[] args)
        {
            IBook book = new BookStoreProxy("book.txt");

            // читаем первую страницу
            Page page1 = book.GetPage(1);
            Console.WriteLine(page1.Number + "\n" + page1.Text + "\n" + page1.Number + "\n" + page1.Text.Length + "\n");
            // читаем вторую страницу
            Page page2 = book.GetPage(2);
            Console.WriteLine(page2.Number + "\n" + page2.Text + "\n" + page2.Number + "\n" + page2.Text.Length + "\n");
            // возвращаемся на первую страницу    
            page1 = book.GetPage(1);
            Console.WriteLine(page1.Number + "\n" + page1.Text + "\n" + page1.Number + "\n");


            Console.Read();
        }
    }
    
           
       
    class Page
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public string Text { get; set; }
    }

    interface IBook
    {
        Page GetPage(int number);
    }

    class BookStore : IBook
    {
        string _fileText;
        public BookStore(string name)
        {
           _fileText = File.ReadAllText(name);
        }

        public Page GetPage(int number)
        {
            string pageText = _fileText.Substring((number - 1)*2000, 2000-1);
            return new Page() {Number = number, Id = number, Text = pageText };
        }

        
    }

    class BookStoreProxy : IBook
    {
        private List<Page> _pages;
        private BookStore _bookStore;
        string _name;

        public BookStoreProxy(string name)
        {
            _name = name;
            _pages = new List<Page>();
        }
        public Page GetPage(int number)
        {
            Page page = _pages.FirstOrDefault(p => p.Number == number);
            if (page == null)
            {
                if (_bookStore == null)
                    _bookStore = new BookStore(_name);
                page = _bookStore.GetPage(number);
                _pages.Add(page);
            }
            return page;
        }

       
    }
}
