using OopExercise.Dal;
using OopExercise.Extenttion_Method;
using OopExercise.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OopExercise.Menu;
internal class MainMenu
{
    public static void MenuShow()
    {
        DalProduct dal = new DalProduct();
        while (true)
        {
            dal.ChangColor(ConsoleColor.White, ConsoleColor.Blue);

            Console.WriteLine("1. Add");
            Console.WriteLine("2. Show");
            Console.WriteLine("Default exit");
            var n = Validate<int>.Input("Please choose number: ");
            switch (n)
            {
                case 1:
                    dal.ChangColor(ConsoleColor.White, ConsoleColor.Red);
                    dal.AddProduct(); break;
                        case 2:
                    dal.ChangColor(ConsoleColor.White, ConsoleColor.Green);
                    dal.ShowPro(); break;
                default: Console.WriteLine("Exit"); return;
            }

        }
    }
}
