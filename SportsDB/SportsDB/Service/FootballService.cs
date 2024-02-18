using SportsDB.Models;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace SportsDB.Service
{
    public class FootballService : ApiFootballService
    {

        private string urlApi = "https://apiv3.apifootball.com/?action=get_countries&APIkey=43b72e3deccd8ae1c2f53263f159e967d8cd9316de694cc71cafc70c92b3c34a";
        public async Task<List<ApiFootball>> Obter()
        {
            var client = new HttpClient();
            var response = await client.GetAsync(urlApi);
            var responseBody = await response.Content.ReadAsStringAsync();
            JsonNode nodos = JsonNode.Parse(responseBody);

            var footballData = JsonSerializer.Deserialize<List<ApiFootball>>(nodos.ToString());
            return footballData;

        }
    }
}
