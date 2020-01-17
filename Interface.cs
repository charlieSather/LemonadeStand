using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemondeStandProject
{
    static class Interface
    {
        public static (int, int, int, double) GetRecipe(Player player)
        {
            Console.Clear();
            Console.WriteLine("You have:");
            Console.WriteLine($"{player.inventory.lemons.Count} lemons");
            Console.WriteLine($"{player.inventory.sugarCubes.Count} Sugar Cubes");
            Console.WriteLine($"{player.inventory.iceCubes.Count} Ice Cubes");
            Console.WriteLine($"{player.inventory.cups.Count} cups\n");

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
            Console.WriteLine($"{player.name} ended the game with: ${player.wallet.money}");
            Console.WriteLine($"For a net gain of ${player.profit}.");
        }

        public static void GameOver(Player player1, Player player2)
        {
            Console.WriteLine($"{player1.name} ended the game with: ${player1.wallet.money}");
            Console.WriteLine($"{player2.name} ended the game with: ${player2.wallet.money}");
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

        public static int ShopMenu(Player player, Day day)
        {
            Console.Clear();
            Console.WriteLine("You have:");
            Console.WriteLine($"{player.inventory.lemons.Count} lemons");
            Console.WriteLine($"{player.inventory.sugarCubes.Count} Sugar Cubes");
            Console.WriteLine($"{player.inventory.iceCubes.Count} Ice Cubes");
            Console.WriteLine($"{player.inventory.cups.Count} cups\n");

            Console.WriteLine($"Today's forecast: {day.weather.predictedForecast}\x00B0\n");


            Console.WriteLine($"What would you like to buy? You have ${player.wallet.money}.");
            Console.WriteLine("1: Lemons($.05)");
            Console.WriteLine("2: Sugar Cubes($.02)");
            Console.WriteLine("3: Ice Cubes($.01)");
            Console.WriteLine("4: Cups($.02)");
            Console.WriteLine("5: Finished");

            int input = Convert.ToInt32(Console.ReadLine());

            if (input > 5)
            {
                return ShopMenu(player, day);
            }

            return input;

        }

        public static void CustomerPurchase(Customer customer)
        {
            Console.WriteLine($"{customer.name} bought your lemonade!");
        }

        public static void NoMoreCustomers()
        {
            Console.WriteLine("No more customers today!");
        }

        public static void NoMoreCups()
        {
            Console.WriteLine("You ran out of cups!");
        }

        public static void NotEnoughIngredients()
        {
            Console.WriteLine("You don't have enough ingredients for another pitcher!");
        }
        public static void StartDay(Day day, Player player)
        {
            Console.Clear();
            Console.WriteLine($"{day.name}");
            Console.WriteLine($"The weather today is {day.weather.temperature}\x00B0 and {day.weather.condition}");
            Console.WriteLine($"You're starting with ${player.wallet.money}");
            Console.WriteLine("Press enter to start day!");
            Console.ReadLine();
        }
        public static void EndOfDay(Player player, Day day)
        {
            Console.WriteLine("End of day!");
            Console.WriteLine($"There were {day.customers.Count} customers today, you served {player.customersServed}");
            Console.WriteLine($"You have ${player.wallet.money} after ${Math.Round(player.profit, 2)} net profit.");
            Console.ReadLine();
        }

        public static void OutOfMoney(Player player)
        {
            Console.WriteLine($"Sorry {player.name}, you're out of money!");
        }

        public static void StartTurn(Player player)
        {
            Console.Clear();
            Console.WriteLine($"{player.name}'s turn!");
            Console.WriteLine("Press enter to start!");
            Console.ReadLine();
        }
    }
}
