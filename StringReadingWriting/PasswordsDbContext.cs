using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace StringReadingWriting
{
    class PasswordsDbContext : DbContext
    {
        public PasswordsDbContext() : base()
        {

        }

        public DbSet<Password> Passwords { get; set; }

    }
}
