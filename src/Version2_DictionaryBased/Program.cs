using System;
using System.Collections.Generic;
using System.Text;

class Program
{
    static void Main()
    {
        Console.WriteLine("Enter keypad input (e.g., 4433555 555666#):");
        string input = Console.ReadLine();

        if (!input.EndsWith("#"))
            input += "#";

        string output = Translate(input);
        Console.WriteLine("Final Output: " + output);
    }

    static string Translate(string input)
    {
        var keypad = new Dictionary<char, string>()
        {
            {'1', ".,?!"},
            {'2', "ABC"},
            {'3', "DEF"},
            {'4', "GHI"},
            {'5', "JKL"},
            {'6', "MNO"},
            {'7', "PQRS"},
            {'8', "TUV"},
            {'9', "WXYZ"},
            {'0', " "}
        };

        StringBuilder result = new StringBuilder();
        int i = 0;

        while (i < input.Length)
        {
            char current = input[i];

            if (current == '#') break;
            if (current == '*')
            {
                if (result.Length > 0) result.Length--;
                i++;
                continue;
            }
            if (current == ' ')
            {
                i++;
                continue;
            }

            int count = 1;
            while (i + count < input.Length && input[i + count] == current)
                count++;

            if (keypad.ContainsKey(current))
            {
                string chars = keypad[current];
                int index = (count - 1) % chars.Length;
                result.Append(chars[index]);
            }

            i += count;
        }

        return result.ToString();
    }
}
