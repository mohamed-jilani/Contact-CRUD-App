using PTLISTEmobile.Models;
using PTLISTEmobile.Views;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PTLISTEmobile
{
    public partial class App : Application
    {
        public static ContactDatabase database;

        public static ContactDatabase Database
        {
            get
            {
                if( database == null)
                {
                    database = new ContactDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "contacts.db3"));
                }

                return database;
            }
        }

        public App()
        {
            InitializeComponent();

            //MainPage = new ContactePage();
            //MainPage = new AjoutContact();
            MainPage = new NavigationPage(new ContactePage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
