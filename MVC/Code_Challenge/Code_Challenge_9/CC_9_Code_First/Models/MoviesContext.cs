using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;


namespace CC_9_Code_First.Models
{
    public class MoviesContext :DbContext
    {
        public MoviesContext() : base("name=MSSQLConnection") { }  
        public DbSet<Movies> Movie { get; set; }
    }
}
