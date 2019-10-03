using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace UserRegAPI.Entities
{
    public partial class userregisterContext : DbContext
    {
        public String objConnectionString { get; }

        public userregisterContext(string sConnectionString)
        {
            objConnectionString = sConnectionString;
        }

        public userregisterContext(DbContextOptions<userregisterContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=userregister;Trusted_Connection=True;");
                optionsBuilder.UseSqlServer(objConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Users>(entity =>
            {
                entity.Property(e => e.AddRequest).HasColumnType("text");

                entity.Property(e => e.DateReg).HasColumnType("date");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Gender)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Name).HasMaxLength(200);

                entity.Property(e => e.SelectedDays)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });
        }
    }
}
