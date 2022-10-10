using System.Text;

namespace StringCalculator_CL
{
    public class StringCalculator
    {
        private List<string> _delimiters = new List<string>
            {
                ",", "\n"
            };
        private readonly int _maxAllowedNumber = 1000;

        public int Add(string input)
        {
            GetCustomDelimiters(input);

            var numbersPortion = GetNumbersPortion(input);

            var numbers = numbersPortion
                .Split(_delimiters.ToArray(), StringSplitOptions.RemoveEmptyEntries)
                .Select(n => int.Parse(n))
                .ToList();

            EnsureNonNegatives(numbers);

            numbers = EnsureMaxAllowedNumberNotExceeded(numbers);

            return numbers.Sum();
        }

        public void GetCustomDelimiters(string input)
        {
            if (!input.StartsWith("//"))
            {
                return;
            }

            var delimitersString = input.Split("\n", 2)[0];

            if (delimitersString[2] != '[')
            {
                var delimiters = new List<string>
                {
                    delimitersString[2].ToString()
                };
                AddCustomDelimitersWithNoDuplicates(delimiters);
            }

            var multipleDelimiters = new List<string>();

            var customDelimiters = delimitersString
                .Substring(2)
                .Split("]")
                .Where(cd => !string.IsNullOrWhiteSpace(cd))
                .Select(cd => cd[1..]
                    .Split("")
                    .First())
                .ToList();

            var customSingleDelimiters = customDelimiters
                .Where(cd => cd.Length > 1)
                .Select(cd => cd
                    .First().ToString())
                .ToList();

            multipleDelimiters.AddRange(customDelimiters);
            multipleDelimiters.AddRange(customSingleDelimiters);

            AddCustomDelimitersWithNoDuplicates(multipleDelimiters);
        }

        public void AddCustomDelimitersWithNoDuplicates(List<string> customDelimiters)
        {
            _delimiters.AddRange(customDelimiters.Where(cd => !_delimiters.Contains(cd)));
        }

        public string GetNumbersPortion(string input)
        {
            if (input.StartsWith("//"))
            {
                return input.Split("\n", 2)[1]; ;
            }

            return input;
        }

        public void EnsureNonNegatives(List<int> input)
        {
            var negativeNumbers = new List<int>();

            var test = input
                .Where(n => n < 0)
                .ToList();

            foreach (var number in input.Where(n => n < 0))
            {
                negativeNumbers.Add(number);
            }

            if (negativeNumbers.Any())
            {
                NonNegativeException.Throw(negativeNumbers);
            }

            return;
        }

        public List<int> EnsureMaxAllowedNumberNotExceeded(List<int> input)
        {
            return input.Where(n => n <= _maxAllowedNumber).ToList();
        }
    }
}