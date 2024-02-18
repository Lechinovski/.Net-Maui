using SportsDB.Models;

namespace SportsDB.Service
{
    public interface SecondApiFootballService
    {
        public Task<List<SecondApiFootball>> ObterLeagues(string country_id);
    }
}
