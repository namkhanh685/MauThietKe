namespace FactoryMethod
{
    abstract class Factory
    {
        public abstract IShoe FactoryMethod();

        public string CreateShoe()
        {
            var product = FactoryMethod();
            var result = product.GetName();

            return result;
        }
    }

    class WinterShoeFactory : Factory
    {
        public override IShoe FactoryMethod()
        {
            return new WinterShoe();
        }
    }

    class SummerShoeFactory : Factory
    {
        public override IShoe FactoryMethod()
        {
            return new SummerShoe();
        }
    }
    public interface IShoe
    {
        string GetName();
        string GetPrice();
    }
    class WinterShoe : IShoe
    {
        public string GetName()
        {
            return "Winter Shoe";
        }

        public string GetPrice()
        {
            return "3.500.000VND";
        }
    }

    class SummerShoe : IShoe
    {
        public string GetName()
        {
            return "Summer Shoe";
        }

        public string GetPrice()
        {
            return "3.000.000VND";
        }
    }


    class Client
    {
        public void Main()
        {
            Console.WriteLine("App: Launched with the Winter Shoe Factory.");
            ClientCode(new WinterShoeFactory());

            Console.WriteLine("");

            Console.WriteLine("App: Launched with the Summer Shoe Factory.");
            ClientCode(new SummerShoeFactory());
        }

        public void ClientCode(Factory creator)
        {
            Console.WriteLine("Client: I'm not aware of the creator's class," +
                "but it still works.\n" + creator.CreateShoe());
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