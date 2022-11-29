using Entity.Entities;
using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu nu = new Menu() {Food=new Food()};
          
            Console.WriteLine(nu.Food.Description);
        }
    }
}
