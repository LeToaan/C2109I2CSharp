using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OopEncapsulation;
internal class Sunflower:Plant
{
    static void Main(string[] args)
    {
        Sunflower sunflower = new();
        sunflower.Protected();//là con nên dc dùng
        sunflower.Internal();//cùng project/assembly nên dc sài
        sunflower.PrivateProtected();//private hoặc protected thì dc sài
        sunflower.ProtectedInternal();//
        sunflower.Public();//
        //sunflower.Private(); private nên k dc sài
    }
}
