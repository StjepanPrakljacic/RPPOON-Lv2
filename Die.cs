using System;
using System.Collections.Generic;
using System.Text;

namespace lv_2
{
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
}
