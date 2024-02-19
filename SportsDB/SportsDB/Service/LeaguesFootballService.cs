using SportsDB.Models;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace SportsDB.Service
{
    public class LeaguesFootballService : LeaguesApiFootballService
    {
        private string Baseurl = "https://apiv3.apifootball.com/?action=get_leagues&APIkey=43b72e3deccd8ae1c2f53263f159e967d8cd9316de694cc71cafc70c92b3c34a&country_id=6";

        public async Task<List<LeaguesApiFootball>> ObterLeagues(string country_id)
        {

            string urlApi = $"{Baseurl}&country_id={country_id}";

            var client = new HttpClient();
            var response = await client.GetAsync(urlApi);
            var responseBody = await response.Content.ReadAsStringAsync();
            JsonNode nodos = JsonNode.Parse(responseBody);

            var footballData = JsonSerializer.Deserialize<List<LeaguesApiFootball>>(nodos.ToString());
            return footballData;
        }
    }
}

