using SportsDB.Service;
namespace SportsDB;

public partial class LeaguesDetails : ContentPage
{
    private readonly TeamsFootballService _teamsFootballService;
    private string _league_id;
    public LeaguesDetails(TeamsFootballService service, string league_id)
	{
		InitializeComponent();
        _teamsFootballService = service;
        _league_id = league_id;
        InitializePageAsync();
    }

    private async Task InitializePageAsync()
    {
        loading.IsVisible = true;

        var data = await _teamsFootballService.ObterTeams(_league_id);
        listViewLeagues.ItemsSource = data;

        loading.IsVisible = false;
    }
}