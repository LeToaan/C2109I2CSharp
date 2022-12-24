using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtentionMethod;
internal static class ExtentionMethod
{
    //1 class mà là static thì toàn bộ bên trong là static
    public static void checkIsGreaterThan(this int i, int value)
    {
        if (i > value)
        {
            Console.WriteLine($"{i} lon hon {value}");
        }
    }

    public static void Hello(this Program pro)
    {
        Console.WriteLine("haha");
    }
}
