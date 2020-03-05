using System;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Cw1
{
    class Program
    {
        static async Task Main(string[] args)
        {
            //Console.WriteLine("Hello World!");

            //string tmp1 = "borubar";
            //string tmp2 = "i irasiad";

            //var newPerson = new Person { FirstName = "Borubar" };


            //Console.WriteLine($"{tmp1} {tmp2}");

            var url = args.Length > 0 ? args[0] : "https://www.pja.edu.pl";
            var httpClient = new HttpClient();


            var response = await httpClient.GetAsync(url);


            //2xx
            if(response.IsSuccessStatusCode)
            {
                var htmlContent = await response.Content.ReadAsStringAsync();

                var regex = new Regex("[a-z]+[a-z0-9]*@[a-z0-9]+\\.[a-z]+",RegexOptions.IgnoreCase);

                var matches = regex.Matches(htmlContent);

                // foreach

                foreach (var match in matches)
                {
                    Console.WriteLine(match.ToString());
                }
                    
                        
            }
        }
    }
}
