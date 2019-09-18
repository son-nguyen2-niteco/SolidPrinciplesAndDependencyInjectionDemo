using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace SDD.SolidPrinciples
{
    public static class CodeSmellDemo
    {
        public static async Task Run()
        {
            var query = new PublicIpQuery();
            var handler = new PublicIpQueryHandler();

            var ip = await handler.Handle(query);

            Console.WriteLine(ip);
        }
    }

    public class PublicIpQuery : IQuery<string>
    {
    }

    public class PublicIpQueryHandler : IQueryHandler<PublicIpQuery, string>
    {
        public async Task<string> Handle(PublicIpQuery query)
        {
            try
            {
                var client = new HttpClient();

                return await client.GetStringAsync("https://api.ipify.org");
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);

                return string.Empty;
            }
        }
    }

    public interface IQueryHandler<TQuery, TResult> where TQuery : IQuery<TResult>
    {
        Task<TResult> Handle(TQuery query);
    }

    public interface IQuery<TResult>
    {
    }
}