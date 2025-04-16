using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Infrastructure
{
    public class ProTransDbContext : DbContext
    {
        public ProTransDbContext() // Parameterless constructor for migrations
        {
        }
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
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           //User
            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();
            modelBuilder.Entity<User>()
                .HasIndex(u => u.PhoneNumber)
                .IsUnique();
            modelBuilder.Entity<User>()
                .HasMany(u => u.Orders)
                .WithOne(u => u.User)
                .HasForeignKey(u => u.UserId);
            modelBuilder.Entity<User>()
                .HasMany(u => u.Transactions)
                .WithOne(u => u.User)
                .HasForeignKey(u => u.UserId)
                .IsRequired();
           //Employee
           modelBuilder.Entity<Employee>()
                 .HasIndex(u => u.Email)
                .IsUnique();
            modelBuilder.Entity<Employee>()
                .HasIndex(u => u.PhoneNumber)
                .IsUnique();
            modelBuilder.Entity<Employee>()
                .HasOne(e => e.Agency)
                .WithMany(e => e.Employees)
                .HasForeignKey(e => e.AgencyId)
                .IsRequired();
            modelBuilder.Entity<Employee>()
                .HasMany(e => e.AssignmentTranslations)
                .WithOne(e => e.Translator)
                .HasForeignKey(e => e.TranslatorId);
            //Agency
            modelBuilder.Entity<Agency>()
                .HasMany(a => a.Employees)
                .WithOne(a => a.Agency)
                .HasForeignKey(a=>a.AgencyId);
            modelBuilder.Entity<Agency>()
                .HasMany(a => a.Orders)
                .WithOne(a => a.Agency)
                .HasForeignKey(a => a.AgencyId);
            //Transaction
            modelBuilder.Entity<Transaction>()
                .HasOne(t => t.User)
                .WithMany(t => t.Transactions)
                .HasForeignKey(t => t.UserId)
                  .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();
            modelBuilder.Entity<Transaction>()
                .HasOne(t => t.Order)
                .WithOne(t => t.Transaction)
                .HasForeignKey<Transaction>(t => t.OrderId)
                .IsRequired();
            //TranslationSkill
            modelBuilder.Entity<TranslationSkill>()
                .HasOne(ts => ts.Translator)
                .WithMany(ts => ts.TranslationSkills)
                .HasForeignKey(ts => ts.TranslatorId)
                .IsRequired();
            //Distance
            modelBuilder.Entity<Distance>()
                .HasOne(d => d.RootAgency)
                .WithMany(r => r.RootAgencyDistance)
                .HasForeignKey(r => r.RootAgencyId)
                  .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();
            modelBuilder.Entity<Distance>()
                .HasOne(d => d.TargetAgency)
                .WithMany(ta => ta.TargetAgencyDistance)
                .HasForeignKey(ta => ta.TargetAgencyId)
                  .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();
            //Order
            modelBuilder.Entity<Order>()
              .HasOne(o => o.User)
              .WithMany(u => u.Orders)
              .HasForeignKey(o => o.UserId)
              .IsRequired(true);
            //DocumentType
            modelBuilder.Entity<DocumentType>()
               .HasMany(dt => dt.Documents)
               .WithOne(d => d.DocumentType)
               .HasForeignKey(d => d.DocumentTypeId)
               .IsRequired();
            //AssignmentTranslating
            modelBuilder.Entity<AssignmentTranslation>()
                .HasMany(at=> at.Document)
                .WithOne(d => d.AssignmentTranslation)
                .HasForeignKey(d=>d.AssignmentTranslationId);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=localhost;Database=ProTransRemakeDB;User ID=sa;Password=123123;TrustServerCertificate=True;");
        }
    }
}
