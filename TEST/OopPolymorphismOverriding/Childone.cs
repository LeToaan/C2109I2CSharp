using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OopPolymorphismOverriding;
internal class Childone : Parent
{
    //viết lại phương thức của cha
    //cha có virtual mới dc ghi đè
    public override void display() => Console.WriteLine("Parent display");

    //nhưng con sẽ dc viết phương thức tên giống cha
    //sẽ thêm từ new
    public new void show() => Console.WriteLine("Parent display");

}
