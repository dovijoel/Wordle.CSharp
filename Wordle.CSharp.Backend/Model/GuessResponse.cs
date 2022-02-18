using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wordle.CSharp.Backend.Model
{
    public class GuessResponse
    {
        public GuessEnumeration[] Response { get; set; } = new GuessEnumeration[5];
        public bool IsIncorrectLength { get; set; } = false;
        public bool IsValidWord { get; set; }      
        public bool IsAllCorrect { get; set; }
        public string Guess { get; set; }
    }

    public enum GuessEnumeration
    {
        INCORRECT,
        CORRECT,
        WRONG_PLACE
    }
}
