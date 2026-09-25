using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ConsoleAppCS;

internal class HttpClientAsync
{
    public static async Task Test()
    {
        using (HttpClient client = new HttpClient())
        {
            try
            {
                Console.WriteLine("Starting HTTP request to PetStore API...");
                // PetStore API endpoint
                string url = "https://petstore.swagger.io/v2/pet/findByStatus?status=available";
                HttpResponseMessage response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                //Console.WriteLine($"Response: {responseBody}");

                // Deserialize the JSON response into a list of pets
                var pets = JsonSerializer.Deserialize<List<Pet>>(responseBody);

                // Iterate through the list of pets and display their details
                foreach (var pet in pets)
                {
                    //Console.WriteLine($"Pet ID: {pet.id}, Name: {pet.name}");
                    if (pet.id.ToString().Length > 4)
                    {
                        Console.WriteLine($"Pet ID: {pet.id}, Name: {pet.name}");
                    }
                }
                Console.WriteLine("End of PetStore API method...");
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine($"Request error: {e.Message}");
            }
        }
    }
}
public class Pet
{
    public long id { get; set; }
    public string name { get; set; }
    public Category category { get; set; }
    public List<string> photoUrls { get; set; }
    public List<Tag> tags { get; set; }
    public string status { get; set; }
}

public class Category
{
    public long id { get; set; }
    public string name { get; set; }
}

public class Tag
{
    public long id { get; set; }
    public string name { get; set; }
}
