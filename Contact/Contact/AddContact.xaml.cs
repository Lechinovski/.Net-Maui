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
}