using Contact.Modelo;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace Contact.service
{
    public class UsersService : RandomUserService
    {
        private string urlApi = "https://randomuser.me/api/?results=50";
        public async Task<List<RandomUser>> Obter()
        {
            var client = new HttpClient();
            var response = await client.GetAsync(urlApi);
            var responseBody = await response.Content.ReadAsStringAsync();
            JsonNode nodos = JsonNode.Parse(responseBody);
            JsonNode results = nodos["results"];
            var usersData = JsonSerializer.Deserialize<List<RandomUser>>(results.ToString());
            return usersData;
        }
    }
}
