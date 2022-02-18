// See https://aka.ms/new-console-template for more information

using Microsoft.VisualBasic;
using Wordle.CSharp.Backend;
using Wordle.CSharp.Backend.Model;
int numberOfGuessesRemaining = 6;

List<GuessResponse> guessResponses = new List<GuessResponse>();


bool isDone = false;
while (!isDone)
{
    Console.WriteLine($"Please guess a 5 letter word and press enter ({numberOfGuessesRemaining} guesses remaining):");
    string guess = Console.ReadLine();
    Console.Clear();
    // get guess result:
    GuessResponse response = WordleService.CheckWordOfDay(guess);

    if (response.IsIncorrectLength)
    {
        Console.WriteLine("That guess has the wrong length, please retry:");
        continue;
    }
    else if (!response.IsValidWord)
    {
        Console.WriteLine("That word is not valid:");
        continue;
    } else
    {
        guessResponses.Add(response);
        numberOfGuessesRemaining--;
    }

    // output colourful word
    // assuming incorrect length is dealt with above
    foreach (var g in guessResponses)
    {
        var count = 0;
        foreach (var c in g.Guess)
        {
            switch (g.Response[count])
            {
                case GuessEnumeration.INCORRECT:
                    Console.ForegroundColor = ConsoleColor.Gray;
                    break;
                case GuessEnumeration.CORRECT:
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;
                case GuessEnumeration.WRONG_PLACE:
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            Console.Write(c);
            count++;
        }
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.Gray;
    }
   


    Console.WriteLine(response.IsAllCorrect);

    // check if we are done
    isDone = numberOfGuessesRemaining == 0 || guessResponses.Last().IsAllCorrect;
}


