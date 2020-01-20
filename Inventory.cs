using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemondeStandProject
{
    class Inventory
    {
        public List<Lemon> lemons;
        public List<IceCube> iceCubes;
        public List<Cup> cups;
        public List<SugarCube> sugarCubes;

        public Inventory()
        {
            lemons = new List<Lemon>();
            iceCubes = new List<IceCube>();
            cups = new List<Cup>();
            sugarCubes = new List<SugarCube>();
        }

        public void AddLemons(int lemons)
        {
            for (int i = 0; i < lemons; i++)
            {
                Lemon lemon = new Lemon();
                this.lemons.Add(lemon);
            }
        }

        public void AddIceCubes(int iceCubes)
        {
            for (int i = 0; i < iceCubes; i++)
            {
                IceCube iceCube = new IceCube();
                this.iceCubes.Add(iceCube);
            }
        }

        public void AddSugarCubes(int sugarCubes)
        {
            for (int i = 0; i < sugarCubes; i++)
            {
                SugarCube sugarCube = new SugarCube();
                this.sugarCubes.Add(sugarCube);
            }
        }

        public void AddCups(int cups)
        {
            for(int i = 0; i < cups; i++)
            {
                Cup cup = new Cup();
                this.cups.Add(cup);
            }
        }

        public void DisplayInventory()
        {
            // Interface inventory display
        }

        public bool CheckInventory(Recipe recipe)
        {
            if(lemons.Count < recipe.amountOfLemons)
            {
                return true;
            }
            if (sugarCubes.Count < recipe.amountOfSugarCubes)
            {
                return true;
            }
            if (iceCubes.Count < recipe.amountOfIceCubes)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void CheckIfIceMelted(Weather weather)
        {
            if(weather.temperature > 70 && iceCubes.Count > 0)
            {
                Interface.IceMelted(1);
                iceCubes.Clear();
            }
            else if(weather.temperature > 50 && weather.temperature < 70 && iceCubes.Count > 0)
            {
                iceCubes.RemoveRange(0, iceCubes.Count / 2);
                Interface.IceMelted(2);
            }
        }

        public void UpdateLemons()
        {
            List<Lemon> newLemons = new List<Lemon>();

            foreach(Lemon lemon in lemons)
            {
                lemon.DecrementShelfLife();

                if (!lemon.Expired())
                {
                    newLemons.Add(lemon);
                }
            }

            int lemonsLost = lemons.Count - newLemons.Count;
            if(lemonsLost > 1)
            {
                Interface.LemonsLost(lemonsLost);
            }

            lemons.Clear();
            lemons.AddRange(newLemons);
        }
        public void InventoryCheck(Weather weather)
        {
            CheckIfIceMelted(weather);
            UpdateLemons();
        }
    }
}
