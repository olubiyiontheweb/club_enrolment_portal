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

        public override DbSet<IdentityRole> Roles { get; set; }

        public DbSet<Membership> Memberships { get; set; }

        public DbSet<Event> Events { get; set; }

        public DbSet<Attendee> Attendees { get; set; }

        public DbSet<Enquiry> Enquiries { get; set; }

        public DbSet<Enrolment> Enrolments { get; set; }

        public DbSet<Payment> Payments { get; set; }
        
        public DbSet<Ticket> Tickets { get; set; }

        public DbSet<Venue> Venues { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<Notice> Notices { get; set; }

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
                .HasForeignKey(e => e.CreatedByClubId)
                .OnDelete(DeleteBehavior.Cascade);

            // events are created by a club
            modelBuilder.Entity<Event>()
                .HasOne(e => e.CreatedByClub)
                .WithMany(c => c.Events)
                .OnDelete(DeleteBehavior.NoAction);

            // users have many memberships
            modelBuilder.Entity<User>()
                .HasMany(u => u.Memberships)
                .WithOne(m => m.User)
                .HasForeignKey(m => m.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // clubs have many members
            modelBuilder.Entity<Club>()
                .HasMany(m => m.Members)
                .WithOne(m => m.Club)
                .HasForeignKey(c => c.ClubId)
                .OnDelete(DeleteBehavior.Cascade);

            // memberships has one user
            modelBuilder.Entity<Membership>()
                .HasOne(m => m.User)
                .WithMany(u => u.Memberships)
                .OnDelete(DeleteBehavior.NoAction);

            // memberships have one club
            modelBuilder.Entity<Membership>()
                .HasOne(m => m.Club)
                .WithMany(c => c.Members)
                .OnDelete(DeleteBehavior.NoAction);

            // notices belong to one clubs or users
            modelBuilder.Entity<Notice>()
                .HasOne(n => n.CreatedByClub)
                .WithMany(c => c.Notices)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Notice>()
                .HasOne(n => n.CreatedByUser)
                .WithMany(u => u.Notices)
                .OnDelete(DeleteBehavior.NoAction);

            // users have many notices
            modelBuilder.Entity<User>()
                .HasMany(u => u.Notices)
                .WithOne(n => n.CreatedByUser)
                .HasForeignKey(n => n.CreatedByUserId)
                .OnDelete(DeleteBehavior.NoAction);

            // clubs have many notices
            modelBuilder.Entity<Club>()
                .HasMany(c => c.Notices)
                .WithOne(n => n.CreatedByClub)
                .HasForeignKey(n => n.CreatedByClubId)
                .OnDelete(DeleteBehavior.Cascade);

            // events have one ticket
            /*modelBuilder.Entity<Event>()
                .HasOne(e => e.Ticket)
                .WithOne(t => t.Event)
                .HasForeignKey<Ticket>(t => t.EventId)
                .OnDelete(DeleteBehavior.Cascade);    */

            modelBuilder.Entity<Event>()
                .HasMany(e => e.Ticket)
                .WithOne(t => t.Event)
                .HasForeignKey(t => t.EventId)
                .OnDelete(DeleteBehavior.Cascade);

            // tickets belong to one event
            modelBuilder.Entity<Ticket>()
                .HasOne(t => t.Event)
                .WithMany(e => e.Ticket)
                .HasForeignKey(t => t.EventId)
                .OnDelete(DeleteBehavior.NoAction);

            // users have many tickets
            modelBuilder.Entity<User>()
                .HasMany(u => u.Tickets)
                .WithOne(t => t.User)
                .HasForeignKey(t => t.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // tickets belong to one user
            modelBuilder.Entity<Ticket>()
                .HasOne(t => t.User)
                .WithMany(u => u.Tickets)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
