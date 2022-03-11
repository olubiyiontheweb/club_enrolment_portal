using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

using TheKangaroos_ClubEnrolmentPortal.Data.Models;

namespace TheKangaroos_ClubEnrolmentPortal.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Club> Clubs { get; set; }
        public override DbSet<IdentityUser> Users { get; set; }
        public DbSet<Event> Events { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.HasDefaultSchema("Identity");

            modelBuilder.Entity<IdentityUser>(entity =>
            {
                entity.ToTable(name: "User");
            });

            modelBuilder.Entity<IdentityRole>(entity =>
            {
                entity.ToTable(name: "Role");
            });
    
            modelBuilder.Entity<IdentityUserRole<string>>(entity =>
            {
                entity.ToTable("UserRoles");
            });
            
            modelBuilder.Entity<IdentityUserClaim<string>>(entity =>
            {
                entity.ToTable("UserClaims");
            });

            modelBuilder.Entity<IdentityUserLogin<string>>(entity =>
            {
                entity.ToTable("UserLogins");
            });
            
            modelBuilder.Entity<IdentityRoleClaim<string>>(entity =>
            {
                entity.ToTable("RoleClaims");
            });
            
            modelBuilder.Entity<IdentityUserToken<string>>(entity =>
            {
                entity.ToTable("UserTokens");
            });

            /* // clubs have one owner
            modelBuilder.Entity<Club>()
                .HasOne(c => c.Owner)
                .WithMany(u => u.OwnedClubs)
                .HasForeignKey(c => c.OwnerId); */

            /* modelBuilder.Entity<User>()
                .HasMany(u => u.OwnedClubs)
                .WithOne(c => c.Owner)
                .HasForeignKey(c => c.OwnerId); */

            // clubs have many events
            modelBuilder.Entity<Club>()
                .HasMany(c => c.Events)
                .WithOne(e => e.CreatedByClub)
                .HasForeignKey(e => e.CreatedByClubId);

            // events are created by a club
            modelBuilder.Entity<Event>()
                .HasOne(e => e.CreatedByClub)
                .WithMany(c => c.Events)
                .HasForeignKey(e => e.CreatedByClubId);
        }
    }
}
