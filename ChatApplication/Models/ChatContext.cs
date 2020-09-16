using ChatApplication.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatApplication.Models
{


    public partial class ChatContext : DbContext
    {


        public ChatContext(DbContextOptions<ChatContext> options)
            : base(options)
        {
        }
       
        public  DbSet<UserChat> UserChat { get; set; }
        public  DbSet<UserLogin> UserLogin { get; set; }
        public DbSet<Group> Group { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                optionsBuilder.UseSqlServer("Server=DESKTOP-V10CQUK;Database=ChatDb;Trusted_Connection=True;");
                // optionsBuilder.UseSqlServer("Data Source=192.168.43.51,1433;Database=ChatDb;User Id=sa;Password=Hosting@123;MultipleActiveResultSets=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserChat>(entity =>
            {
                entity.HasKey(e => e.Chatid);

                entity.HasIndex(e => new { e.Senderid, e.Receiverid })
                    .HasName("NonClusteredIndex-20200419-114105");

                entity.Property(e => e.Chatid).ValueGeneratedNever();

                entity.Property(e => e.Connectionid).HasMaxLength(50);

                entity.Property(e => e.Messagedate).HasColumnType("datetime");

                entity.Property(e => e.Messagestatus).HasMaxLength(10);

                entity.Property(e => e.Receiverid).HasMaxLength(50);

                entity.Property(e => e.Senderid).HasMaxLength(50);
            });

            modelBuilder.Entity<UserLogin>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.UserName).HasMaxLength(50);

                entity.Property(e => e.UserPass).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}