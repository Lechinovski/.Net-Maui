using SportsDB.Models;

namespace SportsDB.Service
{
    public interface LeaguesApiFootballService
    {
        public Task<List<LeaguesApiFootball>> ObterLeagues(string country_id);
    }
}
