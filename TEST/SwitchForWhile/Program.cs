using System.Collections;
using System.Diagnostics;
using System.Text;


Console.InputEncoding = Encoding.Unicode;
Console.OutputEncoding = Encoding.Unicode;

int number1 = Random.Shared.Next(0,9);
int number2 = Random.Shared.Next(0, 9);
Console.WriteLine($"{nameof(number1)}={number1}, {nameof(number2)}={number2}");
//nameof lấy tên biến để tránh đánh sai tên biến

Console.WriteLine("Vui long nhap dau phep toan: ");
string dau = Console.ReadLine();

switch (dau)
{
    case "+" when number1 > 0 && number2 > 0:
        Console.WriteLine(number1 + number2); break;
    case "-" when number1 >= number2:
        Console.WriteLine(number1 - number2); break;
    case "*": Console.WriteLine(number1 * number2); break;
    case "/" when number2 != 0: 
        Console.WriteLine(number1 / number2); break;
    default: Console.WriteLine("erro");break;
}

//switch expression
Console.WriteLine(
    dau switch { 
    "+" when number1 > 0 && number2 > 0 => number1 + number2,
    "-" when number1 >= number2 => number1 - number2,
    "*" => number1 * number2,
    "/" when number2 != 0 => number1 / number2,
    _=> "hi, i cant"
    }
    );


string[] arrs = { "khai", "tinh", "thang", "huy", "nghi" };

foreach(var arr in arrs)
{
    Console.WriteLine(arr);
}

//int i = 0;
//code loi logic
//while (i< arrs.Length) { 
//    Console.WriteLine(arrs[i]); 
//    i++;
//}

//code dung
//int chieudai = arrs.Length;
//while (i < chieudai)
//{
//    Console.WriteLine(arrs[i]);
//    i++;
//}

//vong lap k su dung bien dem
IEnumerator e = arrs.GetEnumerator();
while (e.MoveNext()) { 
string s = e.Current.ToString();
    Console.WriteLine(s);
}