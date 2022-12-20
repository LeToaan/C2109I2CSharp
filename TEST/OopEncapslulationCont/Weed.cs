using OopEncapsulation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace OopEncapslulationCont;
internal class Weed : Plant
{
    static void Main(string[] args)
    {
        Weed weed= new Weed();
        weed.Protected();
        weed.ProtectedInternal();
        weed.Public();
        //weed.PrivateProtected();// trong cùng đồ án mới dc dùng
    }

}
