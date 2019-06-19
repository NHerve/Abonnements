using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AbonnementsAPi.Models;

namespace AbonnementsAPi.Models
{
    public class AbonnementsAPIContext : DbContext
    {
        public AbonnementsAPIContext(DbContextOptions<AbonnementsAPIContext> options) : base(options){ }
        public DbSet<Clients> clients { get; set; }
        public DbSet<Magazines> Magazines { get; set; }
        public DbSet<Abonnements> Abonnements { get; set; }
        public DbSet<AbonnementsAPi.Models.Log> Log { get; set; }
        public DbSet<AbonnementsAPi.Models.Historique> Historique { get; set; }
        public DbSet<AbonnementsAPi.Models.Employer> Employer { get; set; }
    }
}
