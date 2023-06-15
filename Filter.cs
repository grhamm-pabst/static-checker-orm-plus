using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Static_Checker
{
    internal class Filter
    {
        public List<char> validCharacters = new List<char>() { '_', ' ', '$', '%', '=', '>', '<', '!', '#', '?', ';', ':', ',', '{', '}', '[', ']', '(', ')', '*', '-', '+', '/', '.' };

        public bool isValid(char c)
        {
            return char.IsLetterOrDigit(c) || validCharacters.Contains(c);
        }

        public string filterFromString(string input)
        {
            IEnumerable<char> filteredString = input.Where(c => isValid(c));
            return new string(filteredString.ToArray());
        }
    }
}
