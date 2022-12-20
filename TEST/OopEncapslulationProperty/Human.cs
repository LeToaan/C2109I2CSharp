using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OopEncapslulationProperty;
internal class Human
{
    //field (phải là private)
    private string fullname ;

    //các thuộc tính phải có bổ từ truy cập là public
    //public string Fullname {
    //    set { fullname = value; }
    //    get { return fullname; }
    //}

    //cách rút gọn
    //public string Fullname
    //{
    //    set => Fullname1 = value; 
    //    get => fullname;
    //}

    //dùng tool
    //property => dùng cho mobile
    public string Fullname1 { get => fullname; set => fullname = value; }

    //auto - property => dập cái field thành thuộc tính
    public string Address { get; set; }


    //public void SetFullname(string fullname)
    //{
    //    this.fullname = fullname;
    //}
    //public string GetFullname()
    //{
    //    return fullname;
    //}
}
