using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OopAbstraction;
internal class Dog : Animal
{
    //thực thi lại cái phương thức của animal
    //buộc phải dùng từ khóa override
    public override void ShowAni()
    {
        Console.WriteLine("This is dog");
    }
}
