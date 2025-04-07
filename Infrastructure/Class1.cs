using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Infrastructure
{
    public class ProTransDbContext : DbContext
    {
        public ProTransDbContext(DbContextOptions<ProTransDbContext> options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Agency> Agencies { get; set; }
        public DbSet<Distance> Distances { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<DocumentType> DocumentTypes { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Transaction> Transactions {get;set;}
        public DbSet<TranslationPrice> TranslationPrices { get; set;}
        public DbSet<TranslationSkill> TranslationSkills { get; set; }
        public DbSet<AssignmentNotarization> AssignmentNotarizations { get; set; }
        public DbSet<AssignmentShipping> AssignmentShippings { get; set; }
        public DbSet<AssignmentTranslation> AssignmentTranslations { get; set; }
    }
}
