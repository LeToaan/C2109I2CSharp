using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OopPolymorphismInterface;
internal class SomeFile : IBinaryFile, ITextFile
{
    //bổ từ phải là public
    public void ReadFile() => Console.WriteLine("Read file");

    public void WriteBinaryInterface() => Console.WriteLine("write binary file");


    public void WriteTextFile() => Console.WriteLine("Write text file");
    
}
