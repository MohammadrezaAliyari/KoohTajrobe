using KoohTajrobe.Model.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using KoohTajrobe.Model;
using KoohTajrobe.Model.survey;
using KoohTajrobe.Model.User.Entities;

namespace KoohTajrobe.DataAccess
{
    public class KoohTajrobeDbContext : DbContext
    {
        public KoohTajrobeDbContext(DbContextOptions<KoohTajrobeDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Survey> Surveys { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserRole>().ToTable("UserRole").HasKey(r => new { r.Id });


            modelBuilder.Entity<UserRole>()
                     .HasOne<User>(s => s.User)
                     .WithMany(g => g.UserRoles)
                     .HasForeignKey(s => s.UserId);

            modelBuilder.Entity<UserRole>()
                     .HasOne<Role>(s => s.Role)
                     .WithMany(g => g.UserRoles)
                     .HasForeignKey(s => s.RoleId);

        }
    }
}
