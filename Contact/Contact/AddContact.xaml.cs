using Contact.Modelo;
using Microsoft.Maui.Graphics.Platform;

namespace Contact;

public partial class AddContact : ContentPage
{
	public AddContact()
	{
		InitializeComponent();
	}

    private void AddContact_Button(object sender, EventArgs e)
    {
        RandomUser newContact = new RandomUser
        {
            name = new RandomUser.Name
            {
                title = TitleEntry.Text,
                first = FirstNameEntry.Text,
                last = LastNameEntry.Text
            },
            email = EmailEntry.Text,
            phone = PhoneNumberEntry.Text,
            cell = CellNumberEntry.Text,
        };
        List<RandomUser> dataAdd = new List<RandomUser>();
        dataAdd.Add(newContact);

        OnContactAdded(newContact);


    }

    private async void AddPhoto(object sender, EventArgs e)
    {
        var result = await FilePicker.PickAsync(new PickOptions
        {
            PickerTitle = "Pick Image Please",
            FileTypes = FilePickerFileType.Images

        });

        if (result == null)
            return;

        var stream = await result.OpenReadAsync();

        MyImage.Source = ImageSource.FromStream(() => stream);

    }
    public event EventHandler<RandomUser> ContactAdded;

    protected virtual void OnContactAdded(RandomUser newContact)
    {
        ContactAdded?.Invoke(this, newContact);
    }

}