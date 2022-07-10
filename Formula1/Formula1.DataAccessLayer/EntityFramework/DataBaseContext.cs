using Formula1.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formula1.DataAccessLayer.EntityFramework
{
    public class DataBaseContext : DbContext
    {
        public DbSet <Formula1User> Formula1Users { get; set; }
        public DbSet<Note> Notes { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Liked> Likes { get; set; }

        public DataBaseContext()
        {
            Database.SetInitializer(new MyInitializer());
        }
    }
}
