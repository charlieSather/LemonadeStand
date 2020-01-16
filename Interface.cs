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
            double price = Convert.ToDouble(Console.ReadLine());

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

        public static int ShopMenu(Player player)
        {
            Console.Clear();
            Console.WriteLine("You have:");
            Console.WriteLine($"{player.inventory.lemons.Count} lemons");
            Console.WriteLine($"{player.inventory.sugarCubes.Count} Sugar Cubes");
            Console.WriteLine($"{player.inventory.iceCubes.Count} Ice Cubes");
            Console.WriteLine($"{player.inventory.cups.Count} cups\n");


            Console.WriteLine($"What would you like to buy? You have {player.wallet.money} dollars.");
            Console.WriteLine("1: Lemons");
            Console.WriteLine("2: Sugar Cubes");
            Console.WriteLine("3: Ice Cubes");
            Console.WriteLine("4: Cups");
            Console.WriteLine("5: Finihsed");

            int input = Convert.ToInt32(Console.ReadLine());

            if (input > 5)
            {
                return ShopMenu(player);
            }

            return input;

        }

        public static void CustomerPurchase(Customer customer)
        {
            Console.WriteLine($"{customer.name} bought your lemonade!");
        }
    }
}
