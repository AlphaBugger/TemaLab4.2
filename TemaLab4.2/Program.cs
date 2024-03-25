using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        string fileName = "input.txt";

        if (!File.Exists(fileName))
        {
            File.WriteAllText(fileName, "apple banana carrot avocado broccoli cabbage blueberry " +
                "apricot pear melon grape plum orange banana watermelon kiwi pineapple " +
                "raspberry blackberry strawberry fig lemon lime peach mango coconut");
        }

        string[] words = File.ReadAllText(fileName).Split(new char[] { ' ', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);

        string[][] wordArrays = new string[26][];

        for (int i = 0; i < 26; i++)
        {
            wordArrays[i] = new string[0];
        }

        foreach (string word in words)
        {
            if (!string.IsNullOrWhiteSpace(word) && char.IsLetter(word[0]))
            {
                int index = char.ToLower(word[0]) - 'a';
                wordArrays[index] = AddToArray(wordArrays[index], word);
            }
        }

        for (int i = 0; i < 26; i++)
        {
            if (wordArrays[i].Length > 0)
            {
                Console.WriteLine($"Componenta {Convert.ToChar('A' + i)}:");
                Console.WriteLine(string.Join(", ", wordArrays[i]));
                Console.WriteLine();
            }
        }
        Console.ReadKey();
    }

    static string[] AddToArray(string[] array, string element)
    {
        Array.Resize(ref array, array.Length + 1);
        array[array.Length - 1] = element;
        return array;
    }
}
