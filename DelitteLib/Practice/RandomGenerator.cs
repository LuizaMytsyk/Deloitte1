using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelitteLib
{
    public static class RandomGenerator
    {
        static Random random = new Random();

        public static string GetRandomAlphaNumeric()
        {
            var chars = "abcdefghijklmnopqrstuvwxyz0123456789";
            return new string(chars.Select(c => chars[random.Next(chars.Length)]).Take(8).ToArray());
        }

 
        public static int GetRandomNumber(int count)
        {
            int r = random.Next(count);
            return r;
        }

        public static string SelectRandomElementFromFile(List<string> IDList)
        {
            string ID;
            int randomNumber = RandomGenerator.GetRandomNumber(IDList.Count);
            ID = IDList[randomNumber];
            return ID;
        }



    }
}
