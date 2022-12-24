using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OopPolymorphismOverriding;
internal class Parent
{
    public void show() => Console.WriteLine("Parent show");
    public virtual void display() => Console.WriteLine("Parent display"); //
}
