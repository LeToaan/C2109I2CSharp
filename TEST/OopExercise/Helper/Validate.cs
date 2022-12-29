using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OopExercise.Helper;
internal class Validate<T>
{
    public static T Input(string message)
    {
        var typecode = Type.GetTypeCode(typeof(T));
        var obj = new object();
        bool flag;
        do
        {
            flag = true;
            try
            {
                Console.Write(message);
                var str = Console.ReadLine();
                if (string.IsNullOrEmpty(str))
                {
                    throw new Exception("error, null of empty");
                }
                switch (typecode)
                {
                    case TypeCode.String:
                        obj = str;
                        break;
                    case TypeCode.Int32:
                        obj= Convert.ToInt32(str);
                        if ((int)obj < 0){
                            throw new Exception("Value must be greater than 0");
                        }
                        break;
                    case TypeCode.Double:
                        obj= Convert.ToDouble(str);
                        if ((double)obj < 0)
                        {
                            throw new Exception("Value must be greater than 0");
                        }
                        break;
                    case TypeCode.DateTime:
                        var date = DateTime.TryParseExact(str, new[] {"d/M/yyyy, d-M-yyyy"},
                            new CultureInfo("vi-VN"), 
                            DateTimeStyles.None, out var t)?t: throw new Exception("Date time wrong!");
                        obj = date.Add(DateTime.Now.TimeOfDay);
                        break;
                    
                }
            }
            catch(Exception e) {
                Console.WriteLine($"{e.GetType()} : {e.Message}, Enter again: ");
                throw;
                flag = false;
            }
            
        }while(!flag);
        return (T)obj;
    }
}
