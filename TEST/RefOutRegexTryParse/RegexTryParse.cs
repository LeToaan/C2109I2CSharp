
using System.Text.RegularExpressions;

namespace RefOutRegexTryParse;
internal class RegexTryParse
{
    public void checkNumberByRegex()
    {
        string? str = null;
        Console.WriteLine("Vui long nhap so: ");
        str = Console.ReadLine();
        if (new Regex("^[0-9]+$").IsMatch(str))
        {
            int result = int.Parse(str);
            Console.WriteLine($"{nameof(result)}={result}");
        }
    }

    public void checkStringByTryParse() {
        string? str = null;
        Console.WriteLine("Vui long nhap so: ");
        str = Console.ReadLine();
        if (int.TryParse(str, out int i)) {
            Console.WriteLine($"{nameof(i)}={i}");
        }
    }
}
