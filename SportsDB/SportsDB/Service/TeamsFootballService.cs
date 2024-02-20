using SportsDB.Models;
using System.Text.Json;
using System.Text.Json.Nodes;


namespace SportsDB.Service
{
    public class TeamsFootballService : TeamsApiFootballService
    {
        private string Baseurl = "https://apiv3.apifootball.com/?action=get_teams&APIkey=43b72e3deccd8ae1c2f53263f159e967d8cd9316de694cc71cafc70c92b3c34a&league_id=99";

        public async Task<List<TeamsApiFootball>> ObterTeams(string league_id)
        {
            string urlApi = $"{Baseurl}&league_id={league_id}";

            var client = new HttpClient();
            var response = await client.GetAsync(urlApi);
            var responseBody = await response.Content.ReadAsStringAsync();
            JsonNode nodos = JsonNode.Parse(responseBody);

            var footballData = JsonSerializer.Deserialize<List<TeamsApiFootball>>(nodos.ToString());
            return footballData;
        }
    }
}
