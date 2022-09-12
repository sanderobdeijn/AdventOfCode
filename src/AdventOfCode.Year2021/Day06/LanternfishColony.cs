using System.Numerics;

namespace AdventOfCode.Year2021.Day06
{
    public class LanternfishColony
    {
        public LanternfishColony(int daysUntilReproduction, long count)
        {
            DaysUntilReproduction = daysUntilReproduction;
            Count = count;
        }

        public int DaysUntilReproduction { get; private set; }

        public long Count { get; private set; }

        public IEnumerable<LanternfishColony> NextDay()
        {
            if(DaysUntilReproduction == 0)
            {
                return new List<LanternfishColony>() 
                { 
                    new LanternfishColony(8, Count),
                    new LanternfishColony(6, Count)
                };
            }

            return new List<LanternfishColony>() { new LanternfishColony(DaysUntilReproduction - 1, Count) };
        }
    }
}
