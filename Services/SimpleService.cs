namespace MyServiceNamespace
{
    public class SimpleService
    {
        private const string GreetingPrefix = "Hello, ";

        public string SayHello(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return "Hello there!";
            }

            return $"{GreetingPrefix}{name}!";
        }
      
        public int AddNumbers(int a, int b)
        {
            return a + b;
        }
    }
}
