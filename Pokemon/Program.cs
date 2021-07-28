using System;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Collections.Generic;
using System.Text.Json;
using Newtonsoft.Json.Linq;

namespace Pokemon
{
    class Program
    {
        static void Main(String[] args)
        {
            bool go = true;
            string words;
            string pokemons;
            Console.WriteLine("please enter a pokemon");

                pokemons = Console.ReadLine();
            while(go){
                Console.WriteLine("please enter what attribute you would like or enter exit to quit");

                words = Console.ReadLine();
                if (words == "exit")
                {
                    go = false;
                }
                else{
                    try{GetRequest("https://pokeapi.co/api/v2/pokemon/" + pokemons, words);}
                    catch{}}
                
            }
           
            
        }
        async static void GetRequest(string url, string what){
           
            HttpClient client = new HttpClient();
            
            HttpResponseMessage response = client.GetAsync(url).Result;
            
           
            HttpContent content = response.Content;
            string mycont = await content.ReadAsStringAsync();
             JObject jresponse = JObject.Parse(mycont);
             string test = (string)jresponse.SelectToken(what).ToString();
                        Console.WriteLine(test);
        }
    }

}