using System;
using System.Linq;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace RealtimeSparky.Model
{
    public partial class SparkyContext : DbContext
    {

        public SparkyContext()
        {
        }

        public SparkyContext(DbContextOptions<SparkyContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Sparkyvalues> Sparkyvalues { get; set; }    
               
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Sparkyvalues>(entity =>
            {
                entity.ToTable("sparkyvalues");

                entity.HasIndex(e => e.Id)
                    .HasName("idnew_table_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Value)
                    .HasColumnName("value")
                    .HasColumnType("varchar(16000)");
            });
        }

    
    }
}
