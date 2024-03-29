using SportsDB.Models;
using SportsDB.Service;
namespace SportsDB;

public partial class PaisDetails : ContentPage
{
    private readonly LeaguesFootballService _secondFootballService;
    private string _country_id;

    public PaisDetails(LeaguesFootballService service, string country_id)
    {
        InitializeComponent();
        _secondFootballService = service;
        _country_id = country_id;   
        InitializePageAsync();
    }

    private async Task InitializePageAsync()
    {
        loading.IsVisible = true;

        var data = await _secondFootballService.ObterLeagues(_country_id);
        listViewPaises.ItemsSource = data;

        loading.IsVisible = false;
    }

    private async void LeaguesDetails(object sender, SelectedItemChangedEventArgs e)
    {
        var selectedDivision = e.SelectedItem as LeaguesApiFootball;
        if (selectedDivision != null)
        {
            var leaguesId = selectedDivision.league_id;
            var teamsFootballService = new TeamsFootballService();
            await Navigation.PushAsync(new LeaguesDetails(teamsFootballService, leaguesId));
        }

    }
}
