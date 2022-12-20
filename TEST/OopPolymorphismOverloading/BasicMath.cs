using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OopPolymorphismOverloading;
internal class BasicMath
{
    public int NumberOne { get; set; }
    public int NumberTwo { get; set; }


    //overloading(1 là construstor, 2 là các method) cùng tên chỉ khác tham số hay kiểu của tham số
    //public BasicMath() { }

    //public BasicMath(int numberOne, int numberTwo)
    //{
    //    NumberOne = numberOne;
    //    NumberTwo = numberTwo;
    //}


    //public BasicMath(int numberOne)
    //{
    //    NumberOne = numberOne;
    //}


    //public BasicMath(int numberTwo)
    //{
    //    NumberTwo = numberTwo;
    //}


    //thay vì overloading phương thức Optional argument => đối số truyền cho tham số (Parameter)

    public void sum(int num1 = 0, int num2 = default)
    {
        NumberTwo = num2;
        NumberOne = num1;

        Console.WriteLine(NumberOne + NumberTwo);
    }


    //public void sum(int num1, int num2)
    //{
    //    NumberTwo= num2;
    //    NumberOne= num1;

    //    Console.WriteLine(NumberOne + NumberTwo);
    //}

    //public void sum()
    //{
    //    NumberOne= 0;
    //    NumberTwo= 0;
    //    Console.WriteLine(NumberOne + NumberTwo);

    //}

}
