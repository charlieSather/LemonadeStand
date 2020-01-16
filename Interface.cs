using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemondeStandProject
{
    static class Interface
    {
        public static (int, int, int, double) GetRecipe()
        {
            Console.WriteLine("How many lemons in your recipe?");
            int lemons = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("How many sugar cubes in your recipe?");
            int sugarCubes = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("How many ice cubes in your recipe?");
            int iceCubes = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("What is the price of your recipe?");
            double price = Convert.ToInt32(Console.ReadLine());

            return (lemons, sugarCubes, iceCubes, price);
        }

        public static string GetName(int playerNumber)
        {
            Console.WriteLine($"What is player number {playerNumber}'s name?");
            return Console.ReadLine();
        }

        public static int GetPlayers()
        {
            Console.WriteLine("How many players are there?");
            return Convert.ToInt32(Console.ReadLine());
        }

        public static void GameOver(Player player)
        {
            Console.WriteLine($"{player.name} wins!");
        }

        public static int BuyLemons()
        {
            Console.WriteLine("How many lemons would you like to buy?");
            return Convert.ToInt32(Console.ReadLine());            
        }
        public static int BuyIce()
        {
            Console.WriteLine("How many ice cubes would you like to buy?");
            return Convert.ToInt32(Console.ReadLine());
        }
        public static int BuySugar()
        {
            Console.WriteLine("How many sugar cubes would you like to buy?");
            return Convert.ToInt32(Console.ReadLine());
        }
        public static int BuyCups()
        {
            Console.WriteLine("How many cups would you like to buy?");
            return Convert.ToInt32(Console.ReadLine());
        }
    }
}
