using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_QLSV;
internal class SinhVien
{
    public SinhVien()
    {
    }

    public int Id { get; set; }
    public string Name { get; set; }
    public bool Gender { 
        get; set;
    }
    public DateTime DOB { get; set; }

    public void Input()
    {

        bool a = true;
       while(a)
        {
         
            Id = 0;
            int e = Id;
            Console.WriteLine("Input Id: ");
            string str = Console.ReadLine();
            Id = int.Parse(str);
            bool idRegex = Int32.TryParse(str, out e);

            if (idRegex)
                {
                Console.WriteLine($"Id: {str}");
                a = false;
                    }
              else
                    {
                        Console.WriteLine("Error input id!");
                        
                    }
           

       
           }
           a = true;
        while(a)
        {
            Console.WriteLine("Input name: ");
                         Name = Console.ReadLine();
                         if (Name.Length <= 0 || Name.Length >50)
                          {
                                    Console.WriteLine("Error input length name!");
                           }
                            else { Console.WriteLine($"{nameof(Name)}: {Name}"); 
                            a = false;
                         }
             
         }
        
       
        a = true;
        while(a )
        {
            Console.WriteLine("Input gender: ");
            Gender = bool.Parse(Console.ReadLine());
            if (Gender == true) { Console.WriteLine("Gender: Nam"); a = false; }
            else if (Gender == false) { Console.WriteLine("Gender: Nu"); a = false; }
            else{ Console.WriteLine("Error gender!"); }
        }

        Console.WriteLine("Input DOB: ");
        DOB = DateTime.Parse(Console.ReadLine());
        Console.WriteLine($"DOB: {DOB}");
        
        

    }
    public override string ToString()
    {
        return $"{{{nameof(Id)}={Id.ToString()}, {nameof(Name)}={Name}, {nameof(Gender)}={Gender.ToString()}, {nameof(DOB)}={DOB.ToString()}}}";
    }
}
