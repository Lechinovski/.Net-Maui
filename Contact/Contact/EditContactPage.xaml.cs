using Contact.Modelo;
namespace Contact;

public partial class EditContactPage : ContentPage
{
    //private readonly RandomUser _originalUser;
    private RandomUser _selectedUser;
    private readonly int _index;

    public EditContactPage(RandomUser selectedUser, int index)
	{
		InitializeComponent();

        //_originalUser = selectedUser;
        _selectedUser = selectedUser;
        _index = index;

        ImageEntry.Source = selectedUser.picture?.large
                ?? ImageSource.FromFile($"{Environment.CurrentDirectory}/Resources/Images/dotnet_bot.png");
        NameEntry.Text = $"{selectedUser.name.title} {selectedUser.name.first} {selectedUser.name.last}";
        EmailEntry.Text = selectedUser.email;
        PhoneEntry.Text = selectedUser.phone;
        CellEntry.Text = selectedUser.cell;
    }

    private void EditContact_Button(object sender, EventArgs e)
    {
        // _selectedUser.picture = TODO - Trocar o tipo Picture para ImageSource

        // Essa lógica não suporta nomes compostos, mas é a forma que achei de separar os nomes sem modificar a tela.
        var fullName = NameEntry.Text.Split(' ');
        _selectedUser.name.title = fullName[0];
        _selectedUser.name.first = fullName[1];
        _selectedUser.name.last = fullName[2];

        _selectedUser.email = EmailEntry.Text;
        _selectedUser.phone = PhoneEntry.Text;
        _selectedUser.cell = CellEntry.Text;

        OnContactEdited(_selectedUser, _index);
    }

    public event EventHandler<(RandomUser, int)> ContactEdited;

    protected virtual void OnContactEdited(RandomUser contact, int index)
    {
        ContactEdited?.Invoke(this, (contact, index));
    }
}