using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OopAbstraction;
//kế thừa dùng dấu :
internal abstract class Cat : Animal
{
    //con kế thừa cha mà cha là abstract, con phải thực thi lại các phương thức mà cha abstract, nếu không con cũng là abstract
    private bool gender;
    //1 phương thức mà chỉ có 1 câu lệnh thì chuyển sang expession body
    public void showCat() => Console.WriteLine("This is a cat: ");
    
        
    
}
