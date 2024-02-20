using SportsDB.Models;

namespace SportsDB.Service
{
    public interface TeamsApiFootballService
    {
        public Task<List<TeamsApiFootball>> ObterTeams(string league_id);
    }
}
