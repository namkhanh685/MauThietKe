namespace AbstractFactory
{
    public interface IAbstractShoeFactory
    {
        IAbstractSummerShoe CreateSummerShoe();

        IAbstractWinterShoe CreateWinterShoe();
    }
    class AdidasFactory : IAbstractShoeFactory
    {
        public IAbstractSummerShoe CreateSummerShoe()
        {
            return new AdidasSummerShoe();
        }

        public IAbstractWinterShoe CreateWinterShoe()
        {
            return new AdidasWinterShoe();
        }
    }
    class NikeFactory : IAbstractShoeFactory
    {
        public IAbstractSummerShoe CreateSummerShoe()
        {
            return new NikeSummerShoe();
        }

        public IAbstractWinterShoe CreateWinterShoe()
        {
            return new NikeWinterShoe();
        }
    }

    public interface IAbstractSummerShoe
    {
        string GetPrice();
        string GetName();
        string GetShoeBranch();
    }

    class AdidasSummerShoe : IAbstractSummerShoe
    {
        public string GetName()
        {
            return "Adidas Summer Shoe";
        }
        public string GetPrice()
        {
            return "2.000.000VND";
        }
        public string GetShoeBranch()
        {
            return "Adidas";
        }
    }

    class NikeSummerShoe : IAbstractSummerShoe
    {
        public string GetName()
        {
            return "Nike Summer Shoe";
        }
        public string GetPrice()
        {
            return "3.000.000VND";
        }
        public string GetShoeBranch()
        {
            return "Nike";
        }
    }

    public interface IAbstractWinterShoe
    {
        string GetName();
        string GetPrice();
        string GetShoeBranch();
    }

    class AdidasWinterShoe : IAbstractWinterShoe
    {
        public string GetName()
        {
            return "Adidas Winter Shoe";
        }
        public string GetPrice()
        {
            return "4.000.000VND";
        }
        public string GetShoeBranch()
        {
            return "Adidas";
        }
    }

    class NikeWinterShoe : IAbstractWinterShoe
    {
        public string GetName()
        {
            return "Nike Winter Shoe";
        }
        public string GetPrice()
        {
            return "3.500.000VND";
        }
        public string GetShoeBranch()
        {
            return "Nike";
        }
    }

    class Client
    {
        public void Main()
        {
            Console.WriteLine("Client: Testing Adidas factory type...");
            ClientMethod(new AdidasFactory());
            Console.WriteLine();

            Console.WriteLine("Client: Testing Nike factory type...");
            ClientMethod(new NikeFactory());
        }

        public void ClientMethod(IAbstractShoeFactory factory)
        {
            var summerShoe = factory.CreateSummerShoe();
            var winterShoe = factory.CreateWinterShoe();

            Console.WriteLine(summerShoe.GetName());
            Console.WriteLine(summerShoe.GetPrice());
            Console.WriteLine(summerShoe.GetShoeBranch());
            Console.WriteLine(winterShoe.GetName());
            Console.WriteLine(winterShoe.GetPrice());
            Console.WriteLine(winterShoe.GetShoeBranch());
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            new Client().Main();
        }
    }
}