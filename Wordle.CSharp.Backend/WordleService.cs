using Wordle.CSharp.Backend.Model;

namespace Wordle.CSharp.Backend
{
    public static class WordleService
    {
        public static string GetWordOfDay()
        {
            return "ratio";
        }

        public static GuessResponse CheckWordOfDay(string guess)
        {
            guess = guess.ToLower();
            GuessResponse response = new GuessResponse();
            if (guess.Length == 5)
            {
                string wordOfTheDay = GetWordOfDay().ToLower();

                for (int i = 0; i < 5; i++)
                {
                    char c = guess[i];

                    // is character in word?
                    int index = wordOfTheDay.IndexOf(c);
                    if (index == -1)
                    {
                        response.Response[i] = GuessEnumeration.INCORRECT;
                        continue;
                    }

                    // is character in the right place?
                    bool isCorrectPlace = guess[i] == wordOfTheDay[i];
                    if (isCorrectPlace)
                    {
                        response.Response[i] = GuessEnumeration.CORRECT;
                    } else
                    {
                        response.Response[i] = GuessEnumeration.WRONG_PLACE;
                    }

                    // do we care if all the letters are correct?
                    response.IsAllCorrect = response.Response.All(e => e == GuessEnumeration.CORRECT);
                }
                
            } else
            {
                response.IsIncorrectLength = true;
            }


            return response;
        }
    }
}