// See https://aka.ms/new-console-template for more information
using Wordle.CSharp.Backend;
using Wordle.CSharp.Backend.Model;
int numberOfGuessesRemaining = 6;

GuessResponse response = new GuessResponse();
response.IsAllCorrect = false;
while (numberOfGuessesRemaining > 0 && !response.IsAllCorrect)
{
    Console.WriteLine($"Please guess a 5 letter word and press enter ({numberOfGuessesRemaining} guesses remaining):");
    string guess = Console.ReadLine();

    // get guess result:
    response = WordleService.CheckWordOfDay(guess);

    if (response.IsIncorrectLength)
    {
        Console.WriteLine("That guess has the wrong length, please retry:");
        continue;
    } else
    {
        numberOfGuessesRemaining--;
    }

    // output colourful word

    Console.WriteLine(response.IsAllCorrect);
}


