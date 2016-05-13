using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;



namespace Client
{

    class Program
    {

        public static void Main(string[] args)
        {
            Console.WriteLine("in main running http requests");
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Http Request " + i);
                RunAsync().Wait();
            }

        }


        public static async Task RunAsync()
        {

            using (var client = new HttpClient())
            {

                //Send HTTP requests
                client.BaseAddress = new Uri("http://localhost:60467//api/contact");
                var X = client.BaseAddress.ToString();

                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // HTTP GET
                HttpResponseMessage response = await client.GetAsync(client.BaseAddress);
                Console.WriteLine(response);
                if (response.IsSuccessStatusCode)
                {

                    //map json response to Contact class
                    Contact[] contacts = await response.Content.ReadAsAsync<Contact[]>();
                    foreach (Contact c in contacts)
                    {
                        Console.WriteLine("{0}\t${1}", c.id, c.Name);
                    }

                }
                else
                {
                    Console.WriteLine(response.StatusCode);
                }


            }
        }
    }


}
