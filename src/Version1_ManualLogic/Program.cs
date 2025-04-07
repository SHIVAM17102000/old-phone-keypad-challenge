using System;
using System.Text;

class Program
{
    static void Main()
    {
        Console.WriteLine("Enter keypad input (e.g., 4433555 555666#):");
        string input = Console.ReadLine();

        if (!input.EndsWith("#"))
            input += "#";

        string output = TranslateKeypadInput(input);
        Console.WriteLine("Final Output: " + output);
    }

    static string TranslateKeypadInput(string input)
    {
        string[] keypad = new string[10];
        keypad[1] = ".,?!";
        keypad[2] = "ABC";
        keypad[3] = "DEF";
        keypad[4] = "GHI";
        keypad[5] = "JKL";
        keypad[6] = "MNO";
        keypad[7] = "PQRS";
        keypad[8] = "TUV";
        keypad[9] = "WXYZ";
        keypad[0] = " ";

        StringBuilder result = new StringBuilder();
        int i = 0;

        while (i < input.Length)
        {
            char current = input[i];

            if (current == '#')
                break;

            if (current == '*')
            {
                if (result.Length > 0)
                    result.Length--;
                i++;
                continue;
            }

            if (current == ' ')
            {
                i++;
                continue;
            }

            if (char.IsDigit(current))
            {
                int count = 1;
                while (i + count < input.Length && input[i + count] == current)
                    count++;

                int digit = current - '0';
                string letters = keypad[digit];

                if (!string.IsNullOrEmpty(letters))
                {
                    int index = (count - 1) % letters.Length;
                    result.Append(letters[index]);
                }

                i += count;
            }
            else
            {
                i++;
            }
        }

        return result.ToString();
    }
}
