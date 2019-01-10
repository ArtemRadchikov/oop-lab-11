using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oop_lab_11 
{
    class Car : IComparable
    {
        public int CompareTo(object o)
        {
            Car p = o as Car;
            if (p != null)
            {
                return this.Year.CompareTo(p.Year);
            }
            else
                throw new Exception();
        }
        

        private readonly int id;
        private string make;
        private string model;
        private short year;
        private string color;
        private int price;
        private short registNumber;
        static private int counter;
        private bool status;
        private const int constForCash = 259;

        private int age;

        /*свойства (get, set) – для всех поле класса (поля класса должны быть закрытыми);
         * Для одного из свойств ограните доступ по set */

        public int Id => id;

        public string Model { get => model; set => model = value; }
        public string Make { get => make; set => make = value; }
        public short Year { get => year; set => year = value; }
        public string Color { get => color; set => color = value; }
        public short RegistNumber { get => registNumber; private set => registNumber = value; }
        public int Price { get => price; set => price = value; }
        public bool Status { get => status; set => status = value; }
        public static int Counter { get => counter; set => counter = value; }
        public int Age { get => age; set => age = value; }

        //Не менее трех конструкторов (с параметрами  и без, а также с параметрами по умолчанию );

        public Car(string make, string model, short year, string color, int price)
        {
            this.Make = make;
            this.Model = model;
            this.Year=year;
            this.Color = color;
            this.Price = price;
            RegistNumber = 1111;
            id = GetHashCode();
            counter++;
            this.Age = DateTime.Now.Year - (int)year;
        }

        //с пареметрами (всеми)
        public Car(string make, string model, short year, string color, int price, short registNumber)
        {
            this.Make = make;
            this.Model = model;
            this.Year = year;
            this.Color = color;
            this.Price = price;
            this.RegistNumber = registNumber;
            id = GetHashCode();
            counter++;
        }

        //c параметрами по умолчанию
        public Car(string make = "non")
        {
            this.Make = make;
            Model = "non";
            Year = 2000;
            Color = "white";
            Price = 103232;
            RegistNumber = 1111;
            id = GetHashCode();
            counter++;
        }

        //статический конструктор (конструктор типа);
        static Car()
        {
            //не должен иметь параметров
            Console.WriteLine("Вызван статический конструктор, так как cоздан первый объект\n");
            counter = 0;
        }

        //определите закрытый конструктор; предложите варианты его вызова

        //private Car() { }

        /*в одном из методов класса для работы с аргументами используйте ref - и out-параметры*/

        public void GetdisplayAgeOfMachine(ref int quality)
        {
            int age;
            string ageStr;
            DateTime date = DateTime.Now;//изменить в ref


            if (year == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Нельза высчитать возраст машины\n");

                return;
            }

            age = (int)(date.Year - year);
            if (age <= 1)
            {
                if (age == 1)
                {
                    ageStr = "год";
                }
                else
                {
                    ageStr = "лет";
                }
            }
            else
            {
                if (age < 5)
                {
                    ageStr = "года";
                }
                else
                {
                    ageStr = "лет";
                }
            }

            if (age > quality)
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
            }
            Console.WriteLine($"Возраст машины: {age} {ageStr}\n");
            Console.ForegroundColor = ConsoleColor.Gray;

            if (age <= quality)
            {
                status = true;
            }
            else
            {
                status = false;
            }

        }

        /*создайте в классе статическое поле, 
         * хранящее количество созданных объектов (инкрементируется в конструкторе) 
         * и статический метод вывода информации о классе. */

        static public void PrintInformation()
        {
            Console.WriteLine("Кол-во созданых элементов: {0}", counter);
        }

        public override int GetHashCode()
        {
            int hash;
            if (Price == 0)
            {
                Price = 10000;
            }
            hash = (int)(RegistNumber / constForCash + Year / 11 + Price / constForCash / constForCash);
            return hash;
        }

        public override bool Equals(object obj)
        {
            if (obj.ToString() == this.model)
            {
                return true;
            }
            else
                return false;
        }

        public override string ToString()
        {
            string str= Price+"";
           
            return Make+" "+Model+" "+Year+" "+Color+" "+Price;
        }

        





        //-------класс partial 
        public partial class Part
        {
            int a;
        }
        public partial class Part
        {
            //public string name; 
            public string Name { get; set; }

            public Part(int a)
            {
                this.a = a = 10;
            }

            public void PartMethod()
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"\n\nИспользование класса partial: \n{a}");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
        //-----------------
    }
}
