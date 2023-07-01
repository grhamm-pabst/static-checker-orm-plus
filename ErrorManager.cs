using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Static_Checker
{
    internal static class ErrorManager
    {
        public static void throwError(string message)
        {
            Console.WriteLine($"ERROR: {message}");
            Console.ReadLine();
            throw new Exception($"ERROR: {message}");
        }
    }
}
