using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Assignment_1.Models;
using System.Data.Entity;

namespace Assignment_1.Repositories
{
    public class ContactRepository : IContactRepository
    {
        ContactContext db;
        DbSet<Contact> dbSet;

        public ContactRepository()
        {
            db = new ContactContext();
            dbSet = db.Set<Contact>();
        }

        public async Task<List<Contact>> GetAllAsync()
        {
            return await dbSet.ToListAsync();
        }
        public async Task<Contact> FindAsync(long id)
        {
            return await db.Contacts.FindAsync(id);
        }

        public async Task CreateAsync(Contact contact)
        {
            dbSet.Add(contact);
            await db.SaveChangesAsync();
        }

        public async Task DeleteAsync(long id)
        {
            var contact = await dbSet.FindAsync(id);
            if (contact != null)
            {
                dbSet.Remove(contact);
                await db.SaveChangesAsync();
            }
        }
    }
}