using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exam_QLSV.DATA;
using Exam_QLSV.UI;

namespace Exam_QLSV;
internal class MainSV : ISinhVien
{
    List<SinhVien> list = new();
    public void AddStu()
    {
        bool run = true;
        while(run)
        {
            Console.WriteLine("Amount add: ");
            string str = Console.ReadLine();
            bool abc = Int32.TryParse(str, out int i);
            if (abc)
            {   
                for(int a = 0; a < i; a++)
                {
                    Console.WriteLine($"Student {a+1}: ");
                    SinhVien sv = new();
             
                    sv.Input();
                    list.Add(sv);
                    

                }
                run= false;
            }
            else { Console.WriteLine("Please, input number!");  }
        }
       
       
        
       
    }

    public virtual void RemoveStu()
    {
        int i =0;
        Console.WriteLine("Input number id you want delete: ");
        string str = Console.ReadLine();
        i = int.Parse(str);
        bool a = Int32.TryParse(str, out i);
        if (a)
        {
            foreach (var value in from stu in list where stu.Id == i select stu)
            {
                list.Remove(value);
            }
            foreach (var stu in from stu in list select stu)
            {
                Console.WriteLine(stu);
            }

        }
        else
        {
            Console.WriteLine("Delete error!");
        }
       
       




    }

    public virtual void SearchStu()
    {
        throw new NotImplementedException();
    }

    public void ShowAllList()
    {
        foreach(var stu in from stu in list select stu)
        {
            Console.WriteLine(stu);
        }
    }

    public virtual void SortList()
    {
        throw new NotImplementedException();
    }

    public virtual void UpdateStu()
    {
        throw new NotImplementedException();
    }
}
