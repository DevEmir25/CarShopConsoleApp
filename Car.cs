using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarClassLibrary
{
    public class Car
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public decimal Price { get; set; }
        public Car() // Varsayılan yapıcı
        {
            Make = "henüz belirlenmedi";
            Model = "henüz belirlenmedi";
            Price  = 0.00M;
        }
        public Car(string a, string b, decimal c)
        {
            Make = a;
            Model = b;
            Price = c;
        }
        override public string ToString()
        {
            return "Marka = " + Make + " ,Model = " + Model + " ,Fiyat = " + Price + "tl";
        }
    }
}
