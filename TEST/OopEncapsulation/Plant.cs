using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OopEncapsulation;
public class Plant
{
    //access modifier => các bổ từ truy cập
    private void Private() => Console.WriteLine("Private");//private chỉ dùng dc trong class
    protected void Protected() => Console.WriteLine("Protected");//protected chỉ dùng dc cho con cháu, kế thừa mới dc sài
    internal void Internal() => Console.WriteLine("Internal");//internal là trong cùng cài project
    private protected void PrivateProtected() => Console.WriteLine("Private Protected");//hoặc là private hoặc là protected thì sẽ sài dc
    protected internal void ProtectedInternal() => Console.WriteLine("Protected internal");//hoặc là protected hoặc là internal thì dc sài
    public void Public() => Console.WriteLine("Public");

    static void Main(string[] args)
    {
        Plant plant = new();
        plant.Private();
        plant.Protected();
        plant.Internal();
        plant.PrivateProtected();
        plant.ProtectedInternal();
        plant.Public();

    }
}
