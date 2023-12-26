using System;
using System.Collections.Generic;
using System.Text;

using SQLite;

namespace PTLISTEmobile.Models
{
    public class Contact
    {
        [PrimaryKey, AutoIncrement]
        public int id{ get; set; }
        public string name { get; set; }
        public string statut { get; set; }
        public string imageSource { get; set; }
    }
}
