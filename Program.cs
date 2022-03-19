using CarClassLibrary;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;

namespace CarShopConsoleApp
{
    class Program
    {
        
        static void Main(string[] args)
        {
            Store s = new Store(); 
            
            Console.WriteLine(" Mağazaya hoşgeldiniz!!");
            Console.WriteLine(" İlk yapmanız gereken kendinize bir envanter oluşturmak.");
            Console.WriteLine(" Sonrasında oluşturduğunuz envarterden sepetinize araba ekleyebilirsiniz.");
            Console.WriteLine(" Arabaları seçtikten ve ekledikten sonra toplam maliyeti göreceksiniz.");

            int action = chooseAction();

            try
            {
                while (action != 0)
                {
                    Console.WriteLine(action + " seçtiniz.");

                    switch (action)
                    {
                        // Envantere Ekle
                        case 1:
                            Console.WriteLine(" Envantere yeni bir araba eklemeyi seçtiniz.");
                            string carMake = "";
                            string carModel = "";
                            Decimal carPrice = 0;

                            Console.WriteLine(" Arabanın markası ne olsun? ford, fiat, opel vs.");
                            carMake = Console.ReadLine();

                            Console.WriteLine(" Arabanın modeli nedir? focus, egea, astra vs. ");
                            carModel = Console.ReadLine();

                            Console.WriteLine(" Arabanın fiyatı nedir?");
                            carPrice = int.Parse(Console.ReadLine());

                            Car newCar = new Car(carMake, carModel, carPrice);
                            s.CarList.Add(newCar);


                            // json dönüşümü için önce programın çalışıp girdi alması gerekir.
                            System.IO.File.WriteAllText(@"D:\cars_data.json", JsonConvert.SerializeObject(newCar));

                            printInventory(s);
                            break;

                        //Sepete ekle
                        case 2:
                            Console.WriteLine(" Sepete araba eklemeyi seçtiniz. ");
                            printInventory(s);
                            Console.WriteLine(" Hangi arabayı almak istersiniz ? ");
                            int carChosen = int.Parse(Console.ReadLine());

                            s.ShoppingList.Add(s.CarList[carChosen]);

                            printShoppingCart(s);

                            break;
                        case 3:
                            printShoppingCart(s);
                            Console.WriteLine("Seçtiğiniz arabaların toplam maliyetleri = " + s.Checkout());
                            break;
                        default:
                            break;

                    }
                    action = chooseAction();

                }
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("Hatalı giriş yaptınız.");
                throw;
            }
            
        }

        private static void printShoppingCart(Store s)
        {
            Console.WriteLine(" Satın almak istediğiniz arabalar: ");
            for (int i = 0; i < s.ShoppingList.Count; i++)
            {
                Console.WriteLine(" Araba # " + i + " " + s.ShoppingList[i]);
            }
        }

        private static void printInventory(Store s)
        {
            for(int i = 0; i< s.CarList.Count; i++)
            {
                Console.WriteLine(" Araba # " + i + " "+s.CarList[i]);
            } 
        }

        static public int chooseAction()
        {
            int choice = 0;
            Console.WriteLine(" Ne yapmak istediğinizi seçin çıkmak için (0) envantere yeni araba eklemek için (1) sepete eklemek için (2) kontrol için (3)");

            choice = int.Parse(Console.ReadLine());
            return choice;
        }
        
    }
     
}
