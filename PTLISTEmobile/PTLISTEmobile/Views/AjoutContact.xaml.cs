using PTLISTEmobile.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PTLISTEmobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AjoutContact : ContentPage
    {
        private Contact upContact = null;
        public AjoutContact()
        {
            InitializeComponent();
        }

        public AjoutContact(Contact c)
        {
            InitializeComponent();

            upContact = c;

            txtNom.Text = c.name;
            txtStatut.Text = c.statut;
            txtImage.Text = c.imageSource;

            btnAdd.Text = "Update";
            
        }

        private async void btnAdd_Clicked(object sender, EventArgs e)
        {
            if(upContact == null)
            {
                Contact contact = new Contact
                {
                    name = txtNom.Text,
                    statut = txtStatut.Text,
                    imageSource = txtImage.Text

                };

                await App.Database.SaveContactAsync(contact);

                _ = DisplayAlert("Ajout", "Contact ajouté avec sucessè ", "OK");

                await Navigation.PopAsync();
            }
            else
            {
                upContact.name = txtNom.Text;
                upContact.statut = txtStatut.Text;
                upContact.imageSource = txtImage.Text;

                await App.Database.SaveContactAsync(upContact);

                _ = DisplayAlert("Update", "Contact Updated avec sucessè ", "OK");
                upContact = null;

                await Navigation.PopAsync();
            }
            
        }
    }
}