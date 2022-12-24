using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OopPolymorphismInterface;
internal class ManyFile : IBinaryFile, ITextFile
{
    //bỏ đi bổ từ truy cập sau đó thêm tên interface phía trước
    void IBinaryFile.ReadFile() => Console.WriteLine("Read file");
    void ITextFile.ReadFile() => Console.WriteLine("Read file");


    public void WriteBinaryInterface() => Console.WriteLine("write binary file");


    public void WriteTextFile() => Console.WriteLine("Write text file");
}
