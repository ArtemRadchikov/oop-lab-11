using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oop_lab_11
{
    class Program
    {
        static void Main(string[] args)
        {

            #region Task 1

            int counter = 0;

            string[] StringArray = new string[] { "january", "february", "march", "april", "may", "june", "july", "august", "september", "october", "november", "december" };

            foreach(string i in StringArray)
            {
                Console.Write(i+"   ");
            }
            Console.WriteLine();

            //запрос возвращающий последовательность месяцев с длиной строки равной n
            int N = 5;
            IEnumerable<string> ArrayLongNStrings = StringArray.Where(n => n.Length == N).Select(n => n);

            printResult(ArrayLongNStrings);

            //запрос возвращающий только летние и зимние месяцы

            IEnumerable<string> ArrayOfSummerAndWinterMonth = from str in StringArray
                                                              where str.StartsWith("j")|| str.StartsWith("f") 
                                                              || str.StartsWith("au") || str.StartsWith("d")
                                                              select str;
            printResult(ArrayOfSummerAndWinterMonth);

            // запрос вывода месяцев в алфавитном порядке

            IEnumerable<string> monthsAlphabetically = StringArray.OrderBy(t=>t);

            printResult(monthsAlphabetically);

            //запрос  считающий месяцы содержащие букву «u» и длиной имени не менее 4-х

            var MonthCount = StringArray
                            .Where(p => p.Length >= 4 && p.Contains("u"))
                            .Count();

            Console.WriteLine(MonthCount);

            void printResult(IEnumerable<string> arrayOfObjects)
            {
                Console.ForegroundColor = ConsoleColor.Blue+counter;
                foreach (var i in arrayOfObjects)
                {
                    Console.Write(i + "   ");
                }
                Console.ResetColor();
                Console.WriteLine();
                counter++;
            }
            #endregion

            #region Task 2-3

            List<Car> cars = new List<Car>
            {
                new Car { Make="Pejeo",Model="E23",Year=2011,Color="red",Price=15245},
                new Car { Make="Pejeo",Model="E85",Year=2001,Color="red",Price=1245},
                new Car { Make="BMW",Model="E23",Year=2009,Color="red",Price=152335},
                new Car { Make="Mersedes",Model="E556",Year=2014,Color="blue",Price=14445},
                new Car { Make="BMW",Model="E23",Year=2005,Color="green",Price=12},
                new Car { Make="Mersedes",Model="E3",Year=2015,Color="green",Price=15552},
                new Car { Make="BMW",Model="Ad3",Year=2017,Color="green",Price=1524},

            };

            Console.ResetColor();
            Console.WriteLine("\nСписок автомобилей заданной марки;");
            IEnumerable<Car> ListOfMokes = cars.Where(p => p.Make == "Pejeo");
            Console.ForegroundColor = ConsoleColor.Blue + counter++;
            foreach (var i in ListOfMokes)
            {
                Console.WriteLine(i);
            }

            Console.ResetColor();
            Console.WriteLine("\nСписок автомобилей заданной модели, которые эксплуатируются больше n лет;"); 
            IEnumerable<Car> ListOfCarsMoselsAndYersMoreThan = cars.Where(p => p.Model == "E23" && DateTime.Now.Year-p.Year > 5);
            Console.ForegroundColor = ConsoleColor.Blue + counter++;
            foreach (var i in ListOfCarsMoselsAndYersMoreThan)
            {
                Console.WriteLine(i);
            }

            Console.ResetColor();
            Console.WriteLine("\nКоличество автомобильной заданного цвета и диапазона цены ");
            var CountByColorAndValueOfPrice = cars.Count(p => p.Color == "red" && p.Price > 1_000 && p.Price < 100_000);
            Console.ForegroundColor = ConsoleColor.Blue + counter++;
            Console.WriteLine(CountByColorAndValueOfPrice);

            Console.ResetColor();
            Console.WriteLine("\nСамый старый автомобиль");
            Car TheOldestCar = cars.Min(p => p);

            Console.ForegroundColor = ConsoleColor.Blue + counter++;
            Console.WriteLine(TheOldestCar);

            Console.ResetColor();
            Console.WriteLine("\nПервых пять самых новых автомобилей");
            IEnumerable<Car> Take5TheNews = cars.OrderByDescending(p => p.Year).Take(5);
            counter = 0;

            Console.ForegroundColor = ConsoleColor.Blue + counter++;
            foreach (Car i in Take5TheNews)
            {
                Console.WriteLine(i);
            }

            IEnumerable<Car> SortedByPrice = cars.OrderBy(p => p.Price);

            Console.ResetColor();
            Console.WriteLine("\nУпорядоченный массив по цене  ");

            Console.ForegroundColor = ConsoleColor.Blue + counter++;
            foreach (Car i in SortedByPrice)
            {
                Console.WriteLine(i);
            }
            Console.ResetColor();
            #endregion

            #region Task 4
            Console.WriteLine("Придумайте и напишите свой собственный запрос, в котором было бы не менее 5 операторов из разных категорий: условия, проекций, упорядочивания, группировки, агрегирования, кванторов и разбиения.");
            Console.WriteLine();

            cars.Add(new Car { Make = "Pejeo", Model = "E23", Year = 2011, Color = "green", Price = 1545 });
            cars.Add(new Car { Make = "Pejeo", Model = "E22", Year = 2011, Color = "red", Price = 15245 });
            cars.Add(new Car { Make = "Pejeo", Model = "213", Year = 2011, Color = "blue", Price = 1523345 });
            cars.Add(new Car { Make = "Pejeo", Model = "r423", Year = 2011, Color = "red", Price = 3445 });
            cars.Add(new Car { Make = "Pejeo", Model = "D23", Year = 2011, Color = "grey", Price = 345 });
            Console.ResetColor();

            var task5 = cars.Where(p => p.Make == "Pejeo")
                .GroupBy(p => p.Color)
                .Select(g => new
                {
                    Color = g.First().Color,
                    Count = g.Count(),
                    Elements = g.Select(p => p),
                    ContainsModel = g.Any(p => p.Model == "E23")
                });                    

            foreach(var groups in task5)
            {
                Console.WriteLine("Цвет: {0} всего: {1} есть модель E23:{2}",groups.Color,groups.Count,groups.ContainsModel);
                foreach(var element in groups.Elements)
                {
                    Console.WriteLine(element);
                }
                Console.WriteLine(  );
            }
            #endregion
            #region Task5

            Console.WriteLine("Придумайте запрос с оператором Join ");
            Console.WriteLine();

            List<Color> colors = new List<Color>
            {
                new Color{ColorName="red",color=ConsoleColor.Red},
                new Color{ColorName="green",color=ConsoleColor.Green},
                new Color{ColorName="blue",color=ConsoleColor.Blue},
                new Color{ColorName="grey",color=ConsoleColor.Gray},
            };

            var CarsAndColors = cars.Join(colors,
                p => p.Color,
                t => t.ColorName,
                (p, t) => new { p.Make, p.Model, p.RegistNumber, p.Price, t.color,t.ColorName }).OrderBy(p=>p.Price);

            foreach(var i in CarsAndColors)
            {
                Console.ForegroundColor = i.color;
                Console.WriteLine($"{i.Make} {i.Model} {i.RegistNumber} {i.Price} {i.ColorName}");
            }
            #endregion
        }
        class Color
        {
            public string ColorName;
            public ConsoleColor color;
        }
    }
}
