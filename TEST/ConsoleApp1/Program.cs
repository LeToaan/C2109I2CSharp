using System.Text;


Console.InputEncoding = Encoding.Unicode;
Console.OutputEncoding = Encoding.Unicode;

int number = 10;
double money = 10.5;
bool check = true;
string str = "Toan0";

//trong c sharp thường có 2 dạng kiểu chính:
//1 value type (dạng số) không chưa dc null
//2 là reference type (chuổi, đối tượng) cho phép null;

string name = null;

// code cũ
Nullable<int> a = null; // tất cả các dạng đều dc null


//code mới => nullavle value type
int? b = null;
bool? flag = null;

//if(name != null)
//{
//   Console.WriteLine(true);
//}
//else { Console.WriteLine(false); }

//?: => ternary operator
Console.WriteLine(name != null ? true : false) ;
Console.WriteLine(name is not null ? true : false);
// is not (!=)
//is (==)

//? => null conditional operator
// ? dùng sau đít tên biến, hay đối tượng
//? tương tự (!=), nếu cái gì đó khác null thì lấy cái vế sau
int? length = name?.Length;


//?? => null coalesing operator
// ?? tương tự dấu ==, nếu cái gì đó băng null thì lấy cái vế sau

int? chieudai = name?.Length ?? 10 ;