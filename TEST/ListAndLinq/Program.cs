using ListAndLinq;
using System.Collections;
using System.Text;

Console.InputEncoding = Encoding.Unicode;
Console.OutputEncoding = Encoding.Unicode;

List<Student> students = new()
{
    new Student() {Id= 1, Name="Toan", Gender= true, DOB= new DateTime(2003,09,27)},
        new Student() {Id= 2, Name="Nghi", Gender= true, DOB= new DateTime(2003,09,27)},
    new Student() {Id= 3, Name="Thang", Gender= true, DOB= new DateTime(2003,09,27)},
};


//duyệt list qua vòng lập foreach
//foreach (var stu in students)
//{
//    Console.WriteLine(stu);
//}

////vòng lặp foreach sẽ chuyển thành 
//IEnumerator enu = students.GetEnumerator();
//while (enu.MoveNext())
//{
//    Console.WriteLine(enu.Current.ToString());
//}

//duyệt qua list

students.ForEach(Console.WriteLine);

//linq => language integrated query
//linq to sql => website thay thế cú pháp sql trong c#
//linq to object => consle
//sql => select from where group by having order by
//c# => FROM WHERE GROUP BY HAVING ORDER BY...SELECT
//linq có 2 dạng
//style 1 => query syntax => dựa theo cú pháp của sql, dễ học, dễ dùng
//style 2 => method syntax => dựa theo lambda => khó hoc, khó dùng, nhưng cực nhanh



//hiển thị toàn bộ thông tin sinh viên trong list với điều kiện id phải lớn hơn 2
//foreach (var stu in students)
//{
//    if(stu.Id > 2)
//    {
//        Console.WriteLine(stu);
//    }
//}


// style 1 của linq: query syntax
//var t = from stu in students
//        where stu.Id > 2 
//        select stu;
//foreach(var i in t)
//{
//    Console.WriteLine(i);
//}

////style 1 của linq nhưng thu gọn
//foreach (var i in from stu in students
//                  where stu.Id > 2
//                  select stu)
//{
//    Console.WriteLine(i);
//}

//style 2 của linq: method syntax
var t = students.Where(stu => stu.Id > 2);
foreach (var i in t)
{
    Console.WriteLine(i);
}

//style 2 rút gọn
foreach (var i in students.Where(stu => stu.Id > 2))
{
    Console.WriteLine(i);
}

//kết hợp với foreach của list
students.Where(stu => stu.Id > 2).ToList().ForEach(Console.WriteLine);