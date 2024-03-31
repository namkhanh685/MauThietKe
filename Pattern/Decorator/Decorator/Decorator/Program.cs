namespace Decorator
{
    public abstract class Order
    {
        public abstract string Operation();
    }

    class BasicOrder : Order
    {
        public override string Operation()
        {
            return "Basic Order";
        }
    }

    abstract class ShippingDecorator : Order
    {
        protected Order _Order;

        public ShippingDecorator(Order Order)
        {
            this._Order = Order;
        }

        public void SetOrder(Order Order)
        {
            this._Order = Order;
        }

        public override string Operation()
        {
            if (this._Order != null)
            {
                return this._Order.Operation();
            }
            else
            {
                return string.Empty;
            }
        }
    }

    class ExpressShippingDecorator : ShippingDecorator
    {
        public ExpressShippingDecorator(Order comp) : base(comp)
        {
        }

        public override string Operation()
        {
            return $"Express Shipping Decorator({base.Operation()})";
        }
    }

    class SpecialShippingDecorator : ShippingDecorator
    {
        public SpecialShippingDecorator(Order comp) : base(comp)
        {
        }

        public override string Operation()
        {
            return $"Special Shipping Decorator ({base.Operation()})";
        }
    }

    public class Client
    {
        public void ClientCode(Order Order)
        {
            Console.WriteLine("RESULT: " + Order.Operation());
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Client client = new Client();

            var simple = new BasicOrder();
            Console.WriteLine("Client: I get a simple Order:");
            client.ClientCode(simple);
            Console.WriteLine();

            ExpressShippingDecorator decorator1 = new ExpressShippingDecorator(simple);
            SpecialShippingDecorator decorator2 = new SpecialShippingDecorator(decorator1);
            Console.WriteLine("Client: Now I've got a decorated Order:");
            client.ClientCode(decorator2);
        }
    }
}
