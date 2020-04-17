using System;
using System.Collections.Generic;
using System.Text;

namespace lv_2
{
    class Program
    {
        static void Main(string[] args)
        {
            DiceRoller diceRoller = new DiceRoller();
            for (int i = 0; i < 20; i++)
            {
                diceRoller.InsertDie(new Die(6));
            }
            diceRoller.RollAllDice();
            IList<int> results = diceRoller.GetRollingResults();
            foreach (int result in results)
            {
                Console.WriteLine(result);
            }
        }
    }
}
