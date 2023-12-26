using PTLISTEmobile.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PTLISTEmobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ContactePage : ContentPage
    {

        private ObservableCollection<Contact> contacts;
        public ContactePage()
        {
            InitializeComponent();
            /*
            contacts = new ObservableCollection<Contact>
            {
                new Contact{name="samsung1" , statut="disponible", imageSource="smsung1.jpg"},
                new Contact{name="samsung2" , statut="disponible", imageSource="smsung2.jpg"},
                new Contact{name="samsung3" , statut="non disponible", imageSource="smsung3.jpg"}
            };
            listContacts.ItemsSource = contacts;
            */

        }


        protected async override void OnAppearing()
        {
            listContacts.ItemsSource = await App.Database.GetContactsAsync();

        }

        private void BtnAfficher_Clicked(object sender, EventArgs e)
        {
            var menuItem = sender as MenuItem;
            var contact = menuItem.CommandParameter as Contact;
            DisplayAlert("Details : ", contact.name, "OK");
        }
        private void BtnDelete_Clicked(object sender, EventArgs e)
        {
            var menuItem = sender as MenuItem;
            var contact = menuItem.CommandParameter as Contact;
            App.Database.DeleteContactAsync(contact);
            OnAppearing();
            //contacts.Remove(contact);

        }

        private void btnAdd_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AjoutContact());
        }

        private void btnEdit_Clicked(object sender, EventArgs e)
        {
            var menuItem = sender as MenuItem;
            var contact = menuItem.CommandParameter as Contact;
            Navigation.PushAsync(new AjoutContact(contact));

        }
    }
}