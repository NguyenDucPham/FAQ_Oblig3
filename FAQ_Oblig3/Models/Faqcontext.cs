using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

using Microsoft.EntityFrameworkCore;

namespace FAQ_Oblig3.Models
{
    public class Faqcontext : DbContext
    {
        public Faqcontext(DbContextOptions<Faqcontext> options)
        : base(options) { }

        public DbSet<Qa> QAer { get; set; }

    }
}
