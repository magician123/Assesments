using Autofac;
using SortText.UI.Startup;
using System;

namespace SortText.UI
{
    class Program
    {
        static void Main(string[] args)
        {

            Bootstrapper bootsrapper = new Bootstrapper();

            var container = bootsrapper.Bootstrap();
            var sort = container.Resolve<SortText>();

            Console.WriteLine("Enter a text");
            var text = Console.ReadLine();

            Console.WriteLine($"Sorted text is {sort.SortStringAsync(text).Result}");
            Console.ReadKey();
        }
 
    }
}
