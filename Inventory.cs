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

        }
    }
}
