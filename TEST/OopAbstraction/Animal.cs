using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OopAbstraction;
internal abstract class Animal
{
    //các field (thật chất là các biến toàn cục của riêng class)
    private string fullname;
    private int age;

    //1 phương thức k có body {} => nó là abstrac
    //1 phương thức là abstract kéo theo class là abstract
    public abstract void ShowAni();

}
