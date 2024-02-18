using SportsDB.Models;

namespace SportsDB.Service
{
    public interface ApiFootballService
    {
        public Task<List<ApiFootball>> Obter();
    }
}
