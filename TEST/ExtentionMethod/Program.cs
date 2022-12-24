
using ExtentionMethod;
using System.Text;

Console.InputEncoding = Encoding.Unicode;
Console.OutputEncoding = Encoding.Unicode;

Console.WriteLine("Vui long nhan bien i: ");

int i = int.TryParse(Console.ReadLine(), out int result)?result:0;

CheckNumber.checkIsGreaterThan(i, 100);

i.checkIsGreaterThan(100);

Program pro = new();
pro.Hello();