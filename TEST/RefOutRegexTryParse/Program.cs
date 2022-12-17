

//int a = 10;
//int b = 5;

//RefOut.ChangeVar(ref a, ref b);
Console.InputEncoding = Encoding.Unicode;
Console.OutputEncoding = Encoding.Unicode;

RefOut.ChangeVar(out int a, out int b);
Console.WriteLine("main: ");
Console.WriteLine($"{nameof(a)}={a}, {nameof(b)}={b}");

//oop nguyên thủy, thuần oop => c# cũ
//RegexTryParse parse = new RegexTryParse();

////dùng từ var
//var par = new RegexTryParse();

//target-type => c# mới
RegexTryParse p = new();
//p.checkNumberByRegex();
//p.checkStringByTryParse();
p.tryCatchBug();