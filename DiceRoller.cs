using System;
using System.Collections.Generic;
using System.Text;

namespace lv_2
{
    class DiceRoller : ILogable
    {
        private List<Die> dice;
        private List<int> resultForEachRoll;
        public DiceRoller()
        {
            this.dice = new List<Die>();
            this.resultForEachRoll = new List<int>();
        }
        public virtual void InsertDie(Die die)
        {
            dice.Add(die);
        }
        public virtual void RollAllDice()
        {
            this.resultForEachRoll.Clear();
            foreach (Die die in dice)
            {
                this.resultForEachRoll.Add(die.Roll());
            }
        }
        public virtual void RemoveAllDice()
        {
            this.dice.Clear();
            this.resultForEachRoll.Clear();
        }
        public IList<int> GetRollingResults()
        {

            return new System.Collections.ObjectModel.ReadOnlyCollection<int>(this.resultForEachRoll);

        }
        public int DiceCount
        {
            get { return dice.Count; }
        }
        public string GetStringRepresentation()
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (int result in this.resultForEachRoll)
            {
                stringBuilder.Append(result.ToString()).Append("\n");
            }
            return stringBuilder.ToString();
        }
    }
}



