using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OopPolymorphismInterface;
internal interface IBinaryFile

{
    //không dùng bổ từ truy cập (access modify)
    void WriteBinaryInterface();
    void ReadFile();
    //có phương thức mặc đinh tồn tại trong interface
    void showInfo() => Console.WriteLine("this is binary");
}
