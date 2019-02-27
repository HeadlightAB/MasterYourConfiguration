namespace HelloConfigurationManager
{
    internal class Program
    {
        static void Main()
        {
            var introducer = new Introducer(new Console());

            introducer.SayHello();

            System.Console.ReadLine();
        }
    }
}
