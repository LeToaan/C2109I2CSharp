
namespace PartialClass;
internal partial class Human
{

    //1 phương thức mà chỉ có 1 câu lệnh 
    //C sharp sẽ k sử dụng phương thức mà dùng expression body => biểu thức dưới dạng phương thức
    public void show() =>
        Console.WriteLine($"{nameof(fullname)}={fullname}");

    public void check() => Console.WriteLine(10 > 5 ? true : false);
}
