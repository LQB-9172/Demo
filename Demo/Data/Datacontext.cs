using Microsoft.EntityFrameworkCore;
using static System.Net.Mime.MediaTypeNames;
using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Reflection.Emit;
using Microsoft.AspNetCore.Identity;

namespace Demo.Data
{
    public class Datacontext : IdentityDbContext<AppUser>
    {
        public Datacontext(DbContextOptions<Datacontext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Student>()
                .HasOne(s => s.User)
                .WithOne()
                .HasForeignKey<Student>(s => s.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<RefreshToken>()
            .HasOne(rt => rt.User)
            .WithMany()
            .HasForeignKey(rt => rt.UserId)
            .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<StudentLesson>()
            .HasOne(sl => sl.Student)
            .WithMany(s => s.StudentLessons)
            .HasForeignKey(sl => sl.StudentID)
            .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<StudentLesson>()
                .HasOne(sl => sl.Lesson)
                .WithMany()
                .HasForeignKey(sl => sl.LessonID)
                .OnDelete(DeleteBehavior.Restrict);
        }
        #region DbSet
        public DbSet<RefreshToken> RefreshTokens { get; set; }
        public DbSet<StudentLesson> StudentLessons { get; set; }
        public DbSet<Lesson>? Lessons { get; set; }
        public DbSet<Student>? Students { get; set; }
        public DbSet<Video>? Videos { get; set; }
        public DbSet<Image>? Images { get; set; }
        public DbSet<Progress>? Progresses { get; set; }
        public DbSet<Listening>? Questions { get; set; }
        public DbSet<Reading>? Readings { get; set; }
        public DbSet<TestResult>? TestResults { get; set; }
        public DbSet<IdentityUserRole<string>> UserRoles { get; set; }
        public DbSet<IdentityUserClaim<string>> UserClaims { get; set; }
        public DbSet<IdentityUserLogin<string>> UserLogins { get; set; }
        public DbSet<IdentityUserToken<string>> UserTokens { get; set; }
        #endregion

    }
}
