using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace productapp.Models
{
    public class prodcontext:DbContext
    {
        public prodcontext(DbContextOptions<prodcontext> options) : base(options)
        {

        }

        public DbSet<products> products { get; set; }

        public DbSet<category> category { get; set; }
    }
}