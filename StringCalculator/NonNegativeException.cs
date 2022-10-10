using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculator_CL
{
    public class NonNegativeException : Exception
    {
        public NonNegativeException(string error) : base(error)
        {
        }

        public static void Throw(List<int> numbers)
        {
            var errorMessage = $"Negative numbers not allowed: {string.Join(", ", numbers)}";
            throw new NonNegativeException(errorMessage);
        }
    }
}