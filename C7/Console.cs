using System;
using System.Collections.Generic;

namespace C7
{
    public static class Console
    {
        public static void Main(string[] args)
        {
            var f = new Ferrari();
            var p = new Porsche();
            var l = new Lambo();
            var list = new List<IVehicle>() { f, p, l };

            int max = 0;
            var min = GetMinAndMax(list, out max);

            (int min2, int max2) = GetMinAndMax7(list);
            (var min3, var max3) = GetMinAndMax7(list);
            var (min4, max4) = GetMinAndMax7(list);
            var (min5, _) = GetMinAndMax7(list);
            var full = GetMinAndMax7(list);

            // Deconstruct, options
            var (Name, price) = f;


        }
        #region Pattern Matching
        // Overlapping conditional and variable declaration
        private static string GetCarDetails(IVehicle vehicle)
        {
            if (vehicle is Ferrari car)
            {
                if (car.Price > 0)
                {
                    return "The " + car.Name + "costs" + car.Price;
                }
                else
                    return "Nothing to see here";
            }
            var porsche = vehicle as Porsche;
            if (porsche != null)
            {
                if (porsche.Price > 0)
                {
                    return "The " + porsche.Name + "costs" + porsche.Price;
                }
                else
                    return "Nothing to see here";
            }
            var lambo = vehicle as Lambo;
            if (lambo != null)
            {
                if (lambo.Price > 0)
                { // silly quotes & experience
                    return "The " + lambo.Name + "costs" + lambo.Price.ToString() + "It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout. The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters, as opposed to using 'Content here, content here', making it look like readable English. Many desktop publishing packages and web page editors now use Lorem Ipsum as their default model text, and a search for 'lorem ipsum' will uncover many web sites still in their infancy. Various versions have evolved over the years, sometimes by accident, sometimes on purpose (injected humour and the like).";
                }
                else
                    return "Nothing to see here";
            }
            return "Nothing to see here";
        }
        #endregion
        private static string GetCarDetails7(IVehicle vehicle)
        {
            if (vehicle is Ferrari car && car.Price > 0)
            {
                return "The " + car.Name + "costs" + car.Price;

            }

            if (vehicle is Porsche porsche && porsche.Price > 50000)
            {
                return "The " + porsche.Name + "costs" + porsche.Price;

            }
            if (vehicle is Lambo lambo && (lambo.Price > 0))
            {
                return "The " + lambo.Name + "costs" + lambo.Price;
            }
            return "Nothing to see here";
        }

        private static string GetCarDetails7When(IVehicle vehicle)
        {
            switch (vehicle)
            {
                case Ferrari ferrari when ferrari.Price > 0:
                    return $"The {ferrari.Name}costs{ferrari.Price}";
                case Porsche porsche when porsche.Price > 50000:
                    return $"The {porsche.Name}costs{porsche.Price}";
                case Lambo lambo when lambo.Price > 0:
                    return $"The {lambo.Name}costs{lambo.Price}";
                default:
                    return "Nothing to see here";
            }
        }


        #region Tuples
        // Tuple class, memory, type reference and real reference
        // item1, item2
        private static int GetMinAndMax(List<IVehicle> vehicles, out int max)
        {
            int min = int.MaxValue;
            max = int.MinValue;
            foreach (var item in vehicles)
            {
                min = (int)Math.Min(min, item.Price);
                max = (int)Math.Max(max, item.Price);
            }
            return min;
        }
        private static (int min, int max) GetMinAndMax7(List<IVehicle> vehicles)
        {
            int min = int.MaxValue;
            int max = int.MinValue;
            foreach (var item in vehicles)
            {
                min = (int)Math.Min(min, item.Price);
                max = (int)Math.Max(max, item.Price);
            }
            return (min, max);
        }
        #endregion
    }
    public interface IVehicle
    {
        decimal Price { get; set; }
        string Name { get; set; }
        Speeds Speed { get; set; }

    }

    public class Ferrari : IVehicle
    {
        public Ferrari()
        {
            Price = 555000000;
            Name = "Ferrari";
            Speed = Speeds.Fast;
        }
        public decimal Price { get; set; }
        public string Name { get; set; }
        public Speeds Speed { get; set; }
        public void Deconstruct(out string name, out decimal price)
        {
            name = Name;
            price = Price;
        }
    }
    public class Porsche : IVehicle
    {
        public Porsche()
        {
            Price = 4508000;
            Name = "Porsche";
            Speed = Speeds.Fast;
        }
        public decimal Price { get; set; }
        public string Name { get; set; }
        public Speeds Speed { get; set; }
    }
    public class Lambo : IVehicle
    {
        public Lambo()
        {
            Price = 60000000000;
            Name = "Lambo";
            Speed = Speeds.SuperFast;
        }
        public decimal Price { get; set; }
        public string Name { get; set; }
        public Speeds Speed { get; set; }
    }

    #region Numeric Literal Syntax


    // Digit Seperator
    public class SpecialNumbers
    {
        public const int OneMillion = 0___0;
        public const long BillionsAndBillions = 100_000_000_000;

        public const double AvogadroConstant = 6.022_140_857_747_474e23;
        public const decimal GoldenRatio = 1.618_033_988_749_894_848_204_586_834_365_638_117_720_309_179M;
    }
    // Binary Literal

    [Flags]
    public enum Speeds
    {
        Slow = 0b1,
        Normal = 0b10_0000_0000,
        Fast = 4,
        SuperFast = 8,
        LightSpeed = 1048576,

    }

    #endregion

    #region Out Variables

    public class TestOutVaribleUsage
    {
        public void Test(string input)
        {
            // C# 6
            int numericResult;
            if (int.TryParse(input, out numericResult))
            {
                // success
            }
            else
            {
                // failed
            }

            // C# 7
            if (int.TryParse(input, out int result)) // var
            {
                // success
                var sucess = result;
            }
            else
            {
                // failed
            }
            result += result;

        }
    }

    #endregion

    #region Expression Body Members
    // Expression bodied constructors, finalizers, get/set accessors
    public class ClassExample
    {
        private string Name { get; set; }

        ~ClassExample() => Name = "Finalize before GC";
        public ClassExample(string s) => this.Name = s;

        public string SmartName
        {
            get => "Smart" + Name;
            set => this.Name = value ?? "Smart name here";
        }
    }

    #endregion

    #region Local Functions
    public class LocalF
    {
        public int Method1()
        {
            string a = "1";
            string b = "2";
            int c = 34;
            return LocalMethod(a) + AnotherLocalMethodNoOneElseEverUses(b) + DontGoOverBoardGosh(c);

            int LocalMethod(string s)
            {
                return int.Parse(s);
            }

            int AnotherLocalMethodNoOneElseEverUses(string s)
            {
                return 1 + int.Parse(s);
            }
            int DontGoOverBoardGosh(int x) => x;
        }
    }

    #endregion
}
