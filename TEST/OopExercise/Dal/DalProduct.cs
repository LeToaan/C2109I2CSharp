using OopExercise.entity;
using OopExercise.Helper;
using OopExercise.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OopExercise.Dal;
internal class DalProduct : IProduct
{
    public List<Product> list { get; set; } = new List<Product>();

    public void AddProduct()
    {
        var n = Validate<int>.Input("Please enter amount list: ");
        for(int i = 0; i < n; i++)
        {
            Product pro = new();
            pro.Id = Validate<string>.Input("id: ");
            pro.Name = Validate<string>.Input("Name: ");
            pro.Price = Validate<double>.Input("Price: ");
            pro.Quantity = Validate<int>.Input("Quantity: ");
            pro.Mfg = Validate<DateTime>.Input("Date:");
            list.Add(pro);

        }
    }

    public void DeleteProduct()
    {
        throw new NotImplementedException();
    }

    public void ShowPro()
    {
        list.ForEach(Console.WriteLine);
    }

    public void UpdateProdcut()
    {
        throw new NotImplementedException();
    }
}
