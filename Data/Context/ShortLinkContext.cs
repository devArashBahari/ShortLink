using Domain.Models.Link;
using Domain.Models.Person;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Context
{
    public class ShortLinkContext : DbContext
    {
        public ShortLinkContext(DbContextOptions<ShortLinkContext> options) : base(options)
        {

        }
        public DbSet<Person> Person { get; set; }
        public DbSet<ShortUrl> shortUrls { get; set; }
        public DbSet<Browser> browsers { get; set; }
        public DbSet<Os> Os { get; set; }
        public DbSet<Device> devices { get; set; }
        public DbSet<RequestUrl> requestUrls { get; set; }
    }
 
}
