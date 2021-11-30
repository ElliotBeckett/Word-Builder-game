using System;
using System.Threading;

namespace ShaunChallenge
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("\t\t\t**********************");
            Console.WriteLine("\t\t\tThis is a cool program");
            Console.WriteLine("\t\t\t**********************");

            //Initialising our variables

            //Array of all the letters in the alphabet
            char[] alphabetArr = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z'};
            bool validWord = false;
            string playerWord = String.Empty;
            bool matchedWord = false;
            string builtWord = "";
            int buildAttempts = 0;

            //Setup Random Number Generator
            Random randNum = new Random();

            while (!validWord)
            {
                try
                {
                    Console.Write("Please enter the word you want to test: ");
                    playerWord = Console.ReadLine().ToLower();

                    if (playerWord.Length < 3)
                    {
                        Console.Write("The word you entered is too short \n\nPlease enter a word that is 3 letters long: ");
                    }
                    else
                    {
                        validWord = true;
                    }
                }
                catch (Exception validWordEx)
                {
                    Console.WriteLine("There was an issue with your input and caused an error");
                    Console.WriteLine($"The error generated was {validWordEx.Message} \n\nPlease try again: ");
                }
            }

            char[] wordLetters = playerWord.ToCharArray();

            for (int x = 0; x < wordLetters.Length; x++)
            {
                Console.WriteLine($"{x}: {wordLetters[x]}");
            }

            Console.WriteLine(playerWord.Length - 1);
            Console.WriteLine(wordLetters.Length - 1);

            while (!matchedWord)
            {
                char letterToInsert = ' ';
                
                for (int letterPosition = 0; letterPosition < (wordLetters.Length -1) ; letterPosition++)
                {
                    while ((wordLetters[letterPosition] != letterToInsert))
                    {
                        int randomLetterNumber = randNum.Next(0, alphabetArr.Length);
                        letterToInsert = alphabetArr[randomLetterNumber];

                        string letterToCheck = playerWord[letterPosition].ToString();
                        Console.WriteLine($"\nPosition of the letter we are checking: {letterPosition}");
                        Console.WriteLine($"Letter to check against: {letterToCheck}");
                        Console.WriteLine($"Letter the system generated: {letterToInsert}");

                        if (wordLetters[letterPosition] == letterToInsert)
                        {
                            Console.WriteLine("\nThe letter generated matched our word, adding it to the build");
                            builtWord += letterToInsert;
                            letterPosition++;
                        }
                        else
                        {
                            Console.WriteLine("\nThe letter generated didn't match, let's try again!");
                        }

                        buildAttempts++;
                        Console.WriteLine($"\nBuild number: {buildAttempts} \nWord generated so far: {builtWord}");
                        letterToInsert = ' ';
                        if (builtWord == playerWord)
                        {
                            matchedWord = true;
                            break;
                           
                        }
                        
                    }
                }
                             
            }

            if (matchedWord)
            {
                Console.WriteLine($"\n\n\nWe were able to build your word: {playerWord} \n\nIt took {buildAttempts} attempts to get there");
            }

            //Prevents the console from closing
            Console.ReadKey();
        }//
    }//
}//