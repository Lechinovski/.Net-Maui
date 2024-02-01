using Contact.Modelo;
using Microsoft.Maui.Controls;
using System;

namespace Contact
{
    public partial class ContactDetailsPage : ContentPage
    {
        public ContactDetailsPage(RandomUser selectedUser)
        {
            InitializeComponent();

            detailsImage.Source = selectedUser.picture.large;
            detailsName.Text = $"{selectedUser.name.title} {selectedUser.name.first} {selectedUser.name.last}";
            detailsEmail.Text = selectedUser.email;
            detailsPhone.Text = selectedUser.phone;
            detailsCell.Text = selectedUser.cell;
        }
    }
}
