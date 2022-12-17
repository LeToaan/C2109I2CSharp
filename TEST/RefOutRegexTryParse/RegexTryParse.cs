


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

    public void tryCatchBug()
    {
        Console.WriteLine("Vui long nhap so luong: ");
        string? amount = Console.ReadLine();

        try
        {
            int total = int.Parse(amount);
            if(total <=0)
            {
                throw new Exception("Phai lon hon 0");
            }
        }
        catch (Exception) when (amount.Contains("$")){
            Console.WriteLine("k dc co dau $");
        }
        catch(Exception e)
        {
            //Console.WriteLine(e.GetType()+ " : "+ e.Message);
            Console.WriteLine($"{e.GetType()} : {e.Message}");
        }
    }
}
