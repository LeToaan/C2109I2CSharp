using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OopExercise.Extenttion_Method;
static class ExtMethod
{
    public static void ChangColor<T>(this T item, params ConsoleColor[] colors)
    {
        Console.BackgroundColor = colors[0];
        Console.BackgroundColor = colors[1];
    }
}
