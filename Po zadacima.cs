//zad 1.
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

// zad 2.


    class Program
    {
        static void Main(string[] args)
        {
            DiceRoller diceRoller = new DiceRoller();
            Random randomGenerator = new Random();
            for (int i = 0; i < 20; i++)
            {
                diceRoller.InsertDie(new Die(6, randomGenerator));
            }
            diceRoller.RollAllDice();
            IList<int> results = diceRoller.GetRollingResults();
            foreach (int result in results)
            {
                Console.WriteLine(result);
            }
        }
    }




    class Die
    {
        private int numberOfSides;
        private Random randomGenerator;
        public Die(int numberOfSides, Random randomGenerator)
        {
            this.numberOfSides = numberOfSides;
            this.randomGenerator = randomGenerator;
        }
        public int Roll()
        {
            int rolledNumber = randomGenerator.Next(1, numberOfSides + 1);
            return rolledNumber;
        }

    }

// zad 3.


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


    class RandomGenerator
    {
        private static RandomGenerator instance;
        private Random random;
        private RandomGenerator()
        {
            this.random = new Random();
        }
        public static RandomGenerator GetInstance()
        {
            if (instance == null)
                instance = new RandomGenerator();
            return instance;
        }
        public int NextInt(int lowerBound, int upperBound)
        {
            return random.Next(lowerBound, upperBound);
        }

    }



    class Die
    {
        private int numberOfSides;
        private RandomGenerator randomGenerator;
        public Die(int numberOfSides)
        {
            this.numberOfSides = numberOfSides;
            this.randomGenerator = RandomGenerator.GetInstance();
        }
        public int Roll()
        {
            return this.randomGenerator.NextInt(1, numberOfSides + 1);
        }
    }


// zad 4. 


    interface ILogger
    {
        void Log(string message);
    }





    class ConsoleLogger : ILogger
    {
        public void Log(string message) { Console.WriteLine(message); }
    }



    class FileLogger : ILogger
    {
        private string filePath;
        public FileLogger(string filePath)
        {
            this.filePath = filePath;
        }
        public void Log(string message)
        {
            using (System.IO.StreamWriter fileWriter = new System.IO.StreamWriter(this.filePath, true))

            {
                fileWriter.WriteLine(message);
            }
        }
    }




    class DiceRoller
    {
        private List<Die> dice;
        private List<int> resultForEachRoll;
        private ILogger logger;
        public DiceRoller()
        {
            this.dice = new List<Die>();
            this.resultForEachRoll = new List<int>();
        }
        public void InsertDie(Die die)
        {
            dice.Add(die);
        }
        public void RollAllDice()
        {
            this.resultForEachRoll.Clear();
            foreach (Die die in dice)
            {
                this.resultForEachRoll.Add(die.Roll());
            }
        }
        public IList<int> GetRollingResults()
        {
            return
            new System.Collections.ObjectModel.ReadOnlyCollection<int>(this.resultForEachRoll);
        }
        public int DiceCount
        {
            get { return dice.Count; }
        }
        public void SetLogger(ILogger logger)
        {
            this.logger = logger;
        }
        public void LogRollingResults()
        {
            foreach (int result in this.resultForEachRoll)
            {
                logger.Log(result.ToString());
            }
        }
    }


// zad 5.

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



    interface ILogable
    {
        string GetStringRepresentation();
    }



    interface ILogger
    {
        void Log(ILogable data);
    }




    class FileLogger : ILogger
    {
        private string filePath;
        public FileLogger(string filePath)
        {
            this.filePath = filePath;
        }
        public void Log(ILogable data)
        {
            using (System.IO.StreamWriter fileWriter = new System.IO.StreamWriter(this.filePath))

            {
                fileWriter.WriteLine(data.GetStringRepresentation());
            }
        }
    }




    class ConsoleLogger : ILogger
    {
        public void Log(ILogable data)
        {
            Console.WriteLine(data.GetStringRepresentation());
        }
    }


// zad 6.)

    interface IRoller
    {
        void RollAllDice();
    }



    interface IHandleDice
    {
        void RemoveAllDice();
        void RollAllDice();
    }


    class ClosedDiceRoller : IRoller
    {
        private List<Die> dice;
        private List<int> resultForEachRoll;
        public ClosedDiceRoller(int diceCount, int numberOfSides)
        {
            this.dice = new List<Die>();
            for (int i = 0; i < diceCount; i++)
            {
                this.dice.Add(new Die(numberOfSides));
            }
            this.resultForEachRoll = new List<int>();
        }
        public void RollAllDice()
        {
            this.resultForEachRoll.Clear();
            foreach (Die die in dice)
            {
                this.resultForEachRoll.Add(die.Roll());
            }
        }
    }


    class FlexibleDiceRoller : IRoller, IHandleDice
    {
        private List<Die> dice;
        private List<int> resultForEachRoll;
        public FlexibleDiceRoller()
        {
            this.dice = new List<Die>();
            this.resultForEachRoll = new List<int>();
        }
        public void InsertDie(Die die)
        {
            dice.Add(die);
        }
        public void RemoveAllDice()
        {
            this.dice.Clear();
            this.resultForEachRoll.Clear();
        }
        public void RollAllDice()
        {
            this.resultForEachRoll.Clear();
            foreach (Die die in dice)
            {
                this.resultForEachRoll.Add(die.Roll());
            }
        }
    }


// zad 7. 

    class FlexibleDiceRoller : IRoller, IHandleDice
    {
        private List<Die> dice;
        private List<int> resultForEachRoll;
        public FlexibleDiceRoller()
        {
            this.dice = new List<Die>();
            this.resultForEachRoll = new List<int>();
        }
        public void InsertDie(Die die)
        {
            dice.Add(die);
        }
        public void RemoveAllDice()
        {
            this.dice.Clear();
            this.resultForEachRoll.Clear();
        }
        public void RemoveDiceWithSides(int sides)
        {
            for (int i = 0; i < dice.Count; i++)
            {
                if (dice[i].NumberOfSides == sides)
                {
                    dice.RemoveAt(i);

                    --i;
                }
            }
        }
        public void RollAllDice()
        {
            this.resultForEachRoll.Clear();
            foreach (Die die in dice)
            {
                this.resultForEachRoll.Add(die.Roll());
            }
        }
    }


    class Die
    {
        private int numberOfSides;
        private RandomGenerator randomGenerator;
        public Die(int numberOfSides)
        {
            this.numberOfSides = numberOfSides;
            this.randomGenerator = RandomGenerator.GetInstance();
        }
        public int Roll()
        {
            return this.randomGenerator.NextInt(1, numberOfSides + 1);
        }
        public int NumberOfSides
        {
            get { return this.numberOfSides; }
        }
    }






