using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Assignment_1.Models
{
    public class ContactContext : DbContext
    {
        public ContactContext() : base("name = MSSQLConnection") { }
        public DbSet<Contact> Contacts { get; set; }
    }
}