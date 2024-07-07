using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace WRA.Utility
{
    public static class RandomHelper
    {
        private const int RANDOM_REPEATS_MAX = 10;
    
        public static List<int> RandomNumbersFromRange(int min, int max, int count, List<int> exclude = null)
        {
            List<int> numbers = new List<int>();
            var tempRepeats = 0;
            var numbersLenght = max - min;
        
            if (exclude == null)
            {
                exclude = new List<int>();
            }
        
            if (numbersLenght < count)
            {
                Debug.LogError("Count is bigger than range");
                count = numbersLenght - 1;
            }

            for (int i = 0; i < count; i++)
            {
                if (tempRepeats > RANDOM_REPEATS_MAX)
                {
                    Debug.LogWarning("Breaked loop because of too many repeats");
                    break;
                }

                var tempRand = Random.Range(min, max);
                if (numbers.Contains(tempRand))
                {
                    tempRepeats++;
                    i--;
                    continue;
                }
                numbers.Add(tempRand);
            }

            return numbers;
        }
    
        public static int RandomNumberExcludeNumbers(int min, int max, List<int> exclude)
        {
            var count = max - min;
            if (count <= exclude.Count)
            {
                Debug.LogError("Exclude list is bigger than range");
                return -1;
            }
        
            if(count == 0 || count == 1)
                return min;

            var numbers = Enumerable.Range(min, max).ToList();
            exclude.ForEach(x => numbers.Remove(x));
        
            return numbers[Random.Range(0, numbers.Count)];
        }
    }
}
