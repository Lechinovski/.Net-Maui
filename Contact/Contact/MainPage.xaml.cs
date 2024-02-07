using Contact.service;
using Contact.Modelo;
using System.Collections.ObjectModel;
using System.Text.Json;
using System.IO;


namespace Contact
{
    public partial class MainPage : ContentPage
    {
        private readonly string _cachePath = Path.Combine(FileSystem.Current.CacheDirectory, "contacts.json");
        private readonly RandomUserService _usersService;

        public MainPage(RandomUserService service)
        {
            InitializeComponent();

            LoadData();

            _usersService = service;
        }

        private List<RandomUser> GetList()
        {
            var data = (List<RandomUser>)listViewUsers.ItemsSource;
            return data.OrderBy(x => x.name.first).ToList();
        }


        private async void OnCounterClicked(object sender, EventArgs e)
        {
            loading.IsVisible = true;

            var data = await _usersService.Obter();
            listViewUsers.ItemsSource = data.OrderBy(x => x.name.first).ToList();
            await SaveDataAsync();

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

        private async void DeleteButton_Clicked(object sender, EventArgs e)
        {
            var button = (ImageButton)sender;
            var selectedUser = (RandomUser)button.BindingContext;

            //var data = (List<RandomUser>)listViewUsers.ItemsSource;
            //data = data.OrderBy(x => x.name.first).ToList();
            var data = GetList();
            data.Remove(selectedUser);

            listViewUsers.ItemsSource = null;
            listViewUsers.ItemsSource = data;

            await SaveDataAsync();
        }

        private async void AddContact(object? sender, RandomUser newContact)
        {
            //var data = (List<RandomUser>)listViewUsers.ItemsSource;
            var data = GetList();

            data.Insert(0, newContact);
            listViewUsers.ItemsSource = null;
            listViewUsers.ItemsSource = data;

            await SaveDataAsync();

            await Navigation.PopAsync();
        }

        public void AddContactPageButton(object sender, EventArgs e)
        {
            var addContact = new AddContact();
            addContact.ContactAdded += AddContact;
            Navigation.PushAsync(addContact);
        }

        private void EditContactButton(object sender, EventArgs e)
        {
            var button = (ImageButton)sender;
            var selectedUser = (RandomUser)button.BindingContext;

            var data = (List<RandomUser>)listViewUsers.ItemsSource;

            var index = data.FindIndex(x => x == selectedUser);

            var editContact = new EditContactPage(selectedUser, index);
            editContact.ContactEdited += EditContact;

            Navigation.PushAsync(editContact);

        }

        private async void EditContact(object? sender, (RandomUser contact, int index) args)
        {
            // var data = (List<RandomUser>)listViewUsers.ItemsSource;
            var data = GetList();
            data[args.index] = args.contact;

            listViewUsers.ItemsSource = null;
            listViewUsers.ItemsSource = data;

            await SaveDataAsync();

            await Navigation.PopAsync();
        }

        private void LoadData()
        {
            if (!File.Exists(_cachePath))
                return;

            using var fs = File.OpenRead(_cachePath);
            listViewUsers.ItemsSource = JsonSerializer.Deserialize<List<RandomUser>>(fs);
        }

        private async Task SaveDataAsync()
        {
            await using var fs = File.Create(_cachePath);
            await JsonSerializer.SerializeAsync(fs, (List<RandomUser>)listViewUsers.ItemsSource);
        }

    }
}

