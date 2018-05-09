using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace InsecTimeLine.Models
{
    public partial class insectimelineContext : DbContext
    {
        public virtual DbSet<Events> Events { get; set; }
        public virtual DbSet<Timeline> Timeline { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer(@"Server=.;Database=insectimeline;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Events>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.DateEng)
                    .HasColumnName("Date_Eng")
                    .HasColumnType("datetime");

                entity.Property(e => e.DateNep)
                    .HasColumnName("Date_Nep")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Timeline>(entity =>
            {
                entity.Property(e => e.EventLink)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.EventRefId).HasColumnName("EventRef_Id");

                entity.Property(e => e.ImageLink)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Title).HasColumnName("title");
            });
        }
    }
}
