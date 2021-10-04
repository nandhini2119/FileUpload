using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Data.SqlClient;
using Microsoft.EntityFrameworkCore.SqlServer;

namespace FileUpload.Models
{
    public partial class AppDbContext: DbContext
    {
        public AppDbContext()
        {

        }
        public AppDbContext(DbContextOptions<AppDbContext> options)
           : base(options)
        {
        }
        public virtual DbSet<FileData> FileData { get; set; }
        public virtual DbSet<BankStatement> BankStatement { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                /*warningTo protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.*/
             optionsBuilder.UseSqlServer("Server=DESKTOP-2N7VHQK\\SQLEXPRESS;Initial Catalog=fileUpload;Trusted_Connection=True;");
               
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<FileData>(entity =>
            {
                entity.Property(e => e.FileExtension).HasMaxLength(50);

                entity.Property(e => e.FileName).HasMaxLength(500);

                entity.Property(e => e.FilePath).HasMaxLength(500);

                entity.Property(e => e.MimeType).HasMaxLength(50);
            });

            modelBuilder.Entity<BankStatement>(entity =>
            {
                entity.Property(e => e.FileExtension).HasMaxLength(50);

                entity.Property(e => e.FileName).HasMaxLength(500);

                entity.Property(e => e.FilePath).HasMaxLength(500);

                entity.Property(e => e.MimeType).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);


    }
}
