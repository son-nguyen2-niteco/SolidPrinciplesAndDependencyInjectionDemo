namespace SDD.SolidPrinciples
{
    internal static class Program
    {
        private static void Main()
        {
            CodeSmellDemo.Run().GetAwaiter().GetResult();
            //DynamicProxyDemo.Run();
        }
    }
}