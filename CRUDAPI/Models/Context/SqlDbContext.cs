using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CRUDAPI.Models.Context
{
    public class SqlDbContext : DbContext
    {
        public SqlDbContext() { }

        public SqlDbContext(DbContextOptions<SqlDbContext> opcoes) 
        : base(opcoes) { }
        
        public DbSet<Person> Persons {get; set;}        
        
    }
}