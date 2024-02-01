using Contact.service;
using Contact.Modelo;
using System.Collections.ObjectModel;


namespace Contact
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        private readonly RandomUserService _usersService;

        public MainPage(RandomUserService service)
        {
            InitializeComponent();
            _usersService = service;
        }

        public MainPage()
        {
        }

        private async void OnCounterClicked(object sender, EventArgs e)
        {
            loading.IsVisible = true;

            var data = await _usersService.Obter();
            listViewUsers.ItemsSource = data;

            loading.IsVisible = false;
        }
        private void ContactDetails(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
                return;

            var selectedUser = (RandomUser)e.SelectedItem;

            Navigation.PushAsync(new ContactDetailsPage(selectedUser));

            ((ListView)sender).SelectedItem = null;
        }

        private void DeleteButton_Clicked(object sender, EventArgs e)
        {
            var button = (ImageButton)sender;
            var selectedUser = (RandomUser)button.BindingContext;

            var data = (List<RandomUser>)listViewUsers.ItemsSource;
            data.Remove(selectedUser);

            listViewUsers.ItemsSource = null;
            listViewUsers.ItemsSource = data;
        }

        private void AddContact_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AddContact());
        }
    }
}

