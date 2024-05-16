namespace RomanNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {


            Console.WriteLine("Numbers To Roman");
            int n1 = 5;
            string romanString = Roman.IntToRoman(n1);
            Console.WriteLine($"Number: {n1} = {romanString}");
            int n2 = 1994;
            string romanString2 = Roman.IntToRoman(n2);
            Console.WriteLine($"Number: {n2} = {romanString2}");


            Console.WriteLine("===============================");
            Console.WriteLine("Roman To Numbers");
            string roman = "III";
            int num = Roman.RomanToInt(roman);
            Console.WriteLine($"Roman: {roman} = {num}");
            string roman2 = "MCMXCIV";
            int num2 = Roman.RomanToInt(roman2);
            Console.WriteLine($"Roman: {roman2} = {num2}");
            Console.ReadLine();
        }
    }


    public static class Roman
    {
        public static string IntToRoman(int num)
        {
            string romanResult = string.Empty;
            string[] romanLetters = {
                                        "M",
                                        "CM",
                                        "D",
                                        "CD",
                                        "C",
                                        "XC",
                                        "L",
                                        "XL",
                                        "X",
                                        "IX",
                                        "V",
                                        "IV",
                                        "I"
            };
            int[] numbers = {
                                    1000,
                                    900,
                                    500,
                                    400,
                                    100,
                                    90,
                                    50,
                                    40,
                                    10,
                                    9,
                                    5,
                                    4,
                                    1
            };
            int i = 0;
            while (num != 0)
            {
                if (num >= numbers[i])
                {
                    num -= numbers[i];
                    romanResult += romanLetters[i];
                }
                else
                {
                    i++;
                }
            }
            return romanResult;
        }

        public static string IntToRomanDictionary(int num)
        {
            string romanResult = "";
            Dictionary<string, int> romanNumbersDictionary = new() {
            {
                "I",
                1
            }, {
                "IV",
                4
            }, {
                "V",
                5
            }, {
                "IX",
                9
            }, {
                "X",
                10
            }, {
                "XL",
                40
            }, {
                "L",
                50
            }, {
                "XC",
                90
            }, {
                "C",
                100
            }, {
                "CD",
                400
            }, {
                "D",
                500
            }, {
                "CM",
                900
            }, {
                "M",
                1000
            }
        };
            foreach (var item in romanNumbersDictionary.Reverse())
            {
                if (num <= 0) break;
                while (num >= item.Value)
                {
                    romanResult += item.Key;
                    num -= item.Value;
                }
            }
            return romanResult;
        }

        /* ============================================================================= */

        /// <summary>
        /// Example 1
        /// Input: s = "III"
        /// Output: 3
        /// Explanation: III = 3.
        /// 
        /// Example 2
        /// Input: s = "LVIII"
        /// Output: 58
        /// Explanation: L = 50, V= 5, III = 3.
        /// 
        /// Example 3
        /// Input: s = "MCMXCIV"
        /// Output: 1994
        /// Explanation: M = 1000, CM = 900, XC = 90 and IV = 4.
        /// 
        /// https://www.c-sharpcorner.com/article/convert-roman-to-numbers-in-c-sharp/
        /// https://www.c-sharpcorner.com/article/convert-numbers-to-roman-characters-in-c-sharp/
        /// لو اللى بعده اكبر نطرح
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static int RomanToInt(string s)
        {
            int sum = 0;
            Dictionary<char, int> romanNumbersDictionary = new()
            {
                { 'I', 1 },
                { 'V', 5 },
                { 'X', 10 },
                { 'L', 50 },
                { 'C', 100 },
                { 'D', 500 },
                { 'M', 1000 }
            };
            for (int i = 0; i < s.Length; i++)
            {
                char currentRomanChar = s[i];
                romanNumbersDictionary.TryGetValue(currentRomanChar, out int num);
                if (i + 1 < s.Length && romanNumbersDictionary[s[i + 1]] > romanNumbersDictionary[currentRomanChar])
                {
                    sum -= num;
                }
                else
                {
                    sum += num;
                }
            }
            return sum;
        }
    }

}
