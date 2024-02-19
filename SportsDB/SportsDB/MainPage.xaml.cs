using SportsDB.Service;
using SportsDB.Models;
using System.Text.Json;

namespace SportsDB
{
    public partial class MainPage : ContentPage
    {
        private readonly ApiFootballService _footballService;

        public MainPage(ApiFootballService service)
        {
            InitializeComponent();
            _footballService = service;
            InitializePageAsync();
        }

        private async Task InitializePageAsync()
        {
            loading.IsVisible = true;

            var data = await _footballService.Obter();
            listViewPaises.ItemsSource = data;

            loading.IsVisible = false;
        }

        private async void DetailsPais(object sender, SelectedItemChangedEventArgs e)
        {
            var selectedCountry = e.SelectedItem as ApiFootball;
            if (selectedCountry != null)
            {
                var countryId = selectedCountry.country_id;
                var secondFootballService = new LeaguesFootballService(); // Instancia o serviço da segunda API
                await Navigation.PushAsync(new PaisDetails(secondFootballService, countryId)); // Passa o serviço e o country_id como parâmetros
            }
        }

    }
}
