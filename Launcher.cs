using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace BaseConverter;

public class Launcher
{
    const string Digits = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuv";

    /// <summary>
    /// Конвертер из СС10 в СС[2;50]
    /// </summary>
    static string FromBase10(BigInteger N, int baseX)
    {
        if (baseX < 2 || baseX > Digits.Length)
        {
            throw new ArgumentException($"Основание должно быть в диапазоне [2;50] !!");
        }

        if (N == 0)
        {
            return "0";
        }

        string result = "";
        while (N > 0)
        {
            int cur = (int)(N % baseX);
            result = Digits[cur] + result;
            N /= baseX;
        }
        return result;
    }

    /// <summary>
    /// Конвертер строки N из СС[baseX] в СС[base10]
    /// </summary>
    static string ToBase10(string N, int baseX)
    {
        if (baseX < 2 || baseX > Digits.Length)
        {
            throw new ArgumentException($"Основание должно быть в диапазоне [2;50] !!");
        }

        BigInteger base10 = N.Reverse().Select((digit, index) => Digits.IndexOf(digit) * BigInteger.Pow(baseX, index)).Aggregate((first, next) => first + next);

        return base10.ToString();
    }


    static void Main()
    {
        Console.Write("Введите число: ");
        string input = Console.ReadLine().Trim();

        Console.Write("Введите СС числа [2–50]: ");
        int fromBase = int.Parse(Console.ReadLine());

        Console.Write("Введите выходную СС [2–50]: ");
        int toBase = int.Parse(Console.ReadLine());

        try
        {
            string base10 = ToBase10(input, fromBase);
            string result = FromBase10(BigInteger.Parse(base10), toBase);

            Console.WriteLine($"{result}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"{ex.Message}");
        }

        //Console.WriteLine("\n...");
        //Console.ReadLine();
    }
}
