using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nsConsole
{
    public enum Status
    {
        Creating,
        WaitingForPayment,
        Paid,
        Assembling,
        ReadyForDelivery,
        Delivered,
        Received,
        Refund,
        Error
    }
    public abstract class Delivery
    {
        public string Address; 
        public void Move(string name)
        {            
            Console.WriteLine("Заказ {0} для доставки по адресу: {1} у курьера.", name, Address);
        }
    }
    public class Courier
    {        
        public virtual bool Traffic(string route)
        {
            return false;
        }
    }
    public class BikeCourier : Courier
    {
        private string Bike = "TREK";
        public override bool Traffic(string route)
        {            
            return route != Bike;            
        }
        protected double Speed;        
    }
    public class PostCourier : Courier
    {
        public override bool Traffic(string route)
        {
            if (postageStamp)
                Speed = +1;           
            else
                Speed = 0;
            return (Speed > 0);
        }
        public double Speed;       
        private bool postageStamp = false;
    }
    public class CarCourier:Courier
    {
        private string Car = "Lada";
        public override bool Traffic(string route)
        {            
            return route != Car;
        }
        protected double Speed;        
    }
    public class HomeDelivery : Delivery
    {
        private BikeCourier courier;     
        public HomeDelivery()
        {
            courier = new BikeCourier();
            Console.WriteLine("Вы выбрали доставку на дом");
        }
    }
    public class PickPointDelivery : Delivery
    {
        private PostCourier courier;
        public PickPointDelivery()
        {
            courier = new PostCourier();
            Console.WriteLine("Вы выбрали доставку в пункт выдачи");
        }
    }
    public class ShopDelivery : Delivery
    {
        private CarCourier courier;
        public ShopDelivery()
        {
            courier = new CarCourier();
            Console.WriteLine("Вы выбрали доставку в магазин");
        }
    }

    public abstract class Product
    {
        public string Name;
        public decimal Price { get; set; }
    }
    public class ProductTools : Product
    {
        public ProductTools(string name, decimal price, string description)
        {
            this.Name = name ?? "неизвестный товар";
            this.Price = price > 0 ? price : 1;
            this.Description = description ?? "инструмент";
        }
        public string Description { get; set; }
    }
    public class ProductGames : Product
    {
        public ProductGames(string name, decimal price, bool multiuser)
        {
            this.Name = name ?? "неизвестный товар";
            this.Price = price > 0 ? price : 1;
            this.MultiUser = multiuser;
        }
        public bool MultiUser;
    }
    public class ProductFood : Product
    {
        public ProductFood(string name, decimal price, double mass, int dateexpiration)
        {
            this.Name = name ?? "неизвестный товар";
            this.Price = price > 0 ? price : 1;
            this.Mass = mass > 0 ? mass : 1;
            this.DateCreate = DateTime.Now;
            this.DateExpiration = DateCreate.AddMonths(dateexpiration);

        }
        public double Mass { get; set; }
        public DateTime DateCreate;
        public DateTime DateExpiration;
    }
    public class Order<TDelivery,TProduct> where TDelivery : Delivery where TProduct: Product
    {
        public TDelivery MyDelivery { get; set; }
        public TProduct MyProduct { get; set; }
        public Order(TDelivery delivery, TProduct myProduct, double _count)
        {
            MyDelivery = delivery;
            MyProduct = myProduct;
            GlobalID += 1;
            id = GlobalID;
            StatusOrder = Status.Creating;
            Count = _count;
        }
        public Status StatusOrder;
        public double Count { get; set; } 
        public static int GlobalID = 0;
        private int id;
        public int ID { get { return id; } }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            //Создание товаров в магазине
            Product tools = new ProductTools("лопата", 500m, "садовый инвентарь");
            Product games = new ProductGames("шашки", 800m, true);
            Product foods = new ProductFood("молоко", 75m, 1, 24);
            ArrayList MyOrder = new ArrayList();
            
            //Выбор способа доставки заказа
            Delivery myDelivery = new HomeDelivery();
            //Оформление заказа
            Order < Delivery, Product> order = new Order<Delivery, Product>(myDelivery, tools, 2);
            order.MyDelivery.Address = "\'а/я 500\'";            
            order.MyDelivery.Move(order.MyProduct.Name);            
            MyOrder.Add(order);

            myDelivery = new PickPointDelivery();            
            order = new Order<Delivery, Product>(myDelivery, games,1);
            order.MyDelivery.Address = "\'На деревню дедушке\'";           
            order.MyDelivery.Move(order.MyProduct.Name);
            MyOrder.Add(order);

            myDelivery = new ShopDelivery();
            order = new Order<Delivery, Product>(myDelivery, foods,7);
            order.MyDelivery.Address = "\'OZON\'";
            order.MyDelivery.Move(order.MyProduct.Name);
            MyOrder.Add(order);

            Console.ReadKey();
        }
    }
}
        #region 5.6.1
        //static string[] ArrayInputFromConsole(in int countArr, string textMessage)
        //{
        //    var ArrayOut = new string[countArr];
        //    for (int i = 0; i < countArr; i++)
        //    {
        //        Console.WriteLine(textMessage);
        //        ArrayOut[i] = Console.ReadLine();
        //    }
        //    return ArrayOut;
        //}
        //static bool CheckEnter(in string sData, out int iData)
        //{
        //    iData = 0;
        //    return Int32.TryParse(sData, out iData);
        //}
        //static (string FirstName, string LastName, int Age, int CountPet, string[] NamePet, int CountColor, string[] NameColor) GetInfoOwnerAndPet()
        //{
        //    (string FirstName, string LastName, int Age, int CountPet, string[] NamePet, int CountColor, string[] NameColor) IOAP;

        //    Console.WriteLine("Введите свое имя:");
        //    IOAP.FirstName = Console.ReadLine();

        //    Console.WriteLine("Введите свою фамилию:");
        //    IOAP.LastName = Console.ReadLine();

        //    Console.WriteLine("Введите свой возраст:");
        //    string inputString = Console.ReadLine();                                    
        //    while(!CheckEnter(inputString, out IOAP.Age) || (IOAP.Age == 0))
        //    {
        //        Console.WriteLine("Введите свой возраст:");
        //        inputString = Console.ReadLine();
        //    }            
            
        //    Console.WriteLine("У Вас есть питомец? Y/N");
        //    if (Console.ReadLine().ToUpper().Equals("Y"))
        //    {
        //        Console.WriteLine("Введите количество питомцев:");
        //        inputString = Console.ReadLine();
        //        while (!CheckEnter(inputString, out IOAP.CountPet) && (IOAP.CountPet > 0))
        //        {
        //            Console.WriteLine("Вы подтвердили, что у Вас есть питомцы, напишите их количество цифрами:");
        //            inputString = Console.ReadLine();
        //        }
        //    }
        //    else
        //        IOAP.CountPet = 0;

        //    IOAP.NamePet = ArrayInputFromConsole(IOAP.CountPet, "Введите кличку питомца:");
        //    Console.WriteLine("Введите количество любимых цветов:");            
        //    inputString = Console.ReadLine();
        //    while (!CheckEnter(inputString, out IOAP.CountColor) && (IOAP.CountColor > 0))
        //    {
        //        Console.WriteLine("Напишите количество цифрами:");
        //        inputString = Console.ReadLine();
        //    }
        //    IOAP.NameColor = ArrayInputFromConsole(IOAP.CountColor, "Напишите название любимого цвета:");

        //    return IOAP;            
        //}
        //static void ShowMessageToConsole((string FirstName, string LastName, int Age, int CountPet, string[] NamePet, int CountColor, string[] NameColor) IOAP)
        //{
        //    Console.WriteLine($"Анкета {IOAP.FirstName} {IOAP.LastName}");
        //    Console.WriteLine($"Возраст {IOAP.Age} \n Количество питомцев {IOAP.CountPet} \n Клички питомцев:");
        //    foreach(string nickname in IOAP.NamePet)
        //    {
        //        Console.WriteLine(nickname + "\n");
        //    }
        //    Console.WriteLine("Любимые цвета:");
        //    foreach (string colorname in IOAP.NameColor)
        //    {
        //        Console.WriteLine(colorname + "\n");
        //    }
        //}
        
        //static void Main(string[] args)
        //{
        //    ShowMessageToConsole(GetInfoOwnerAndPet());
        //    Console.WriteLine("Для выхода из программы нажмите любую клавишу");
        //    Console.ReadKey();
        //    #region
        //    //for (int i = 5; i > 1; i--)
        //    //{
        //    //    Console.WriteLine("Iteration {0}", i);
        //    //    switch (Console.ReadLine())
        //    //    {
        //    //        case "red":
        //    //            Console.BackgroundColor = ConsoleColor.Red;
        //    //            Console.ForegroundColor = ConsoleColor.Black;

        //    //            Console.WriteLine("Your color is red!");
        //    //            break;

        //    //        case "green":
        //    //            Console.BackgroundColor = ConsoleColor.Green;
        //    //            Console.ForegroundColor = ConsoleColor.Black;

        //    //            Console.WriteLine("Your color is green!");
        //    //            break;

        //    //        case "cyan":
        //    //            Console.BackgroundColor = ConsoleColor.Cyan;
        //    //            Console.ForegroundColor = ConsoleColor.Black;

        //    //            Console.WriteLine("Your color is cyan!");
        //    //            break;
        //    //        default:
        //    //            Console.BackgroundColor = ConsoleColor.Yellow;
        //    //            Console.ForegroundColor = ConsoleColor.Black;

        //    //            Console.WriteLine("Your color is yellow!");
        //    //            break;
        //    //    }
        //    //}
        //    //Console.WriteLine("Your ");
        //    //Console.WriteLine("Your ");
        //    //Console.WriteLine("Your ");
        //    //Console.WriteLine("Your ");

        //    //Console.ReadKey();
        //    //var name = "";
        //    //var age = 0;
        //    //Console.WriteLine("What is your name?");
        //    //name = Console.ReadLine();
        //    //Console.WriteLine("What is your age?");

        //    //var res = int.TryParse(Console.ReadLine(), out age);

        //    //while (!res)
        //    //{
        //    //    Console.WriteLine("What is your age?");
        //    //    res = int.TryParse(Console.ReadLine(), out age);
        //    //}
        //    //if (age > 200)
        //    //{
        //    //    Console.WriteLine("Your name is Dinosaur {0} and age is {1} ", name, age);

        //    //}
        //    //else
        //    //{
        //    //    Console.WriteLine("Your name is {0} and age is {1} ", name, age);
        //    //}
        //    //Console.Write("Write your birthday ");
        //    //var day = Console.ReadLine();
        //    //Console.WriteLine("Your birthday is {0}", day);
        //    //Console.ReadKey();
        //    #endregion
        //}
        #endregion      
