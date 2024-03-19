namespace Builder
{
    public interface IVehicleBuilder
    {
        void BuildWindow();

        void BuildEngine();

        void BuildTires();
    }


    public class ConcreteCarBuilder : IVehicleBuilder
    {
        private Car _product = new Car();

        public ConcreteCarBuilder()
        {
            this.Reset();
        }

        public void Reset()
        {
            this._product = new Car();
        }

        public void BuildWindow()
        {
            this._product.Add("Window");
        }

        public void BuildEngine()
        {
            this._product.Add("Engine V4");
        }

        public void BuildTires()
        {
            this._product.Add("Tires");
        }

        public Car GetProduct()
        {
            Car result = this._product;

            this.Reset();

            return result;
        }
    }

    public class Car
    {
        private List<object> _parts = new List<object>();

        public void Add(string part)
        {
            this._parts.Add(part);
        }

        public string ListParts()
        {
            string str = string.Empty;

            for (int i = 0; i < this._parts.Count; i++)
            {
                str += this._parts[i] + ", ";
            }

            str = str.Remove(str.Length - 2); // removing last ",c"

            return "Product parts: " + str + "\n";
        }
    }

    public class Director
    {
        private IVehicleBuilder _builder;

        public IVehicleBuilder Builder
        {
            set { _builder = value; }
        }

        public void BuildMinimalViableProduct()
        {
            this._builder.BuildEngine();
        }

        public void BuildFullFeaturedProduct()
        {
            this._builder.BuildTires();
            this._builder.BuildEngine();
            this._builder.BuildWindow();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var director = new Director();
            var builder = new ConcreteCarBuilder();
            director.Builder = builder;

            Console.WriteLine("Standard basic car:");
            director.BuildMinimalViableProduct();
            Console.WriteLine(builder.GetProduct().ListParts());

            Console.WriteLine("Standard full featured car:");
            director.BuildFullFeaturedProduct();
            Console.WriteLine(builder.GetProduct().ListParts());

            Console.WriteLine("Custom car:");
            builder.BuildWindow();
            builder.BuildEngine();
            Console.Write(builder.GetProduct().ListParts());
        }
    }
}
