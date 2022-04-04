using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;

using TheKangaroos_ClubEnrolmentPortal.Data.Models;

namespace TheKangaroos_ClubEnrolmentPortal.Data
{
    public class ApplicationDbContext : IdentityDbContext<User, IdentityRole, string>
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        // Add DbSet properties here for names of tables in the database
        public DbSet<Club> Clubs { get; set; }
        public override DbSet<User> Users { get; set; }
        public DbSet<Event> Events { get; set; }

        public DbSet<Attendee> Attendees { get; set; }

        public DbSet<Enquiry> Enquiries { get; set; }

        public DbSet<Enrolment> Enrolments { get; set; }

        public DbSet<Membership> Memberships { get; set; }

        public DbSet<Payment> Payments { get; set; }
        
        public DbSet<Ticket> Tickets { get; set; }

        public DbSet<Venue> Venues { get; set; }

        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.HasDefaultSchema("TheKangaroos");

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable(name: "Users");
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

            // relationships

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

            // clubs have many events
            modelBuilder.Entity<Club>()
                .HasMany(c => c.Members)
                .WithOne(m => m.Club)
                .HasForeignKey(m => m.ClubId);

            // users have many memberships
            modelBuilder.Entity<User>()
                .HasMany(u => u.Memberships)
                .WithOne(m => m.User)
                .HasForeignKey(m => m.UserId);

            // memberships have one user
            modelBuilder.Entity<Membership>()
                .HasOne(m => m.User)
                .WithMany(u => u.Memberships)
                .HasForeignKey(m => m.UserId);

            // memberships have one club
            modelBuilder.Entity<Membership>()
                .HasOne(m => m.Club)
                .WithMany(c => c.Members)
                .HasForeignKey(e => e.ClubId);
        }
    }
}
