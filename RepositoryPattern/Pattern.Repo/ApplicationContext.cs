using Microsoft.EntityFrameworkCore;
using Pattern.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pattern.Repo
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {

        }

        public DbSet<Employee> Employee { get; set; }
    }
}
