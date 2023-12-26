using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace PTLISTEmobile.Models
{
    public class ContactDatabase
    {
        readonly SQLiteAsyncConnection _database; 

        //pour la creation du table Contact
        public ContactDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Contact>().Wait();

        }
        // pour avoir la liste des contactes
        public Task<List<Contact>> GetContactsAsync()
        {
            return _database.Table<Contact>().ToListAsync();
        } 

        // pour avoir un contacte par id
        public Task<Contact> GetContactAsync(int id)
        {
            return _database.Table<Contact>().Where(c => c.id == id).FirstOrDefaultAsync();
        }

        // ajouter ou modifier un contacte
        public Task<int> SaveContactAsync(Contact contact)
        {
            if(contact != null)
            {
                return _database.UpdateAsync(contact);
            }
            else
            {
                return _database.InsertAsync(contact);
            }
        }

        // pour supprimer un contacte 

        public Task<int> DeleteContactAsync(Contact contact)
        {
            return _database.DeleteAsync(contact);
        }

    }
}
