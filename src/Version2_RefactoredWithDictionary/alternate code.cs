using System;
using System.Collections.Generic;
using System.Text;

class Program
{
    static void Main()
    {
        Console.WriteLine("Please input keypad sequence (* = backspace, # = end):");
        string? inputString = Console.ReadLine();

        // Validate input: must not be null/empty and must contain '#'
        if (string.IsNullOrWhiteSpace(inputString) || !inputString.Contains('#'))
        {
            Console.WriteLine("Invalid input");
            return;
        }

        string result = OldPhonePad(inputString);
        Console.WriteLine("Output: " + result);
    }

    public static string OldPhonePad(string input)
    {
        input = TruncateAtHash(input); // Truncate the string at the first occurrence of '#'
        input = ManageStarForBackspaces(input); // Remove each '*' and the character immediately before it

        List<string> groupedDigits = GroupSameDigits(input); // Group consecutive identical digits
        return ConvertToText(groupedDigits); // Convert digit groups into final text based on keypad mapping
    }

    #region Common Methods

    // Truncates the input at the first '#' character
    private static string TruncateAtHash(string input)
    {
        int index = input.IndexOf('#');
        return index >= 0 ? input.Substring(0, index) : input;
    }

    // Handles backspace logic: removes '*' and the character before it
    private static string ManageStarForBackspaces(string input)
    {
        var result = new StringBuilder();
        foreach (char c in input)
        {
            if (c == '*')
            {
                if (result.Length > 0)
                    result.Length--; // Remove the last character
            }
            else
            {
                result.Append(c);
            }
        }
        return result.ToString();
    }

    // Groups consecutive identical digits into strings
    private static List<string> GroupSameDigits(string input)
    {
        List<string> groups = new List<string>();
        if (string.IsNullOrEmpty(input)) return groups;

        char current = input[0];
        var sb = new StringBuilder(current.ToString());

        for (int i = 1; i < input.Length; i++)
        {
            if (input[i] == current)
            {
                sb.Append(input[i]); // Accumulate same digits
            }
            else
            {
                groups.Add(sb.ToString()); // Save current group
                current = input[i];
                sb.Clear();
                sb.Append(current);
            }
        }

        groups.Add(sb.ToString()); // Add the final group
        return groups;
    }

    // Converts grouped digits to text using old-style phone keypad mapping
    private static string ConvertToText(List<string> digitGroups)
    {
        var phoneKeys = new Dictionary<char, string>
        {
            {'2', "ABC"}, {'3', "DEF"}, {'4', "GHI"},
            {'5', "JKL"}, {'6', "MNO"}, {'7', "PQRS"},
            {'8', "TUV"}, {'9', "WXYZ"}, {'0', " "}
        };

        var result = new StringBuilder();

        foreach (var group in digitGroups)
        {
            if (string.IsNullOrEmpty(group))
                continue;

            char key = group[0];
            int count = group.Length;

            if (phoneKeys.TryGetValue(key, out string? letters))
            {
                int index = (count - 1) % letters.Length; // Wrap around if count > letter options
                result.Append(letters[index]);
            }
        }

        return result.ToString();
    }

    #endregion
}
